using EjercicioPasanteHexacta.Models;
using EjercicioPasanteHexacta.ViewModels;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EjercicioPasanteHexacta.DTOS
{
    public class PersonaDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public string EstadoCivil { get; set; }

        public PersonaDTO(string nombre, string apellido, int edad, string estadoCivil) {

            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
            EstadoCivil = estadoCivil;
        }

            
    }
}   
