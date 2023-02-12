using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Register.Domain.Contracts.Repositories;
using Register.Domain.Contracts.Services;
using Register.Infra.Data.Repository.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context SQL Server
var connectionStringUser = builder.Configuration.GetConnectionString("SQLServerConnection");
builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(connectionStringUser));

//Repositories
builder.Services.AddScoped<IConditionRepository, IConditionRepository>();
builder.Services.AddScoped<IDoctorRepository, IDoctorRepository>();
builder.Services.AddScoped<IPatientRepository, IPatientRepository>();
builder.Services.AddScoped<IPersonRepository, IPersonRepository>();
//builder.Services.AddScoped<IReceptionistRepository, IReceptionistRepository>();
builder.Services.AddScoped<ISpecialtyRepository, ISpecialtyRepository>();


//Services
builder.Services.AddScoped<IConditionService, IConditionService>();

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
