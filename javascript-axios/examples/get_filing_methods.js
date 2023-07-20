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

token = require('../request.js').request.token({ path: '/filing-methods' });

require('../request.js').request.get({ path: '/filing-methods', token: token, queryParams: params });