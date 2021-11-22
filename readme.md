# Super Minimal .NET 6 Web App with Auth and Graph API

This is just a scrap of code really to show a working web app in .NET 6 with the new minimal hosting model. It adds sign-in auth with `Microsoft.Identity.Web` library and Graph API support

The entire Program.cs is shown below in all it's super minimal glory
```cs
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApp(builder.Configuration)
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddMicrosoftGraph()
                .AddInMemoryTokenCaches();

var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
```

# Pre-reqs
- .NET 6 - https://dotnet.microsoft.com/download/dotnet/6.0
- A registered app in Azure AD with a secret - https://docs.microsoft.com/en-us/azure/active-directory/develop/quickstart-register-app
  - Add a "web application" for signin
  - Set the redirect URL to be `https://localhost:5001/signin-oidc`

# Quick Start

- Copy `appsettings.Development.json.sample` to `appsettings.Development.json` and update any references to `__CHANGEME__` in the file.
- Run `dotnet watch` or `dotnet run`
- Go to https://localhost:5001 
- **Note. Only the HTTPS version will work due to cookies blah security blah something**
- Click On "Account" to sign-in and have various details about the user shown