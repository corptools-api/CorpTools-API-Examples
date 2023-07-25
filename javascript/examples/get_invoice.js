const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const INVOICE_ID = process.env.INVOICE_ID;

token = baseRequest.request.token({ path: `/invoices/${INVOICE_ID}` });

baseRequest.request.get({ path: `/invoices/${INVOICE_ID}`, token: token });
