using Programador.API.Dtos;

namespace Programador.API.EndPoints;

public static class ProgramadorEndpoints
{
    const string ProgramadorEndPointName = "GetProgramador";
    private static readonly List<ProgramadorDto> programadores = [
        new(
            1,
            "Satoru",
            "Gojo",
            "Ciencia de Datos",
            15,
            "Senior"
        ),
        new(
            2,
            "Yuta",
            "Okkotsu",
            "Desarrollador Full Stack",
            7,
            "Semi Senior"
        ),
        new(
            3,
            "Suguro",
            "Geto",
            "Desarrollador Back-end",
            18,
            "Senior"
        )
    ];

    public static RouteGroupBuilder MapProgramersEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("programadores")
                        .WithParameterValidation();
        //GET /programadores
        group.MapGet("/", () => programadores);
        //GET /programadores/n
        group.MapGet("/{id}", (int id) => 
        {
            ProgramadorDto? programador = programadores.Find(programador => programador.Id == id);
            return programador is null ? Results.NotFound() : Results.Ok(programador);
        })
        .WithName(ProgramadorEndPointName);
        //POST /programadores
        group.MapPost("/", (CrearProgramadorDto nuevo) => 
        {
            ProgramadorDto programador = new(
                programadores.Count + 1,
                nuevo.Nombre,
                nuevo.Apellido,
                nuevo.Especialidad,
                nuevo.AñosExperiencia,
                nuevo.Rango
            );
            programadores.Add(programador);
            return Results.CreatedAtRoute(ProgramadorEndPointName, new {id = programador.Id}, programador);
        });
        //PUT /programadores/n
        group.MapPut("/{id}", (int id, ActualizarProgramadorDto nuevo) => 
        {
            var index = programadores.FindIndex(programador => programador.Id == id);
            if(index == -1)
            {
                return Results.NotFound();
            }
            programadores[index] = new(
                id,
                nuevo.Nombre,
                nuevo.Apellido,
                nuevo.Especialidad,
                nuevo.AñosExperiencia,
                nuevo.Rango
            );
            return Results.NoContent();
        });
        //DELETE /programador/n
        group.MapDelete("/{id}", (int id) => 
        {
            programadores.RemoveAll(programador => programador.Id == id);
            return Results.NoContent();
        });


        
        return group;
    }
}
