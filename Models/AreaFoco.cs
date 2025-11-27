namespace OngDonacionesWpf.Models
{
    // Tabla: AreasFoco
    public class AreaFoco
    {
        // Id_Area INT PRIMARY KEY
        public int IdArea { get; set; }

        // Nombre_Area VARCHAR(100) NOT NULL
        public string NombreArea { get; set; } = string.Empty;
    }
}
