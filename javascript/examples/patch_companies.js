const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of PATCH /companies

// this example will update the company name

const COMPANY = process.env.COMPANY_NAME;
const NAME = 'Awesome Newer Name'

let body =
  {
    companies: [
      {
        company: COMPANY,
        name: NAME
      }
    ]
  };

token = baseRequest.request.token({ path: '/companies', body: body });

baseRequest.request.patch({ path: '/companies', token: token, body: body });