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
    public partial class DetalleRenta : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("AutomovilesRentados.aspx");
                }
                else
                {
                    var idRenta = Request.QueryString["Id"].ToString();
                    var renta = BLLRenta.ConsultarRentaExtendidaPorId(idRenta);
                    CargarFormulario(renta);
                }
            }
        }

        private void CargarFormulario(VORentaExtendida renta)
        {
            lblIdRenta.Text = renta.IdAutomovil.ToString();
            lblFechaHora.Text = renta.FechaHora.ToString();
            lblCuotaTotal.Text = renta.CuotaTotal.ToString();
            lblPlazo.Text = renta.Plazo.ToString() + " días";
            lblNombreCliente.Text = renta.NombreCliente;
            imgFotoCliente.ImageUrl = renta.UrlFotoCliente;
            lblAutomovil.Text = renta.NombreAutomovil;
            imgFotoAutomovil.ImageUrl = renta.UrlFotoAutomovil;
            if ((bool)!renta.Completada)
                btnDevolver.Visible = true;
        }

        protected void btnDevolver_Click(object sender, EventArgs e)
        {
            try
            {
                BLLRenta.DevolverAutomovil(lblIdRenta.Text);
                LimpiarFormulario();
                Response.Redirect("AutomovilesDevueltos.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        private void LimpiarFormulario()
        {
            lblIdRenta.Text = string.Empty;
            lblFechaHora.Text = string.Empty;
            lblCuotaTotal.Text = string.Empty;
            lblPlazo.Text = string.Empty;
            lblNombreCliente.Text = string.Empty;
            imgFotoCliente.ImageUrl = string.Empty;
            lblAutomovil.Text = string.Empty;
            imgFotoAutomovil.ImageUrl = string.Empty;
        }
    }
}