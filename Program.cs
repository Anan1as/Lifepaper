using Lifepaper.Data;
using Lifepaper.Models;
using Lifepaper.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Agregar configuración de SmtpSettings
builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("SmtpSettings"));

// Agregar DbContext
builder.Services.AddDbContext<BaseContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnection"),
    new MySqlServerVersion(new Version(8, 0, 25))));

// Agregar servicios
builder.Services.AddScoped<EmailService>();

// Agregar servicios de MVC, que incluyen ITempDataDictionaryFactory
builder.Services.AddControllersWithViews();

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
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=Index}/{id?}");

app.Run();
