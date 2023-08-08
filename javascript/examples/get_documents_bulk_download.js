const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /documents/bulk-download

const DOCUMENT_ID = process.env.DOCUMENT_ID;

params = {
  ids: [DOCUMENT_ID]
}

token = baseRequest.request.token({ path: '/documents/bulk-download' , queryParams: params});

baseRequest.request.get({ path: '/documents/bulk-download', token: token, queryParams: params});
