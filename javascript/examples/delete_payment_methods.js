const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of DELETE /payment-methods/:id

const PAYMENT_METHOD_ID = process.env.PAYMENT_METHOD_ID;
const url_path = `/payment-methods/${PAYMENT_METHOD_ID}`;
token = require('../request.js').request.token({ path: url_path });

require('../request.js').request.delete({ path: url_path, token: token });