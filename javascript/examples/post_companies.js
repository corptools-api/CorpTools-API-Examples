let body = JSON.stringify(
	{ companies: [
		{ 
			name: 'An Example Company', 
			entity_type: 'Limited Liability Company', 
			jurisdictions: ['Maine', 'Washington']
		}]
	}
); 

token = require('../request.js').request.token({ path: '/companies' });

require('../request.js').request.post({ path: '/companies', token: token, body: body });