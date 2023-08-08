const baseRequest = require('../base_request.js').baseRequest
const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const fs = require('fs');
const currentWorkingDirectory = process.cwd();
const filePath = `${currentWorkingDirectory}/data/services/add_info_corp.json`;

// Example of POST /services/:service_id/info

const SERVICE_ID = process.env.SERVICE_ID

fs.readFile(filePath, 'utf8', (err, data) => {
  if (err) {
    console.error('Error reading the JSON file:', err);
    return;
  }

  try {
	body = JSON.parse(data);
	url_path = `/services/${SERVICE_ID}/info`;
	token = baseRequest.request.token({ path: url_path, body: body });
	baseRequest.request.post({ path: url_path, token: token, body: body }); 
  } catch (parseError) {
    console.error('Error parsing form_data:', parseError);
  }
});