using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLogic;
using Entities;

namespace Presentation.Rentas
{
    public partial class AltaRenta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();
        }

        private void CargarGrid()
        {
            var clientes = BLLCliente.ConsultarClientes();
            clientes.ForEach(cliente => ddlCliente.Items.Add(new ListItem(cliente.Nombre, cliente.IdCliente.ToString())));

            var automoviles = BLLAutomovil.ConsultarAutomoviles(true);
            automoviles.ForEach(auto => ddlAutomovil.Items.Add(new ListItem(auto.Marca + " " + auto.Modelo + " " + auto.Matricula, auto.IdAutomovil.ToString())));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var automovil = BLLAutomovil.ConsultarAutomovilPorId(ddlAutomovil.SelectedValue);
                var fechaRenta = DateTime.Parse(FechaRenta.Value.ToString());
                var fechaDevolucion = DateTime.Parse(FechaDevolucion.Value.ToString());
                var diferencia = (fechaDevolucion - fechaRenta).Days;
                var renta = new VORenta
                {
                    FechaHora = fechaRenta,
                    Plazo = diferencia,
                    CuotaTotal = double.Parse(txtCuota.Text),
                    IdAutomovil = int.Parse(ddlAutomovil.SelectedValue),
                    IdCliente = int.Parse(ddlCliente.SelectedValue)
                };
                BLLRenta.InsertarRenta(renta);
                LimpiarFormulario();
                Response.Redirect("AutomovilesRentados.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        private void LimpiarFormulario()
        {
            FechaRenta.Value = string.Empty;
            FechaDevolucion.Value = string.Empty;
            ddlCliente.SelectedIndex = 0;
            ddlAutomovil.SelectedIndex = 0;
            btnGuardar.Visible = false;
        }

        protected void ddlAutomovil_SelectedIndexChanged(object sender, EventArgs e)
        {
            var automovil = BLLAutomovil.ConsultarAutomovilPorId(ddlAutomovil.SelectedValue);
            var fechaRenta = DateTime.Parse(FechaRenta.Value.ToString());
            var fechaDevolucion = DateTime.Parse(FechaDevolucion.Value.ToString());
            var diferencia = (fechaDevolucion - fechaRenta).Days;
            txtCuota.Text = (diferencia * automovil.Cuota).ToString();
            btnGuardar.Visible = true;
        }
    }
}