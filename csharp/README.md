# Environment Configurations
Create an `.env` file at the root of the `csharp` folder with the following properties defined:

```
ACCESS_KEY='<access-key>'
SECRET_KEY='<secret-key>'
API_URL='https://api.corporatetools.com'

# Optional, request dependent
COMPANY_ID='<company-id>'
COMPANY_NAME='<company-name>'
JURISDICTION='<jurisdiction-abbreviation>'
DOCUMENT_ID='<document-id>'
FILING_PRODUCT_ID='<filing-product-id>'
FILING_METHOD_ID='<filing-method-id>'
WEBSITE_URL=<website-url>
```

# Running Examples
- The Main function entrypoint of the application is in Example.cs
- Uncomment the `request*` function you wish to call

## Running from command-line: 
- `dotnet add package System.IdentityModel.Tokens.Jwt`
- `dotnet add package RestSharp`
- `dotnet add package Newtonsoft.Json`
- `dotnet refresh`
- `dotnet build`
- `dotnet run Example.cs`
