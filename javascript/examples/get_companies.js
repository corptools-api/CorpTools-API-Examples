token = require('../request.js').request.token({ path: '/companies' });

require('../request.js').request.get({ path: '/companies', token: token });