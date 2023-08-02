const baseRequest = require('../base_request.js').baseRequest

// Example of GET /account

token = baseRequest.request.token({ path: '/account' });

baseRequest.request.get({ path: '/account', token: token });