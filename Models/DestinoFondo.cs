namespace OngDonacionesWpf.Models
{
    // Tabla: DestinoFondos
    public class DestinoFondo
    {
        // Id_Destino INT PRIMARY KEY
        public int IdDestino { get; set; }

        // Id_Donacion INT NOT NULL (FK a Donaciones)
        public int IdDonacion { get; set; }

        // Id_Proyecto INT NOT NULL (FK a Proyectos)
        public int IdProyecto { get; set; }

        // MontoAsignado DECIMAL(18,2) NOT NULL
        public decimal MontoAsignado { get; set; }
    }
}
