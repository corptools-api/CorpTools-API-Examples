const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /auth/reset-password

const TOKEN = process.env.RESET_PASSWORD_TOKEN;
const PASSWORD = process.env.PASSWORD;

let body =
{
  token: TOKEN,
  password: PASSWORD,
  password_confirmation: PASSWORD
};

token = baseRequest.request.token({ path: '/auth/reset-password', body: body });

baseRequest.request.post({ path: '/auth/reset-password', token: token, body: body });