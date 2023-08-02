const baseRequest = require('../base_request.js').baseRequest

const path = require('path');
process.chdir(path.resolve(__dirname, '../../'));
require('dotenv').config();

const fs = require('fs');
const currentWorkingDirectory = process.cwd();
const filePath = `${currentWorkingDirectory}/data/form_data_ein_tax_id.json`;

// Example of POST /order-items/requiring-attention

fs.readFile(filePath, 'utf8', (err, data) => {
  if (err) {
    console.error('Error reading the JSON file:', err);
    return;
  }

  try {
    const FORM_DATA = JSON.parse(data);
    console.log(`FORM_DATA: ${FORM_DATA}`);
    const COMPANY_ID = process.env.COMPANY_ID;
    const ORDER_ITEM_ID = process.env.ORDER_ITEM_ID;

    let body =
      {
        company_id: COMPANY_ID,
        order_item_id: ORDER_ITEM_ID,
        form_data: FORM_DATA
      };

    token = baseRequest.request.token({ path: '/order-items/requiring-attention', body: body });
    baseRequest.request.post({ path: '/order-items/requiring-attention', token: token, body: body });  
  } catch (parseError) {
    console.error('Error parsing form_data:', parseError);
  }
});