const baseRequest = require('../base_request.js').baseRequest

token = baseRequest.request.token({ path: '/companies' });

baseRequest.request.get({ path: '/companies', token: token });