require('dotenv').config({ path: '../.env' });

const XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
const request = new XMLHttpRequest();
const jwt = require('jwt-simple');
const CryptoJS = require("crypto-js");

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
		console.log(`token=${token}`)
		return token;
	},
	delete: function ({ path, token, body = {} }) {
		// TODO
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
			url = API_URL + path + '?' + params.toString();
		} else {
			url = API_URL + path;
		}
		console.log(`GET request to url=${url}`);
		request.open('GET', url, true);
		request.setRequestHeader('Authorization', 'Bearer ' + token);
		request.setRequestHeader("Content-Type", "application/json");

		request.onload = function () {
		    if (request.readyState === 4 && request.status === 200) {
		        let response = JSON.parse(request.responseText);
		        console.log(response);
		    } else {
		    	 console.log("Error", JSON.parse(request.responseText)); 
		    }
		};

		request.send();
	},
	patch: function ({ path, token, body = {} }) {
		// TODO
	},
	post: function ({ path, token, body = {} }) {
		body = JSON.stringify(body)
		let payload = {
		  path: path,
		  content: CryptoJS.SHA256(body).toString(CryptoJS.enc.Hex)
		}; 
		let url = API_URL + path
		console.log(`POST request to url=${url}`);
		request.open('POST', url, true);
		request.setRequestHeader('Authorization', 'Bearer ' + token);
		request.setRequestHeader("Content-Type", "application/json");

		request.onload = function () {
		    if (request.readyState === 4 && request.status === 200) {
		        let response = JSON.parse(request.responseText);
		        console.log(response);
		    } else {
		    	console.log("Error", JSON.parse(request.responseText)); 
		    }
		};

		request.send(body);
	}
}
