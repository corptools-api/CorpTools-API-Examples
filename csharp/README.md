# Environment Configurations
Create an `.env` file at the root of the `csharp` folder with the following properties defined:

```
ACCESS_KEY='<access-key>'
SECRET_KEY='<secret-key>'
API_URL='https://api.corporatetools.com'

# Optional, request dependent
CALLBACK_URL='<callback-url>'
COMPANY_ID='<company-id>'
JURISDICTION='<jurisdiction-abbreviation>'
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
