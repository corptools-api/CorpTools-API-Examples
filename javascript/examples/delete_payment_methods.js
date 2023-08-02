const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of DELETE /payment-methods/:payment_method_id

const PAYMENT_METHOD_ID = process.env.PAYMENT_METHOD_ID;
const url_path = `/payment-methods/${PAYMENT_METHOD_ID}`;
token = baseRequest.request.token({ path: url_path });

baseRequest.request.delete({ path: url_path, token: token });