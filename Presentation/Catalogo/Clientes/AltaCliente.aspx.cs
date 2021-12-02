using BussinesLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.Catalogo.Clientes
{
    public partial class AltaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOCliente cliente = new VOCliente
                {
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    UrlFoto = lblUrlFoto.InnerText,
                };
                BLLCliente.InsertarCliente(cliente);
                LimpiarFormulario();
                Response.Redirect("ListaClientes.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        protected void btnSubirImagen_Click(object sender, EventArgs e)
        {
            if (subirImagen.Value.Length > 0)
            {
                var fileName = Path.GetFileName(subirImagen.PostedFile.FileName);
                var extension = Path.GetExtension(fileName).ToLower();
                if (extension != ".jpg" && extension != ".png")
                {
                    lblUrlFoto.InnerText = "Archivo no valido";
                    return;
                }
                var path = Server.MapPath("~/Imagenes/Clientes/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                subirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Clientes/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoCliente.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            txtNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            lblUrlFoto.InnerText = string.Empty;
            imgFotoCliente.ImageUrl = string.Empty;
            btnGuardar.Visible = true;
        }
    }
}