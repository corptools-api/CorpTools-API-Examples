const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /shopping-cart/checkout

const COMPANY_ID		= process.env.COMPANY_ID;
const ITEM_ID 			= process.env.SHOPPING_CART_ITEM_ID;
const PAYMENT_METHOD_ID = process.env.PAYMENT_METHOD_ID;

let body = { 
	company_ids: [COMPANY_ID],
	item_ids: [ITEM_ID],
	payment_token: PAYMENT_METHOD_ID
};

token = baseRequest.request.token({ path: '/shopping-cart/checkout', body: body });

baseRequest.request.post({ path: '/shopping-cart/checkout', token: token, body: body });