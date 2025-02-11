using LubriSoft.Components;
using LubriSoft.Data;
using LubriSoft.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

//********** Blazor Bootstrap **********
builder.Services.AddBlazorBootstrap();

//********** Database Connection **********
builder.Services.AddDbContext<LubriSoftDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("LubriSoftDbConnection")));

//********** Custom Services **********
builder.Services.AddScoped<ILubriSoftServices, LubriSoftServices>();

//********** Web Host **********
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenAnyIP(5189); // HTTP
    options.ListenAnyIP(7192, listenOptions => listenOptions.UseHttps()); // HTTPS
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();