using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Portfolio.Business.AutoMappers;
using Portfolio.Business.Services;
using Portfolio.Business.Settings;
using Portfolio.Data.Context;
using Portfolio.Data.Repositories;
using Portfolio.Domain.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(PersonalInfoMapper));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

/*******************************/
var connectionString = builder.Configuration.GetConnectionString("DefualtConnection");
builder.Services.AddDbContext<PortfolioDBContext>(option => option.UseSqlServer(connectionString));



builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                 .AddEntityFrameworkStores<PortfolioDBContext>();


builder.Services.ConfigureApplicationCookie(options =>
{

    options.LoginPath = "/Dashboard/Auth/Login";
    options.AccessDeniedPath = "/Dashboard/Auth/AccessDenied";
    options.Cookie.HttpOnly = true;

});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


/******* Register servicess   *****/
builder.Services.AddScoped<IAuth, AuthService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPersonalInfo, PersonalInfoService>();
builder.Services.AddScoped<IFileManager, FileMangerService>();
builder.Services.AddScoped<IAchievement, AchievementService>();
builder.Services.AddScoped<IAchievedFor, AchievedForService>();
builder.Services.AddScoped<ICompany, CompanyService>();
builder.Services.AddScoped<ICustomer, CustomerService>();
builder.Services.AddScoped<IEducation, EducationService>();
builder.Services.AddScoped<ISkill, SkillService>();
builder.Services.AddScoped<ISocialMedia, SocialService>();
builder.Services.AddScoped<ITool, ToolService>();
builder.Services.AddScoped<IService, ServiceService>();
builder.Services.AddScoped<IMail, MailServices>();

/*******************************/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseSession();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.MapStaticAssets();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
name: "areas",
pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.MapControllerRoute(
        name: "default",
        pattern: "{area=VisitorUI}/{controller=Home}/{action=Index}/{id?}");

app.Run();
