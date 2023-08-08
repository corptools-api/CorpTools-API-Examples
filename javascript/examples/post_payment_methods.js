const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /payment-methods

const CARD_NUMBER = '4000056655665556'
const EXP_MONTH = '12'
const EXP_YEAR = '2028'
const CVC = '123'
const FIRST_NAME = 'Count'
const LAST_NAME = 'Dracula'
const BILLING_ADDRESS= {
    "city": "New York",
    "state": "NY",
    "zip": "10463",
    "country": "US",
    "address1": "1234 Seasame Street",
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

token = baseRequest.request.token({ path: '/payment-methods', body: body });

baseRequest.request.post({ path: '/payment-methods', token: token, body: body });