using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using Microsoft.Extensions.DependencyInjection;
using API_pc.Data;
using API_pc.integration;


var builder = WebApplication.CreateBuilder(args);
//conexion base de datos - configuracionDBcontext
var connectionstring = builder.Configuration.GetConnectionString("PostgresSQLConnection");
builder.Services.AddDbContext<ApplicationDbContext>(
options => options.UseNpgsql(connectionstring));

//servicios url externa
builder.Services.AddScoped<listarUsuario, listarUsuario>();
builder.Services.AddScoped<mostrarUsuario, mostrarUsuario>();
builder.Services.AddScoped<crearUsuario, crearUsuario>();

//Servicios de Apis
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
   
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
