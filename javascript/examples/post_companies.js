const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const COMPANY_NAME = process.env.COMPANY_NAME;
const JURISDICTION = process.env.JURISDICTION;
const ENTITY_TYPE = process.env.ENTITY_TYPE;

let body =
{
  companies: [
    {
      name: COMPANY_NAME,
      home_state: JURISDICTION,
      entity_type: ENTITY_TYPE
    }
  ]
};

token = baseRequest.request.token({ path: '/companies', body: body });

baseRequest.request.post({ path: '/companies', token: token, body: body });