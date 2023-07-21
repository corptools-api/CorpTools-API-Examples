require('dotenv').config({ path: '../.env' });
const axios = require('axios');
const CryptoJS = require("crypto-js");
const sign = require('jwt-encode');

const DEBUG			= process.env.DEBUG;
const API_URL		= process.env.API_URL;
const ACCESS_KEY 	= process.env.ACCESS_KEY;
const SECRET_KEY 	= process.env.SECRET_KEY;

exports.request = {
	token: function({ path, body = null }) {
		let token = "";
		let header = { access_key: ACCESS_KEY};
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
	base_request: function({ method, path, token, body = {}}) {
		let url = API_URL + path;
		if (DEBUG) console.log(`Axios: ${method} request to url=${url} body=${body}`);
		axios({
		  method: method,
		  url: url,
		  data: body,
		  headers: {
		    'Authorization': 'Bearer ' + token,
		  },
		}).then(response => {
		  console.log('response:', response.data)
		}).catch(error => {
		  console.log('error:', error.message, error.config.data)
		})
	},
	delete: function({ path, token, body = {} }) {
		this.base_request({ method: 'DELETE', path: path, token: token, body: body });
	},
	get: function ({ path, token, queryParams = '' }) {
		let url;
		if (queryParams) {
			// read in query parameters to set on the URL
			const params = new URLSearchParams();
			for (let key in queryParams) {
			  if (queryParams.hasOwnProperty(key)) {
			    const value = queryParams[key];
			    params.append(key, value);
			  }
			}
			path += '?' + params.toString();
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
