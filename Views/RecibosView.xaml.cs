using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using OngDonacionesWpf.Controllers;
using OngDonacionesWpf.Models;

namespace OngDonacionesWpf.Views
{
    public partial class RecibosView : UserControl
    {
        private readonly RecibosController _controller;

        public RecibosView()
        {
            InitializeComponent();
            _controller = new RecibosController();

            CargarCombos();
            CargarGrid();
            LimpiarFormulario();
        }

        private void CargarCombos()
        {
            List<Donacion> donaciones = _controller.ObtenerDonaciones();
            cbDonaciones.ItemsSource = donaciones;

            List<Empleado> empleados = _controller.ObtenerEmpleados();
            cbEmpleados.ItemsSource = empleados;
        }

        private void CargarGrid()
        {
            dgRecibos.ItemsSource = _controller.ObtenerRecibos();
        }

        private void LimpiarFormulario()
        {
            cbDonaciones.SelectedIndex = -1;
            cbEmpleados.SelectedIndex = -1;
            dpFecha.SelectedDate = DateTime.Today;
            txtCodigo.Text = string.Empty;
            dgRecibos.SelectedIndex = -1;
        }

        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbDonaciones.SelectedValue == null || cbEmpleados.SelectedValue == null)
                {
                    MessageBox.Show("Selecciona una donación y un empleado.");
                    return;
                }

                int idDonacion = (int)cbDonaciones.SelectedValue;
                int idEmpleado = (int)cbEmpleados.SelectedValue;
                DateTime fecha = dpFecha.SelectedDate ?? DateTime.Today;
                string codigo = txtCodigo.Text.Trim();

                Recibo nuevo = _controller.CrearRecibo(idDonacion, idEmpleado, fecha, codigo);

                MessageBox.Show($"Recibo creado con Id {nuevo.IdRecibo}.");
                CargarGrid();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el recibo: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgRecibos.SelectedItem is Recibo seleccionado)
            {
                if (MessageBox.Show($"¿Eliminar recibo {seleccionado.IdRecibo}?",
                    "Confirmar", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    try
                    {
                        _controller.EliminarRecibo(seleccionado.IdRecibo);
                        CargarGrid();
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un recibo en la tabla.");
            }
        }
    }
}
