const args = process.argv.slice(2) // Loads either plain JS or axios base request based on CLI flag from package.json

const isAxios = args[0] == 'axios' || !args.length
const baseRequest = isAxios ? require('./base_request_axios.js') : require('./base_request_javascript.js')

module.exports = { baseRequest }