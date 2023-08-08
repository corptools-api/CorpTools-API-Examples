const baseRequest = require('../base_request.js').baseRequest

// Example of GET /callbacks

token = baseRequest.request.token({ path: '/callbacks' });

baseRequest.request.get({ path: '/callbacks', token: token });