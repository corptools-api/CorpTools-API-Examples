const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of PATCH /payment-methods/:payment_method_id

const PAYMENT_METHOD_ID = process.env.PAYMENT_METHOD_ID;
const CARD_NUMBER = '4000056655665556'
const EXP_MONTH = '05'
const EXP_YEAR = '2032'
const CVC = '999'
const FIRST_NAME = 'Cookie'
const LAST_NAME = 'Monster'
const BILLING_ADDRESS= {
    "city": "New York",
    "state": "NY",
    "zip": "10463",
    "country": "US",
    "address1": "9876 Seasame Street",
    "address2": null
  }

let body = { 
	number: CARD_NUMBER,
	exp_month: EXP_MONTH,
	exp_year: EXP_YEAR,
	cvc: CVC,
	first_name: FIRST_NAME,
	last_name: LAST_NAME,
	billing_address: BILLING_ADDRESS
};

const url_path = `/payment-methods/${PAYMENT_METHOD_ID}`;

token = baseRequest.request.token({ path: url_path, body: body });

baseRequest.request.patch({ path: url_path, token: token, body: body });