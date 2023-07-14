exports.post = {
	postCompanies: function(apiUrl, jwt, CryptoJS, request, keys) {
		let body = JSON.stringify(
			{ companies: [
				{ 
					name: 'Example Company', 
					entity_type: 'Limited Liability Company', 
					jurisdictions: ['Maine', 'Washington']
				}]
			}
		); 

		let payload = {
		  path: '/companies',
		  content: CryptoJS.SHA256(body).toString(CryptoJS.enc.Hex)
		}; 

		let header = { access_key: keys.access_key }; 

		let token = jwt.encode(payload, keys.secret_key, 'HS256', { header: header });

		let url = apiUrl + '/companies'

		request.open('POST', url, true);
		request.setRequestHeader('Authorization', 'Bearer ' + token);
		request.setRequestHeader("Content-Type", "application/json");

		request.onload = function () {
		    if (request.readyState === 4 && request.status === 200) {
		        let response = JSON.parse(request.responseText);
		        console.log(response);
		    } else {
		    	console.log("Error", JSON.parse(request.responseText)); 
		    }
		};

		request.send(body);
	}
}