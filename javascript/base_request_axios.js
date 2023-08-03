require('dotenv').config({ path: '../.env' });
const axios = require('axios');
const CryptoJS = require("crypto-js");
const sign = require('jwt-encode');
const fs = require("fs").promises;
const pathModule = require("path");

const DEBUG = process.env.DEBUG;
const API_URL = process.env.API_URL;
const ACCESS_KEY = process.env.ACCESS_KEY;
const SECRET_KEY = process.env.SECRET_KEY;

exports.request = {
	token: function ({ path, body = null }) {
		let token = "";
		let header = { access_key: ACCESS_KEY };
		let payload = {
			path: path
		};

		if (body) {
			payload.content = CryptoJS.SHA256(JSON.stringify(body)).toString(CryptoJS.enc.Hex);
		} else {
			payload.content = CryptoJS.SHA256(encodeURIComponent('')).toString(CryptoJS.enc.Hex);
		}
		token = sign(payload, SECRET_KEY, header);
		if (DEBUG) console.log(`token=${token}`);
		return token;
	},
	base_request: async function ({ method, path, token, body = {} }) {
		let url = API_URL + path;
		if (DEBUG) console.log(`Axios: ${method} request to url=${url} body=${body}`);

		try {
			const response = await axios({
				method: method,
				url: url,
				data: body,
				responseType: 'arraybuffer',
				headers: {
					'Authorization': 'Bearer ' + token,
				},
			});

			// Check content type and save files accordingly (if needed)
			const request_name = method.toLowerCase() + path.replace(/\//g, "_");
			const contentType = response.headers['content-type'];
			if (contentType.includes('image/png')) {
				const buffer = Buffer.from(response.data);
				const filePath = pathModule.join(__dirname, 'documents', `${request_name}_response.png`);
				await fs.writeFile(filePath, buffer);
				console.log(`PNG file saved as ${request_name}_response.png`);
			} else if (contentType.includes('application/pdf')) {
				const buffer = Buffer.from(response.data);
				const filePath = pathModule.join(__dirname, 'documents', `${request_name}_response.pdf`);
				await fs.writeFile(filePath, buffer);
				console.log(`PDF file saved as ${request_name}_response.pdf`);
			} else {
				const dataAsString = response.data.toString();
				const dataAsJson = JSON.parse(dataAsString);
				console.log('response:', dataAsJson);
			}
		} catch (error) {
			console.log('error:', error.message, error.config.data);
		}
	},
	delete: function ({ path, token, body = {} }) {
		this.base_request({ method: 'DELETE', path: path, token: token, body: body });
	},
	get: function ({ path, token, queryParams = '' }) {
		if (Object.keys(queryParams).length) {
			const queryArray = [];
			for (let key in queryParams) {
				if (queryParams.hasOwnProperty(key)) {
					const value = queryParams[key];
					if (Array.isArray(value)) {
						for (const v of value) {
							queryArray.push(`${encodeURIComponent(key)}[]=${encodeURIComponent(v)}`);
						}
					} else if (typeof value === 'object') {
						queryArray.push(`${encodeURIComponent(key)}=${encodeURIComponent(JSON.stringify(value))}`);
					} else {
						queryArray.push(`${encodeURIComponent(key)}=${encodeURIComponent(value)}`);
					}
				}
			}
			const queryString = queryArray.join('&');
			path += '?' + queryString;
		}

		this.base_request({ method: 'GET', path: path, token: token });
	},
	patch: function ({ path, token, body = {} }) {
		this.base_request({ method: 'PATCH', path: path, token: token, body: body });
	},
	post: function ({ path, token, body = {} }) {
		this.base_request({ method: 'POST', path: path, token: token, body: body });
	}
}
