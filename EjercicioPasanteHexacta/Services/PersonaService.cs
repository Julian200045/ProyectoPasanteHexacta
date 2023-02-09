using EjercicioPasanteHexacta.Models;
using System.Runtime.CompilerServices;

namespace EjercicioPasanteHexacta.Services
{
    public class PersonaService: IPersonaService
    {
        AppPersonasContext context;

        public PersonaService(AppPersonasContext dbcontext)
        {
            context = dbcontext;
        }

        public IEnumerable<Persona> Get(string nombre, string apellido)
        {
            return context.Personas.Where(persona => persona.Nombre.Contains(nombre) && persona.Apellido.Contains(apellido));
        }

        public void Save(Persona persona)
        {
            context.Add(persona);
            context.SaveChanges(); //lo correcto sería await context.SaveChangesAsync(); pero surgieron problemas al realizar varias requests 
        }
    }

    public interface IPersonaService
    {
        IEnumerable<Persona> Get(string nombre, string apellido);

        void Save(Persona persona);
    }
}

