namespace OngDonacionesWpf.Models
{
    // Tabla: TiposDonante
    public class TipoDonante
    {
        // Id_TipoDonante INT PRIMARY KEY
        public int IdTipoDonante { get; set; }

        // TipoDonante VARCHAR(50) NOT NULL
        public string NombreTipo { get; set; } = string.Empty;
    }
}
