using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder
    .Services
    .AddControllersWithViews()
    .AddRazorRuntimeCompilation()
    .AddMvcLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

//Multilanguage:
builder.Services.Configure<RequestLocalizationOptions>(opt =>
{
    var supportedCultures = new[] { "tr-TR", "en-US", "es-ES" };
    opt.SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
});

builder.Services.AddBaseServices();

var app = builder.Build();

//Multilanguage:
var supportedCultures = new[] { "tr-TR", "en-US", "es-ES" };
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);
app.UseRequestLocalization(localizationOptions);

//app.AddAccessKeyCheckMiddlewares();
app.AddExceptionCenter();
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
