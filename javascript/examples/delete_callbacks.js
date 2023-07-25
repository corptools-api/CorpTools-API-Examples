const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of DELETE /callbacks/:id

const CALLBACK_ID = process.env.CALLBACK_ID;
const url_path = `/callbacks/${CALLBACK_ID}`

token = baseRequest.request.token({ path: url_path});

baseRequest.request.delete({ path: url_path, token: token });