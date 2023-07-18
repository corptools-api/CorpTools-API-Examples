require('dotenv').config();

const COMPANY_ID    = process.env.COMPANY_ID;
const COMPANY_NAME  = process.env.COMPANY_NAME;
let body =
  {
    companies: [
      {
        company_id: COMPANY_ID,
        name: COMPANY_NAME,
      }
    ]
  }; 

token = require('../request.js').request.token({ path: '/companies', body: body });

require('../request.js').request.patch({ path: '/companies', token: token, body: body });