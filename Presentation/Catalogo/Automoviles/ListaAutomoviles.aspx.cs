using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLogic;
using Entities;

namespace Presentation.Catalogo.Automoviles
{
    public partial class ListaAutomoviles : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            gvAutomoviles.DataSource = BLLAutomovil.ConsultarAutomoviles(null);
            gvAutomoviles.DataBind();
        }

        protected void gvAutomoviles_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var index = int.Parse(e.CommandArgument.ToString());
                var idAutomovil = gvAutomoviles.DataKeys[index].Values["IdAutomovil"].ToString();
                Response.Redirect("EditarAutomovil.aspx?id=" + idAutomovil);
            }
        }
    }
}