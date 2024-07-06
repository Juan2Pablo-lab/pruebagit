namespace Programador.API.Dtos;

public record class ProgramadorDto(
    int Id,
    string Nombre,
    string Apellido,
    string Especialidad,
    int AñosExperiencia,
    string Rango
);
