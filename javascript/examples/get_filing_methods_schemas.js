const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// GET /filing-methods/schemas
const COMPANY_ID	= process.env.COMPANY_ID;
const METHOD_ID 	= process.env.FILING_METHOD_ID;

params = {
  company_id: COMPANY_ID,
  filing_method_id: METHOD_ID
}

token = baseRequest.request.token({ path: '/filing-methods/schemas' });

baseRequest.request.get({ path: '/filing-methods/schemas', token: token, queryParams: params });
