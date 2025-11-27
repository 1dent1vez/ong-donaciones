namespace OngDonacionesWpf.Models
{
    // Tabla: Empleados
    public class Empleado
    {
        // Id_Empleados INT PRIMARY KEY
        public int IdEmpleados { get; set; }

        // Nombre VARCHAR(50) NOT NULL
        public string Nombre { get; set; } = string.Empty;

        // A_Paterno VARCHAR(50) NOT NULL
        public string ApellidoPaterno { get; set; } = string.Empty;

        // A_Materno VARCHAR(50) NULL
        public string? ApellidoMaterno { get; set; }

        // Telefono VARCHAR(20) NULL
        public string? Telefono { get; set; }

        // Email VARCHAR(100) NULL
        public string? Email { get; set; }

        // Puesto VARCHAR(50) NULL
        public string? Puesto { get; set; }
    }
}
