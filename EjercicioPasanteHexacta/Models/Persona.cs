using EjercicioPasanteHexacta.DTOS;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace EjercicioPasanteHexacta.Models;

    public class Persona
{
    [Key]
    public Guid PersonaId { get; set; } = Guid.NewGuid();

    [Required]
    [DisallowNull]
    [StringLength(100, ErrorMessage = "El nombre es demasiado largo")]
    public string Nombre { get; set; }

    [Required]
    [DisallowNull]
    [StringLength(100, ErrorMessage = "El apellido es demasiado largo")]
    public string Apellido{ get; set; }

    [Required]
    [DisallowNull]
    [Range(0,200)]
    public int Edad { get; set; }

    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public GrupoEtario GrupoEtario { get; set; }

    [Required]
    [DisallowNull]
    public EstadoCivil EstadoCivil { get; set; }

    public Persona(string nombre, string apellido, int edad, EstadoCivil estadoCivil)
    {
        Nombre = nombre;
        Apellido = apellido;
        Edad = edad;
        EstadoCivil = estadoCivil;
    }

    static public explicit operator Persona(PersonaDTO dto) => new Persona(dto.Nombre, dto.Apellido, dto.Edad, Enum.Parse<EstadoCivil>(dto.EstadoCivil));
}