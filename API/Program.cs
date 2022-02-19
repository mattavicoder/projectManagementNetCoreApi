
using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.SeedData;
using AutoMapper;
using Application.AutoMapper;
using FluentValidation.AspNetCore;
using Application.Project;
using API.MiddleWare;
using Domain;
using Microsoft.AspNetCore.Identity;
using API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
})
.AddFluentValidation((config) =>
{
    config.RegisterValidatorsFromAssemblyContaining<ProjectValidator>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseSqlite(connectionString: builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(Application.Project.List.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
builder.Services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<DataContext>()
            .AddSignInManager<SignInManager<AppUser>>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Super secret key")),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddScoped<TokenService>();

try
{
    var contextService = builder.Services.BuildServiceProvider().GetService<DataContext>();
    var userManager = builder.Services.BuildServiceProvider().GetService<UserManager<AppUser>>();
    await contextService!.Database.MigrateAsync();
    // await ActivitiesDataSeed.SetActivitesData(contextService);
    //await ProjectsDataSeed.SetProjectsDataSeed(contextService);
    await UserDataSeed.SetUserDataSeed(contextService, userManager);
}
catch (Exception ex)
{
    var logger = builder.Services.BuildServiceProvider().GetService<ILogger<Program>>();
    logger!.LogError(ex, "Error while setting up  migration");

}

//builder.Services

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleWare>();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
    builder.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod()
);

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
