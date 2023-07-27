const baseRequest = require('../base_request.js').baseRequest

// Example GET /account

token = baseRequest.request.token({ path: '/account' });

baseRequest.request.get({ path: '/account', token: token });