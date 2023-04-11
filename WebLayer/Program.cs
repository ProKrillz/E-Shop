using DataLayer;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.I_R;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var config = builder.Configuration;
builder.Services.AddDbContext<EfCoreContext>(o => o.UseSqlServer(config.GetConnectionString("SqlConnectionString")));

builder.Services.AddScoped<IUser, RepositoryUser>();
builder.Services.AddScoped<IProduct, RepositoryProduct>();
builder.Services.AddScoped<IOrdre, RepositoryOrdre>();
builder.Services.AddSession(option => { option.IdleTimeout = TimeSpan.FromMinutes(30); });

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
app.UseSession();
app.MapRazorPages();

app.Run();
