using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheLastBugPrueba.IdentityServer;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("conexionString")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole>() // Utiliza la clase ApplicationUser personalizada
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();


builder.Services.AddIdentityServer()
    .AddAspNetIdentity<ApplicationUser>() // Utiliza la clase ApplicationUser personalizada
    .AddInMemoryIdentityResources(Config.GetIdentityResources())
    .AddInMemoryApiResources(Config.GetApiResources())
    .AddInMemoryClients(Config.GetClients())
    .AddDeveloperSigningCredential(); // Solo para desarrollo, para producción usa certificados reales

// Registro del servicio de autenticación
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();


// Resto de la configuración...

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configura la solicitud HTTP pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // Middleware de autenticación.
app.UseAuthorization();
app.UseIdentityServer(); // Middleware de IdentityServer.

app.MapControllers();

app.Run();

