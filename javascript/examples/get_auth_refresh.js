const baseRequest = require('../base_request.js').baseRequest

// Example of GET /auth/refresh

token = baseRequest.request.token({ path: '/auth/refresh' });

baseRequest.request.get({ path: '/auth/refresh', token: token });