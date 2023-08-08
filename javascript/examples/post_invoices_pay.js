const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of POST /invoices/pay

const PAYMENT_METHOD_ID = process.env.PAYMENT_METHOD_ID;
const INVOICE_ID = process.env.INVOICE_ID;

let body =
  {
    payment_token: PAYMENT_METHOD_ID,
    invoice_ids: [INVOICE_ID]
  };

token = baseRequest.request.token({ path: '/invoices/pay', body: body });

baseRequest.request.post({ path: '/invoices/pay', token: token, body: body });
