using System.ComponentModel.DataAnnotations;

namespace Programador.API.Dtos;

public record class CrearProgramadorDto(
    [Required][StringLength(50)] string Nombre,
    [Required][StringLength(50)] string Apellido,
    [Required][StringLength(20)] string Especialidad,
    [Range(1, 50)] int AñosExperiencia,
    [Required][StringLength(15)] string Rango
    
);
