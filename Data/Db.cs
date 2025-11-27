using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using OngDonacionesWpf.Models;

namespace OngDonacionesWpf.Data
{
    public class Db
    {
        // -------- MODULO 5: RECIBOS --------

        public List<Recibo> ObtenerRecibos()
        {
            var lista = new List<Recibo>();

            using (var conn = DbConnectionFactory.Create())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT Id_Recibo, Id_Donacion, Id_Empleados, Fecha, Codigo_Recibo
                    FROM Recibos
                    ORDER BY Fecha DESC;
                ";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Recibo
                        {
                            IdRecibo = reader.GetInt32(reader.GetOrdinal("Id_Recibo")),
                            IdDonacion = reader.GetInt32(reader.GetOrdinal("Id_Donacion")),
                            IdEmpleados = reader.GetInt32(reader.GetOrdinal("Id_Empleados")),
                            Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            CodigoRecibo = reader.GetString(reader.GetOrdinal("Codigo_Recibo"))
                        });
                    }
                }
            }

            return lista;
        }

        public List<Empleado> ObtenerEmpleados()
        {
            var lista = new List<Empleado>();

            using (var conn = DbConnectionFactory.Create())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT Id_Empleados, Nombre, A_Paterno, A_Materno, Telefono, Email, Puesto
                    FROM Empleados
                    ORDER BY Nombre, A_Paterno;
                ";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Empleado
                        {
                            IdEmpleados = reader.GetInt32(reader.GetOrdinal("Id_Empleados")),
                            Nombre = reader.GetString(reader.GetOrdinal("Nombre")),
                            ApellidoPaterno = reader.GetString(reader.GetOrdinal("A_Paterno")),
                            ApellidoMaterno = reader.IsDBNull(reader.GetOrdinal("A_Materno"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("A_Materno")),
                            Telefono = reader.IsDBNull(reader.GetOrdinal("Telefono"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("Telefono")),
                            Email = reader.IsDBNull(reader.GetOrdinal("Email"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("Email")),
                            Puesto = reader.IsDBNull(reader.GetOrdinal("Puesto"))
                                ? null
                                : reader.GetString(reader.GetOrdinal("Puesto"))
                        });
                    }
                }
            }

            return lista;
        }

        public List<Donacion> ObtenerDonaciones()
        {
            var lista = new List<Donacion>();

            using (var conn = DbConnectionFactory.Create())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT Id_Donacion, Fecha, Id_Donante, Id_MetodoPago, Monto
                    FROM Donaciones
                    ORDER BY Fecha DESC;
                ";

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new Donacion
                        {
                            IdDonacion = reader.GetInt32(reader.GetOrdinal("Id_Donacion")),
                            Fecha = reader.GetDateTime(reader.GetOrdinal("Fecha")),
                            IdDonante = reader.GetInt32(reader.GetOrdinal("Id_Donante")),
                            IdMetodoPago = reader.GetInt32(reader.GetOrdinal("Id_MetodoPago")),
                            Monto = reader.GetDecimal(reader.GetOrdinal("Monto"))
                        });
                    }
                }
            }

            return lista;
        }

        public int InsertarRecibo(Recibo recibo)
        {
            using (var conn = DbConnectionFactory.Create())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO Recibos (Id_Donacion, Id_Empleados, Fecha, Codigo_Recibo)
                    VALUES (@IdDonacion, @IdEmpleados, @Fecha, @CodigoRecibo);
                    SELECT SCOPE_IDENTITY();
                ";

                cmd.Parameters.Add(new SqlParameter("@IdDonacion", SqlDbType.Int) { Value = recibo.IdDonacion });
                cmd.Parameters.Add(new SqlParameter("@IdEmpleados", SqlDbType.Int) { Value = recibo.IdEmpleados });
                cmd.Parameters.Add(new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = recibo.Fecha });
                cmd.Parameters.Add(new SqlParameter("@CodigoRecibo", SqlDbType.VarChar, 50) { Value = recibo.CodigoRecibo });

                conn.Open();
                var result = cmd.ExecuteScalar();
                return Convert.ToInt32(result);
            }
        }

        public void EliminarRecibo(int idRecibo)
        {
            using (var conn = DbConnectionFactory.Create())
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = @"DELETE FROM Recibos WHERE Id_Recibo = @IdRecibo;";
                cmd.Parameters.Add(new SqlParameter("@IdRecibo", SqlDbType.Int) { Value = idRecibo });

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
