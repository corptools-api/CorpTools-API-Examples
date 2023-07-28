const baseRequest = require('../base_request.js').baseRequest

// Example GET /services/:id/info

const SERVICE_ID = process.env.SERVICE_ID

url_path = `/services/${SERVICE_ID}/info`

token = baseRequest.request.token({ path: url_path });

baseRequest.request.get({ path: url_path, token: token });