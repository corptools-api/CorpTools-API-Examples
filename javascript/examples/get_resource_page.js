const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /resources/:resource_id/page/:page_number

RESOURCE_ID = process.env.AGENCY_RESOURCE_ID
PAGE_NUMBER = process.env.PAGE_NUMBER
url_path = `/resources/${RESOURCE_ID}/page/${PAGE_NUMBER}`
token = baseRequest.request.token({ path: url_path });
baseRequest.request.get({ path: url_path, token: token });