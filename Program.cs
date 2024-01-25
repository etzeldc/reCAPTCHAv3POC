using reCAPTCHAv3POC;
using reCAPTCHAv3POC.Interfaces;
using reCAPTCHAv3POC.Services;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseIISIntegration();
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection(nameof(AppSettings)));

builder.Services.AddTransient<ISignupService, SignupService>();

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
//app.UseFileServer();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    app.MapRazorPages();
});

app.Run();
