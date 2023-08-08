const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /services/:service_id/cancel-request

const SERVICE_ID = process.env.SERVICE_ID

const url_path = `/services/${SERVICE_ID}/cancel-request`;
const token = baseRequest.request.token({ path: url_path });
baseRequest.request.post({ path: url_path, token: token }); 