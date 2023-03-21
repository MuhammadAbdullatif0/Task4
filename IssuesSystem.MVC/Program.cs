using IssuesSystem.BL;
using IssuesSystem.BL.Managers;
using IssuesSystem.DAL;
using IssuesSystem.DAL.Repositories.Repos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("tickets");
builder.Services.AddDbContext<IssuesContext>(options
    => options.UseSqlServer(connectionString));

builder.Services.AddScoped<ITicketsRepo, TicketsRepo>();
builder.Services.AddScoped<ITicketManagers, TicketsManager>();
builder.Services.AddScoped<IDeptRepo, DeptRepo>();
builder.Services.AddScoped<IDevRepo, DevRepo>();
builder.Services.AddScoped<IDeptManagers, DeptManagers>();
builder.Services.AddScoped<IDevManagers, DevManagers>();

//builder.Services.AddTransient<ITicketsRepo, TicketsRepo>();
//builder.Services.AddSingleton<ITicketsRepo, TicketsRepo>();

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
