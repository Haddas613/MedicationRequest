using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PatientMedicationApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "1.0.0",
        Title = "Biopharmaceutical & Healthcare API",
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
});
builder.Services.AddControllers()
    .AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });
builder.Services.AddControllers();

builder.Services.AddDbContext<PatientContext>(opt =>
    opt.UseInMemoryDatabase("PatientsList"));
builder.Services.AddDbContext<ClinicianContext>(opt =>
    opt.UseInMemoryDatabase("CliniciansList"));
builder.Services.AddDbContext<MedicationContext>(opt =>
    opt.UseInMemoryDatabase("MedicationsList"));
builder.Services.AddDbContext<MedicationRequestContext>(opt =>
    opt.UseInMemoryDatabase("MedicationRequestsList"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
