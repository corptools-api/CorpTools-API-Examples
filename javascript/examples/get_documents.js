const baseRequest = require('../base_request.js').baseRequest

params = {
	status: 'unread'
}

token = baseRequest.request.token({ path: '/documents' });

baseRequest.request.get({ path: '/documents', token: token, queryParams: params });