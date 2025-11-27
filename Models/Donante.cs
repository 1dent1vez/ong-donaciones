namespace OngDonacionesWpf.Models
{
    // Tabla: Donantes
    public class Donante
    {
        // Id_Donante INT PRIMARY KEY
        public int IdDonante { get; set; }

        // Nombre VARCHAR(100) NOT NULL
        public string Nombre { get; set; } = string.Empty;

        // Email VARCHAR(100) NULL
        public string Email { get; set; }

        // Telefono VARCHAR(20) NULL
        public string Telefono { get; set; }

        // Id_TipoDonante INT NOT NULL (FK a TiposDonante)
        public int IdTipoDonante { get; set; }
    }
}
