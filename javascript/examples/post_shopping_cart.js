const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /shopping-cart

const COMPANY_ID		= process.env.COMPANY_ID;
const FILING_PRODUCT_ID	= process.env.FILING_PRODUCT_ID;
const FILING_METHOD_ID 	= process.env.FILING_METHOD_ID;
const QUANTITY = 1;
// const FORM_DATA = {}; // optional, expects JSON mapping to fields of filing method schema

let body = { 
	company_id: COMPANY_ID,
	product_id: FILING_PRODUCT_ID,
	product_option_id: FILING_METHOD_ID,
	quantity: QUANTITY,
	// form_data: FORM_DATA
};

token = baseRequest.request.token({ path: '/shopping-cart', body: body });

baseRequest.request.post({ path: '/shopping-cart', token: token, body: body });