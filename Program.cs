using demoCRUD.Models;
using demoCRUD.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//here, connection string is getting configured
builder.Services.Configure<ConnectionSetting>(options =>
{
    options.MasterPGConnection = builder.Configuration["PostgresConnection"];
});
builder.Services.AddScoped<DAL>();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();