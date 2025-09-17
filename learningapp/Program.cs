using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect("Endpoint=https://learnappconfig.azconfig.io;Id=cbnO;Secret=FrCURbwVNzbZtePAkuBQdyZ1W5imFdGsxIyTJrYYxoQpJLYXEpnbJQQJ99BIAC1i4TkFv1zqAAABAZAC4byf");
    options.UseFeatureFlags();
});
builder.Services.AddFeatureManagement();
// .AddJsonFile("appsettings.json")
//     .AddEnvironmentVariables();
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

app.UseAuthorization();

app.MapRazorPages();

app.Run();
