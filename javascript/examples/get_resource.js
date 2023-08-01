const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /resources/:id

RESOURCE_ID = process.env.AGENCY_RESOURCE_ID
url_path = `/resources/${RESOURCE_ID}`
token = baseRequest.request.token({ path: url_path });
baseRequest.request.get({ path: url_path, token: token });