namespace EjercicioPasanteHexacta.Models;

public class GrupoEtario
{
    public string Nombre { get; set; }
    public int Min { get; set; }//Incluido
    public int Max { get; set; }//Incluido

    static public List<GrupoEtario> GruposEtarios = new List<GrupoEtario>()
    {
        new GrupoEtario("Niños", 0, 10),
        new GrupoEtario("Adolescentes", 11, 17),
        new GrupoEtario("Adultos", 18, 79),
        new GrupoEtario("Octogenarios", 80, 200)
    };

    public GrupoEtario(string nombre, int min, int max) {
        this.Nombre = nombre;
        this.Min = min;
        this.Max = max;
    
    }

}