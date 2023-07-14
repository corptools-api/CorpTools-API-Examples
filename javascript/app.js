require('dotenv').config();

const XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
let jwt = require('jwt-simple');
let CryptoJS = require("crypto-js");

let request = new XMLHttpRequest();

let apiUrl = process.env.API_URL

let keys = {
	access_key: process.env.ACCESS_KEY,
	secret_key: process.env.SECRET_KEY
}

require('./get_example.js').get.getDocuments(apiUrl, jwt, CryptoJS, request, keys);

// require('./post_example.js').post.postCompanies(apiUrl, jwt, CryptoJS, request, keys);
