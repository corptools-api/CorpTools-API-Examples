const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /documents/:document_id

const DOCUMENT_ID = process.env.DOCUMENT_ID;

token = baseRequest.request.token({ path: `/documents/${DOCUMENT_ID}` });

baseRequest.request.get({ path: `/documents/${DOCUMENT_ID}`, token: token });
