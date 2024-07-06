namespace Programador.API.Dtos;

public record class ActualizarProgramadorDto(
    string Nombre,
    string Apellido,
    string Especialidad,
    int AñosExperiencia,
    string Rango
);
