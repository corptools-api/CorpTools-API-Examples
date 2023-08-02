const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /invoices

// An array of company names or company_ids may be provided, but not both

const COMPANY_IDS = [process.env.COMPANY_ID];

const idsArray = COMPANY_IDS.map((id) => `company_ids[]=${encodeURIComponent(id)}`);
const queryString = idsArray.join('&');
const urlWithParams = `/invoices?${queryString}`

token = baseRequest.request.token({ path: urlWithParams });

baseRequest.request.get({ path: urlWithParams, token: token});

