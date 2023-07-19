const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const COMPANY_ID = process.env.COMPANY_ID;
const JURISDICTION = process.env.JURISDICTION;

params = {
	company_id: COMPANY_ID,
	jurisdiction: JURISDICTION
}

token = require('../request.js').request.token({ path: '/filing-products/offerings' });

require('../request.js').request.get({ path: '/filing-products/offerings', token: token, queryParams: params });