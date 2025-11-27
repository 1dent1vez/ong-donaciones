using System;
using System.Collections.Generic;
using OngDonacionesWpf.Data;
using OngDonacionesWpf.Models;

namespace OngDonacionesWpf.Controllers
{
    public class RecibosController
    {
        private readonly Db _db = new Db();

        public List<Recibo> ObtenerRecibos()
        {
            return _db.ObtenerRecibos();
        }

        public List<Empleado> ObtenerEmpleados()
        {
            return _db.ObtenerEmpleados();
        }

        public List<Donacion> ObtenerDonaciones()
        {
            return _db.ObtenerDonaciones();
        }

        public Recibo CrearRecibo(int idDonacion, int idEmpleado, DateTime fecha, string codigoRecibo)
        {
            if (string.IsNullOrWhiteSpace(codigoRecibo))
                throw new ArgumentException("El código de recibo es obligatorio.", nameof(codigoRecibo));

            var recibo = new Recibo
            {
                IdDonacion = idDonacion,
                IdEmpleados = idEmpleado,
                Fecha = fecha,
                CodigoRecibo = codigoRecibo
            };

            recibo.IdRecibo = _db.InsertarRecibo(recibo);
            return recibo;
        }

        public void EliminarRecibo(int idRecibo)
        {
            _db.EliminarRecibo(idRecibo);
        }
    }
}
