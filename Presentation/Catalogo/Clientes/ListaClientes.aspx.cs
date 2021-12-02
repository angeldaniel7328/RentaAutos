using BussinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.Catalogo.Clientes
{
    public partial class ListaClientes : System.Web.UI.Page
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
            gvClientes.DataSource = BLLCliente.ConsultarClientes();
            gvClientes.DataBind();
        }

        protected void gvClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                var index = int.Parse(e.CommandArgument.ToString());
                var idCliente = gvClientes.DataKeys[index].Values["IdCliente"].ToString();
                Response.Redirect("EditarCliente.aspx?id=" + idCliente);
            }
        }
    }
}