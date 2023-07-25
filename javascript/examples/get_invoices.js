const baseRequest = require('../base_request.js').baseRequest

// Example GET /invoices
// An array of company names or company_ids may be provided, but not both

const COMPANY_ID = process.env.COMPANY_ID

params = {
  company_ids: [COMPANY_ID]
}

token = baseRequest.request.token({ path: '/invoices' });

baseRequest.request.get({ path: '/invoices', token: token, queryParams: params });
