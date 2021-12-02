using BussinesLogic;
using Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentation.Catalogo.Clientes
{
    public partial class EditarCliente : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListaClientes.aspx");
                }
                else
                {
                    string idCliente = Request.QueryString["Id"].ToString();
                    VOCliente cliente = BLLCliente.ConsultarClientePorId(idCliente);
                    CargarFormulario(cliente);
                    lblCliente.ForeColor = Color.Green;
                    btnEliminar.Visible = true;
                }
            }
        }

        private void CargarFormulario(VOCliente cliente)
        {
            lblCliente.Text = cliente.IdCliente.ToString();
            txtNombre.Text = cliente.Nombre.ToString();
            txtTelefono.Text = cliente.Telefono.ToString();
            txtDireccion.Text = cliente.Direccion.ToString();
            txtCorreo.Text = cliente.Correo.ToString();
            lblUrlFoto.InnerText = cliente.UrlFoto.ToString();
            imgFotoCliente.ImageUrl = cliente.UrlFoto;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                BLLCliente.EliminarCliente(lblCliente.Text);
                LimpiarFormulario();
                Response.Redirect("ListaClientes.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOCliente cliente = new VOCliente
                {
                    IdCliente = int.Parse(lblCliente.Text),
                    Nombre = txtNombre.Text,
                    Telefono = txtTelefono.Text,
                    Direccion = txtDireccion.Text,
                    Correo = txtCorreo.Text,
                    UrlFoto = lblUrlFoto.InnerText
                };
                BLLCliente.ActualizarCliente(cliente);
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
            if (SubirImagen.Value.Length > 0)
            {
                var fileName = Path.GetFileName(SubirImagen.PostedFile.FileName);
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
                SubirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Clientes/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoCliente.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            lblCliente.Text = string.Empty;
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