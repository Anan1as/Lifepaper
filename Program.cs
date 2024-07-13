using Lifepaper.Data;
<<<<<<< HEAD
=======
using Lifepaper.Models;
using Lifepaper.Services;
>>>>>>> 139770b9df4fc21712bc8134c2084cdc23dc0faf
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

// Agregar configuración de SmtpSettings
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Agregar DbContext
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"), 
    new MySqlServerVersion(new Version(8, 0, 25))));

// Agregar servicios
builder.Services.AddScoped<EmailService>();
builder.Services.AddControllers();

// google Authentication Service
services.AddAuthentication().AddGoogle(googleOptions =>
{
    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
});


var app = builder.Build();

// Configurar middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
<<<<<<< HEAD

app.UseAuthentication();
=======
>>>>>>> 139770b9df4fc21712bc8134c2084cdc23dc0faf
app.UseAuthorization();

app.MapControllers();

app.Run();
