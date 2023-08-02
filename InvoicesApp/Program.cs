using Domin.Entity;
using Domin.ViewModel;
using Infrastructure.Data;
using Infrastructure.IRepository.ServicesRepository;
using Infrastructure.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");
builder.Services.AddDbContext<InvoicesAppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddIdentity<AppUserModel, IdentityRole>().AddEntityFrameworkStores<InvoicesAppDbContext>();
builder.Services.AddScoped<IServicesInvoice<BayInvoiceViewModel>, ServicesInvoice>();
builder.Services.AddScoped<IServicesProduct<Product>, ServicesProduct>();
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
