const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const WEBSITE_URL = process.env.WEBSITE_URL;
const JURISDICTION = process.env.JURISDICTION;

params = {
  url: WEBSITE_URL,
  jurisdiction: JURISDICTION
}

token = require('../request.js').request.token({ path: '/filing-products' });

require('../request.js').request.get({ path: '/filing-products', token: token, queryParams: params });