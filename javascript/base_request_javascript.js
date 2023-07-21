require('dotenv').config({ path: '../.env' });

const XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
const request = new XMLHttpRequest();
const jwt = require('jwt-simple');
const CryptoJS = require("crypto-js");

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

		token = jwt.encode(payload, SECRET_KEY, 'HS256', { header: header });
		if (DEBUG) console.log(`token=${token}`)
		return token;
	},
	base_request: function({ method, path, token, body = null }) {
		let url = API_URL + path;
		body = JSON.stringify(body);
		if (DEBUG) console.log(`XHR: ${method} ${url} body=${body}`);
		request.open(method, url, true);
		request.setRequestHeader('Authorization', 'Bearer ' + token);
		request.setRequestHeader("Content-Type", "application/json");
		request.onload = function () {
		    if (request.readyState === 4 && request.status === 200) {
		        let response = JSON.parse(request.responseText);
		        console.log(response);
		    } else {
		    	console.log(`ERROR: status=${request.status} msg=${request.responseText}`)
		    }
		};
		if (body == null) {
			request.send();
		} else {
			request.send(body);
		}
	},
	delete: function ({ path, token, body = {} }) {
		this.base_request({ method: 'DELETE', path: path, token: token, body: body });
	},
	get: function ({ path, token, queryParams = '' }) {
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
