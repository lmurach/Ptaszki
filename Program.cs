using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BirdGame.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BirdDbContextConnection") ?? throw new InvalidOperationException("Connection string 'BirdDbContextConnection' not found.");

builder.Services.AddDbContext<BirdDbContext>(options => options.UseSqlite(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<BirdDbContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();

// ADD CONTROLLERS TO SUPPORT AJAX / RESTFUL API
builder.Services.AddControllers();

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

// ADD CONTROLLERS TO SUPPORT AJAX / RESTFUL API
app.MapControllers();

app.Run();
