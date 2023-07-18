let body = { 
	companies: [
		{ 
			name: 'Another Example Company', 
			entity_type: 'Limited Liability Company', 
			jurisdictions: ['Maine', 'Washington']
		}
	]
};

token = require('../request.js').request.token({ path: '/companies', body: body });

require('../request.js').request.post({ path: '/companies', token: token, body: body });