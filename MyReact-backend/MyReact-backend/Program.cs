using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyReact_backend.Context;
using MyReact_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(
	CookieAuthenticationDefaults.AuthenticationScheme)
	.AddCookie(option =>
	{
		option.LoginPath = "/Access/Login";
		option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
	});

builder.Services.AddCors(options =>
	options.AddPolicy("MyPolicy",
		builder => {
			builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
		}
	)
);


builder.Services.AddDbContext<MyReactContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString_myreactdb")
));

/* ------------ SERVICES ------------ */
builder.Services.AddTransient<ServiceEmployee>();
builder.Services.AddTransient<ServiceUser>();
builder.Services.AddTransient<ServiceLogin>();

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseCors("MyPolicy");

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
