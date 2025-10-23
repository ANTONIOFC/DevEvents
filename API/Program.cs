using System.Reflection;
using API.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// uso em memória
//builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseInMemoryDatabase("DevEventsDb"));

// uso com banco de dados SQL Server
var connectionString = builder.Configuration.GetConnectionString("DevEventsCs");

builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseSqlServer(connectionString));

//builder.Services.AddAutoMapper(typeof(DevEventProfile));

//var autoMapperKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Ik15VGVzdFVzZXIiLCJzdWIiOiJNeVRlc3RVc2VyIiwianRpIjoiYTYxMmJlMTQiLCJzY29wZSI6Im15YXBpOnNlY3JldHMiLCJhdWQiOlsiaHR0cDovL2xvY2FsaG9zdDo1MjU0IiwiaHR0cHM6Ly9sb2NhbGhvc3Q6NzEyMiJdLCJuYmYiOjE3NTcwNzY4NzgsImV4cCI6MTc2NDkzOTI3OCwiaWF0IjoxNzU3MDc2ODc5LCJpc3MiOiJkb3RuZXQtdXNlci1qd3RzIn0.u1DVl4lLGZZJ21DuAIDnZIe3BX79-Pav7XAGukrqie8";
//builder.Services.AddAutoMapper(cfg => cfg.LicenseKey = autoMapperKey, typeof(DevEventProfile));

builder.Services.AddControllers();

// old way
//builder.Services.AddSwaggerGen();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSwaggerGen(g =>
{
    g.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "DevEvents.API",
        Version = "v1",
        Description = "API de DevEvents",
        Contact = new OpenApiContact()
        {
            Name = "Antônio Costa",
            Email = "antonifc@gmail.com",
            Url = new Uri("http://linkedin/antoniofcfilho")
        }
    });

    //var xmlFile = "DevEvents.API.xml";
    // var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    g.IncludeXmlComments(xmlPath); 
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.MapOpenApi();
    // old way
    //app.UseSwaggerUI();
    app.UseSwaggerUI(options =>
    {
        //options.SwaggerEndpoint("/openapi/v1.json", "API | v1");
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        options.RoutePrefix = string.Empty;
        //options.Swea
    });

    app.UseReDoc(options =>
    {
        options.SpecUrl("/openapi/v1.json");
    });

    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
