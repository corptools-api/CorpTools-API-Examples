exports.get = {
	getDocuments: function(apiUrl, jwt, CryptoJS, request, keys) {
		let params = JSON.stringify({ status: 'unread' }); 
		// GET requests encode an empty body in the content payload
		let payload = {
		  path: '/documents',
		  content: CryptoJS.SHA256(encodeURIComponent('')).toString(CryptoJS.enc.Hex)
		}; 

		let header = { access_key: keys.access_key }; 

		let token = jwt.encode(payload, keys.secret_key, 'HS256', { header: header });

		let url = apiUrl + '/documents?' + encodeURIComponent(params)

		request.open('GET', url, true);
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

		request.send();
	}

}
