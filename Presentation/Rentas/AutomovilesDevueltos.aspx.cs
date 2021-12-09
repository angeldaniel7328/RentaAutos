using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLogic;

namespace Presentation.Rentas
{
    public partial class AutomovilesDevueltos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CargarGrid();
        }

        private void CargarGrid()
        {
            var rentas = BLLRenta.ConsultarRentasExtendidas(true);
            gvRentas.DataSource = rentas;
            gvRentas.DataBind();
        }

        protected void gvRentas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var index = int.Parse(e.CommandArgument.ToString());
                var idRenta = gvRentas.DataKeys[index].Values["IdRenta"].ToString();
                Response.Redirect("DetalleRenta.aspx?Id=" + idRenta);
            }
        }
    }
}