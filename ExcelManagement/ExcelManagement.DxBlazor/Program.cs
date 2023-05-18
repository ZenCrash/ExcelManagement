using ExcelManagement.ClassLibary;
using ExcelManagement.DxBlazor.Areas.Identity;
using ExcelManagement.DxBlazor.Data;
using ExcelManagement.DxBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ExcelManagementDxBlazorContextConnection") ?? throw new InvalidOperationException("Connection string 'ExcelManagementDxBlazorContextConnection' not found.");

builder.Services.AddDbContext<ExcelManagementDxBlazorContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ExcelManagementDxBlazorContext>();

//Clean on startup
SheetLogic sheetLogic = new();
FileLogic fileLogic = new();

//Clean json files on startup
sheetLogic.CleanJsonFiles();
//Clean Temp Folder
fileLogic.DeleteFilesInTempFolder();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
    options.SizeMode = DevExpress.Blazor.SizeMode.Medium;
});
builder.Services.AddSingleton<WeatherForecastService>();

//token provider
builder.Services.AddScoped<TokenProvider>();

builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

//user service
builder.Services.AddSingleton<UserService>();

builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

//token access
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.UseAuthentication();;

app.Run();