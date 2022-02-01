
using Application.Activities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.SeedData;
using AutoMapper;
using Application.AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(opt => {
    opt.UseSqlite(connectionString: builder.Configuration.GetConnectionString("DefaultConnection")); 
});

builder.Services.AddMediatR(typeof(List.Handler).Assembly);
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
// builder.Services.AddCors(options => {
//     options.AddPolicy("RFCore", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
// });

try
{
    var contextService = builder.Services.BuildServiceProvider().GetService<DataContext>();
    await contextService!.Database.MigrateAsync();
    await ActivitiesDataSeed.SetActivitesData(contextService);
    await ProjectsDataSeed.SetProjectsDataSeed(contextService);
}
catch(Exception ex)
{
    var logger = builder.Services.BuildServiceProvider().GetService<ILogger<Program>>();
    logger!.LogError(ex, "Error while setting up  migration");

}

//builder.Services

var app = builder.Build();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
