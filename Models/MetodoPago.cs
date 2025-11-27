namespace OngDonacionesWpf.Models
{
    // Tabla: MetodosPago
    public class MetodoPago
    {
        // Id_MetodoPago INT PRIMARY KEY
        public int IdMetodoPago { get; set; }

        // Metodo VARCHAR(50) NOT NULL
        public string NombreMetodo { get; set; } = string.Empty;
    }
}
