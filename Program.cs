using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages().AddMicrosoftIdentityUI();
builder.Services.AddMicrosoftIdentityWebAppAuthentication(builder.Configuration)
                .EnableTokenAcquisitionToCallDownstreamApi()
                .AddMicrosoftGraph()
                .AddInMemoryTokenCaches();

var app = builder.Build();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers(); // Note. Only Needed for Microsoft.Identity.Web.UI
app.MapRazorPages();
app.Run();
