# CorptoolsAPI examples
Each file contains GET and POST examples for your Corptools API implementation in various programming languages. Each example is designed to be encapsulated in a single executable file or folder, so you can pull down the code and run it as is. You'll need to update the `access_key` and `secret_key` with your credentials, along with the details of the request paramerters, to fit your own test. 

If you have not already been invited to your Gitter channel, please reach out to api@corporatetools.com to connect with the maintainers of this API. Communication through your Gitter channel is a fast and useful way to get your questions answered. 


* It is strongly recommended to use a [JWT library](https://jwt.io/) to create your token. This streamlines and simplifies your code; reducing the possiblity for error. 

* [JWT](https://jwt.io/) also has a helpful debugger on the homepage to test the structure token.  

# Environment Configurations
Create an `.env` file at the root directory of the project with the following properties defined:

```
DEBUG=true
ACCESS_KEY='<access-key>'
SECRET_KEY='<secret-key>'
API_URL='https://api.corporatetools.com'

# Optional, request dependent
CALLBACK_ID='<callback-id>'
CALLBACK_URL='<callback-url>'
COMPANY_ID='<company-id>'
COMPANY_NAME='<company-name>'
DOCUMENT_ID='<document-id>'
FILING_PRODUCT_ID='<filing-product-id>'
FILING_METHOD_ID='<filing-method-id>'
JURISDICTION='<jurisdiction-abbreviation>'
JURISDICTIONS='<comma-separated-list-of-jurisdiction-names>'
PAYMENT_METHOD_ID='<payment-method-id>'
SHOPPING_CART_ITEM_ID='<shopping-cart-item-id>'
WEBSITE_URL=<website-url>
```