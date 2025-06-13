using supply.Models;
using supply.Models.Repositorie;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

////////////// DB
IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseSqlServer(config.GetConnectionString("sqlconnect"));
});

builder.Services.AddScoped<IRepositorie<Supplier>, dbSupplierRepos>();
builder.Services.AddScoped<IRepositorie<Sale>, dbSaleRepos>();
builder.Services.AddScoped<IRepositorie<Product>, dbProductRepos>();
builder.Services.AddScoped<IRepositorie<InvoiceItem>, dbInvoiceItemRepos>();
builder.Services.AddScoped<IRepositorie<Employee>, dbEmployeeRepos>();
builder.Services.AddScoped<IRepositorie<Customer>, dbCustomerRepos>();
builder.Services.AddScoped<IRepositorie<Category>, dbCategoryRepos>();




////////////////



var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=InvoiceItem}/{action=Index}/{id?}");

app.Run();
