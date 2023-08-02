const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /documents/:document_id/download

// The specified document is saved as a pdf in the 'documents' directory

const DOCUMENT_ID = process.env.DOCUMENT_ID;

token = baseRequest.request.token({ path: `/documents/${DOCUMENT_ID}/download` });

baseRequest.request.get({ path: `/documents/${DOCUMENT_ID}/download`, token: token });
