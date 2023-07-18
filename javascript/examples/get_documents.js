params = {
	status: 'unread'
}

token = require('../request.js').request.token({ path: '/documents' });

require('../request.js').request.get({ path: '/documents', token: token, queryParams: params });