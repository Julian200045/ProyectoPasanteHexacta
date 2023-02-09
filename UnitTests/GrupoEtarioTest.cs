using EjercicioPasanteHexacta.Models;
using EjercicioPasanteHexacta.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Assert = Xunit.Assert;

namespace EjercicioPasanteHexacta.UnitTests
{

    public class GrupoEtarioTest
    {

        [Fact]
        public void PersonasPertenecenAlGrupoEtarioCorrespondiente()
        {

            const string connectionString = "Data Source=InMemorySqLite;Mode=Memory;Cache=shared";
            var connection = new SqliteConnection(connectionString);
            connection.Open();

            var contextOptions = new DbContextOptionsBuilder<AppPersonasContext>().UseSqlite(connection).EnableSensitiveDataLogging().Options;

            AppPersonasContext context = new AppPersonasContext(contextOptions);

            context.Database.EnsureCreated();

            if(context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            List<Persona> personasInit = new List<Persona>
            {
                new Persona("Pepe", "Gonzales", 5, EstadoCivil.Soltero),
                new Persona("Pablo", "Gonzales", 15, EstadoCivil.Soltero),
                new Persona("Patricio", "Gonzales", 55, EstadoCivil.Soltero),
                new Persona("Pilar", "Gonzales", 95, EstadoCivil.Soltero)

            };

            context.Personas.AddRange(personasInit);

            context.SaveChanges();

            PersonaService serviceTest = new PersonaService(context);

            IEnumerable<Persona> personas = serviceTest.Get("", "Gonzales");

            Persona pepe = personas.First(p => p.Nombre == "Pepe");
            Persona pablo = personas.First(p => p.Nombre == "Pablo");
            Persona patricio = personas.First(p => p.Nombre == "Patricio");
            Persona pilar = personas.First(p => p.Nombre == "Pilar");

            Assert.Equal("Niños", pepe.GrupoEtario.Nombre);
            Assert.Equal("Adolescentes", pablo.GrupoEtario.Nombre);
            Assert.Equal("Adultos", patricio.GrupoEtario.Nombre);
            Assert.Equal("Octogenarios", pilar.GrupoEtario.Nombre);
        }
    }
}
