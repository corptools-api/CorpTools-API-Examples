const baseRequest = require('../base_request.js').baseRequest

// Example GET /account/dashpanel

token = baseRequest.request.token({ path: '/account/dashpanel' });

baseRequest.request.get({ path: '/account/dashpanel', token: token });