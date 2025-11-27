using System;

namespace OngDonacionesWpf.Models
{
    // Tabla: Donaciones
    public class Donacion
    {
        // Id_Donacion INT PRIMARY KEY
        public int IdDonacion { get; set; }

        // Fecha DATETIME NOT NULL (DEFAULT GETDATE())
        public DateTime Fecha { get; set; }

        // Id_Donante INT NOT NULL (FK a Donantes)
        public int IdDonante { get; set; }

        // Id_MetodoPago INT NOT NULL (FK a MetodosPago)
        public int IdMetodoPago { get; set; }

        // Monto DECIMAL(18,2) NOT NULL
        public decimal Monto { get; set; }
    }
}
