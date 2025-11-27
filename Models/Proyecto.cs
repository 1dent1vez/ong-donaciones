namespace OngDonacionesWpf.Models
{
    // Tabla: Proyectos
    public class Proyecto
    {
        // Id_Proyecto INT PRIMARY KEY
        public int IdProyecto { get; set; }

        // Nombre_Proyecto VARCHAR(100) NOT NULL
        public string NombreProyecto { get; set; } = string.Empty;

        // Descripcion_Proyecto VARCHAR(255) NULL
        public string DescripcionProyecto { get; set; }

        // Monto_Requerido DECIMAL(18,2) NOT NULL
        public decimal MontoRequerido { get; set; }

        // Id_Area INT NOT NULL (FK a AreasFoco)
        public int IdArea { get; set; }
    }
}
