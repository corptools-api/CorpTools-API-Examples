const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /documents

const STATUS = process.env.STATUS;

params = {
	status: STATUS
}

token = baseRequest.request.token({ path: '/documents' });

baseRequest.request.get({ path: '/documents', token: token, queryParams: params });
