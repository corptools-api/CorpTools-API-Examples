const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

// Example of GET /documents/:document_id/page/:page_number

// The specified page of the document is saved as a png in the 'documents' directory

const DOCUMENT_ID = process.env.DOCUMENT_ID;
const PAGE_NUMBER = process.env.PAGE_NUMBER;

token = baseRequest.request.token({ path: `/documents/${DOCUMENT_ID}/page/${PAGE_NUMBER}` });

baseRequest.request.get({ path: `/documents/${DOCUMENT_ID}/page/${PAGE_NUMBER}`, token: token });
