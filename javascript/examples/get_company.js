const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const COMPANY_ID = process.env.COMPANY_ID;

token = require('../request.js').request.token({ path: `/companies/${COMPANY_ID}` });

require('../request.js').request.get({ path: `/companies/${COMPANY_ID}`, token: token });