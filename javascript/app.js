const XMLHttpRequest = require("xmlhttprequest").XMLHttpRequest;
let jwt = require('jwt-simple');
let CryptoJS = require("crypto-js");

let request = new XMLHttpRequest();

let keys = {
	access_key = 'xxxxx'
	secret_key = 'xxxxx'
}

require('./get_example.js').get.getDocuments(jwt, CryptoJS, request, keys);
require('./post_example.js').post.postCompanies(jwt, CryptoJS, request, keys);
