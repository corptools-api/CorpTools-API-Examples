const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /auth/forgot-password

const EMAIL = process.env.EMAIL;
const SUBDOMAIN = process.env.SUBDOMAIN;    // optional
const WEBSITE_ID = process.env.WEBSITE_ID;  // optional

let body =
{
  email_address: EMAIL,
  // subdomain: SUBDOMAIN,
  website_id: WEBSITE_ID
};

token = baseRequest.request.token({ path: '/auth/forgot-password', body: body });

baseRequest.request.post({ path: '/auth/forgot-password', token: token, body: body });