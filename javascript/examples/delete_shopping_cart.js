const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of DELETE /shopping-cart/:id

const COMPANY_ID = process.env.COMPANY_ID;
const SHOPPING_CART_ITEM_ID = process.env.SHOPPING_CART_ITEM_ID;

let body =
{
  company_ids: [COMPANY_ID],
  item_ids: [SHOPPING_CART_ITEM_ID]
};

token = baseRequest.request.token({ path: '/shopping-cart', body: body });

baseRequest.request.delete({ path: '/shopping-cart', token: token, body: body });