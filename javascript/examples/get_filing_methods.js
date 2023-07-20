const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const COMPANY_ID	= process.env.COMPANY_ID;
const JURISDICTION 	= process.env.JURISDICTION;
const PRODUCT_ID 	= process.env.FILING_PRODUCT_ID;

params = {
	company_id: COMPANY_ID,
  	jurisdiction: JURISDICTION,
  	filing_product_id: PRODUCT_ID
}

token = baseRequest.request.token({ path: '/filing-methods' });

baseRequest.request.get({ path: '/filing-methods', token: token, queryParams: params });