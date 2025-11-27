using System;

namespace OngDonacionesWpf.Models
{
    // Tabla: Recibos
    public class Recibo
    {
        // Id_Recibo INT PRIMARY KEY
        public int IdRecibo { get; set; }

        // Id_Donacion INT NOT NULL (FK a Donaciones)
        public int IdDonacion { get; set; }

        // Id_Empleados INT NOT NULL (FK a Empleados)
        public int IdEmpleados { get; set; }

        // Fecha DATETIME NOT NULL (DEFAULT GETDATE())
        public DateTime Fecha { get; set; }

        // Codigo_Recibo VARCHAR(50) UNIQUE NOT NULL
        public string CodigoRecibo { get; set; } = string.Empty;
    }
}
