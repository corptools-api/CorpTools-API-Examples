const baseRequest = require('../base_request.js').baseRequest

// Example GET /payment-methods

token = baseRequest.request.token({ path: '/payment-methods' });

baseRequest.request.get({ path: '/payment-methods', token: token });