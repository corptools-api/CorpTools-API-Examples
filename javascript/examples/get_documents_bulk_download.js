const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example GET /documents/bulk-download

const DOCUMENT_IDS = [process.env.DOCUMENT_ID];

const idsArray = DOCUMENT_IDS.map((id) => `ids[]=${encodeURIComponent(id)}`);
const queryString = idsArray.join('&');
const urlWithParams = `/documents/bulk-download?${queryString}`

token = baseRequest.request.token({ path: urlWithParams });

baseRequest.request.get({ path: urlWithParams, token: token});
