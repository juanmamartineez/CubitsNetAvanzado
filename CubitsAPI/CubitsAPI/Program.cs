using CubitsApplication;
using CubitsInfrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(x => x.AddPolicy("Default",y => { y.AllowAnyOrigin()
                                                            .AllowAnyHeader()
                                                            .AllowAnyMethod(); }));

var connectionString = builder.Configuration.GetConnectionString("Default");

builder.Services.InstallApplication();
builder.Services.InstallRepositories(connectionString); 

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.UseCors("Default");

app.MapControllers();

app.Run();