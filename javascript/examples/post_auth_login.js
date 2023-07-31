const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /auth/login

const URL = process.env.CALLBACK_URL;

const EMAIL = process.env.EMAIL;
const PASSWORD = process.env.PASSWORD;
const WEBSITE_ID = process.env.WEBSITE_ID; // optional

let body =
{
  email: EMAIL,
  password: PASSWORD,
  website_id: WEBSITE_ID
};

token = baseRequest.request.token({ path: '/auth/login', body: body });

baseRequest.request.post({ path: '/auth/login', token: token, body: body });