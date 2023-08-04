require('dotenv').config({ path: '../.env' });
const fetch = require("isomorphic-fetch");
const jwt = require("jwt-simple");
const CryptoJS = require("crypto-js");
const fs = require("fs").promises;
const pathModule = require("path");

const DEBUG = process.env.DEBUG;
const API_URL = process.env.API_URL;
const ACCESS_KEY = process.env.ACCESS_KEY;
const SECRET_KEY = process.env.SECRET_KEY;

exports.request = {
	token: function({ path, body = null, queryParams = {} }) {
		let token = "";
		let header = { access_key: ACCESS_KEY };
		let payload = { path: path };

		if (body) {
			payload.content = CryptoJS.SHA256(JSON.stringify(body)).toString(CryptoJS.enc.Hex);
		} else {
			payload.content = CryptoJS.SHA256(encodeURIComponent('')).toString(CryptoJS.enc.Hex);
		}

		token = jwt.encode(payload, SECRET_KEY, 'HS256', { header: header });
		if (DEBUG) console.log(`token=${token}`);
		return token;
	},

	base_request: async function({ method, path, token, body = null }) {
		let url = API_URL + path;
		let headers = {
			'Authorization': 'Bearer ' + token,
			'Content-Type': 'application/json',
		};
		let options = {
			method: method,
			headers: headers,
			body: body ? JSON.stringify(body) : null,
		};

		try {
			const response = await fetch(url, options);
			if (!response.ok) {
				throw new Error(`Request failed with HTTP status code: ${response.status}`);
			}

			const contentType = response.headers.get('content-type');

			if (contentType?.includes('application/json')) {
				const responseData = await response.json();
				console.log(responseData);
				return responseData;
			} else if (contentType?.includes('image/png') || contentType?.includes('application/pdf')) {
				const buffer = await response.arrayBuffer();
				const request_name = method.toLowerCase() + path.replace(/\//g, "_");
				const fileName = contentType?.includes('image/png') ? `${request_name}_response.png` : `${request_name}_response.pdf`;
				const filePath = pathModule.join(__dirname, 'documents', fileName);
				await fs.writeFile(filePath, Buffer.from(buffer));
				console.log(`${fileName} saved to /documents successfully.`);
			} else {
				const responseData = await response.text();
				console.log(responseData);
			}
		} catch (error) {
			console.log('ERROR:', error.message);
		}
	},

	delete: async function ({ path, token, body = {} }) {
		let response = await this.base_request({ method: 'DELETE', path: path, token: token, body: body });
		return response;
	},

	get: async function ({ path, token, queryParams = {} }) {
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
		let response = await this.base_request({ method: 'GET', path: path, token: token });
		return response;
	},

	patch: async function ({ path, token, body = {} }) {
		let response = await this.base_request({ method: 'PATCH', path: path, token: token, body: body });
		return response;
	},

	post: async function ({ path, token, body = {} }) {
		let response = await this.base_request({ method: 'POST', path: path, token: token, body: body });
		return response;
	}
};
