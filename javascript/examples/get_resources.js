const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /resources

token = baseRequest.request.token({ path: '/resources' });
baseRequest.request.get({ path: '/resources', token: token });