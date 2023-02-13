using Castle.Components.DictionaryAdapter;
using Microsoft.EntityFrameworkCore;
using Register.Application.Service.SQLServerServices;
using Register.Domain.Contracts.Repositories;
using Register.Domain.Contracts.Services;
using Register.Infra.Data.Repository.Context;
using Register.Infra.Data.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Context SQL Server
var connectionStringUser = builder.Configuration.GetConnectionString("SQLServerConnection");
builder.Services.AddDbContext<SQLServerContext>
    (options => options.UseSqlServer(connectionStringUser));

//Repositories
builder.Services.AddScoped<IConditionRepository, ConditionRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAddressRepository, AddressRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


//Services
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IConditionService, ConditionService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<ISpecialtyService, SpecialtyService>();
builder.Services.AddScoped<IUserService, UserService>();

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
