const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /resources/:resource_id/download

// The specified resource is saved as a pdf in the 'documents' directory

const RESOURCE_ID = process.env.AGENCY_RESOURCE_ID;

token = baseRequest.request.token({ path: `/resources/${RESOURCE_ID}/download` });

baseRequest.request.get({ path: `/resources/${RESOURCE_ID}/download`, token: token });
