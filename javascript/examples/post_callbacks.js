const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example POST /callbacks

const URL = process.env.CALLBACK_URL;

let body =
{
  url: URL
};

token = baseRequest.request.token({ path: '/callbacks', body: body });

baseRequest.request.post({ path: '/callbacks', token: token, body: body });