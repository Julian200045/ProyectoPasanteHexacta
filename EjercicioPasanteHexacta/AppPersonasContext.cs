using EjercicioPasanteHexacta.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EjercicioPasanteHexacta
{
    public class AppPersonasContext: DbContext
    {
        public virtual DbSet<Persona> Personas { get; set; }

        public AppPersonasContext(DbContextOptions<AppPersonasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            try
            {

                var converter = new ValueConverter<GrupoEtario, string>(grupo => grupo.Nombre, nombre => GrupoEtario.GruposEtarios.Find(grupo => grupo.Nombre == nombre)!= null? GrupoEtario.GruposEtarios.Find(grupo => grupo.Nombre == nombre) : new GrupoEtario("Otro",0,200));

                modelBuilder
                    .Entity<Persona>()
                    .Property(persona => persona.GrupoEtario)
                    .HasConversion(converter);

            }
            catch (Exception ex) {
                Console.WriteLine("El grupo etario no está determinado: ", ex.Message);
            }

            string query = String.Join("", GrupoEtario.GruposEtarios.Select(grupo => $"WHEN [Edad] BETWEEN {grupo.Min} AND {grupo.Max} THEN '{grupo.Nombre}' ").ToArray());

            modelBuilder.Entity<Persona>()
                .Property(p => p.GrupoEtario)
                .HasComputedColumnSql("CASE " + query + "ELSE 'Otro' END", stored: true);

            List<Persona> personasInit = new List<Persona>
            {
                new Persona("Julian", "Carretto", 22, EstadoCivil.Soltero),
                new Persona("Camila", "Carretto", 24, EstadoCivil.Soltero),
                new Persona("Valeria", "Chanquia", 22, EstadoCivil.Soltero),
                new Persona("Pepe", "Argento", 8, EstadoCivil.Soltero),
                new Persona("Claudio", "Chavez", 12, EstadoCivil.Soltero),
                new Persona("Jorge", "Perez", 80, EstadoCivil.Soltero)
            };

            modelBuilder.Entity<Persona>(persona =>
            {
                persona.HasData(personasInit);
            });
        }

    }
}
