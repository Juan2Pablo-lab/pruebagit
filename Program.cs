using Programador.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapGet("/", () => "Hola Programador!!");

app.MapProgramersEndpoints();


app.Run();
