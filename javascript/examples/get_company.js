const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /companies/:company_id

const COMPANY_ID = process.env.COMPANY_ID;

token = baseRequest.request.token({ path: `/companies/${COMPANY_ID}` });

baseRequest.request.get({ path: `/companies/${COMPANY_ID}`, token: token });