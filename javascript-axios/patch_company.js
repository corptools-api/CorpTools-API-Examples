const axios = require('axios')
const crypto = require('crypto-js')
const sign = require('jwt-encode')

let keys = {
  access_key: process.env.ACCESS_KEY,
  secret_key: process.env.SECRET_KEY,
}

let url = 'https://api.corporatetools.com'
let data = {
  companies: [
    {
      company_id: '<uuid>',
      name: '<new company name>',
    }
  ]
}
let query_string = ''
let request_body = JSON.stringify(data)

let payload = {
  path: '/companies',
  content: crypto.SHA256(query_string + request_body).toString(crypto.enc.Hex),
}
let token = sign(payload, keys.secret_key, { access_key: keys.access_key })

axios({
  method: 'PATCH',
  url: url + payload.path,
  data: data,
  headers: {
    'Authorization': 'Bearer ' + token,
  },
}).then(response => {
  console.log('response:', response.data)
}).catch(error => {
  console.log('error:', error.message, error.config.data)
})
