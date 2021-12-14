using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLogic;
using Entities;

namespace Presentation.Catalogo.Automoviles
{
    public partial class AltaAutomovil : Page
    {
        protected void Page_Load(object sender, EventArgs e) { }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                VOAutomovil automovil = new VOAutomovil
                {
                    Matricula = txtMatricula.Text,
                    Modelo = txtModelo.Text,
                    Marca = txtMarca.Text,
                    Cuota = double.Parse(txtCuota.Text),
                    UrlFoto = lblUrlFoto.InnerText,
                };
                BLLAutomovil.InsertarAutomovil(automovil);
                LimpiarFormulario();
                Response.Redirect("ListaAutomoviles.aspx");
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
                var path = Server.MapPath("~/Imagenes/Automoviles/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                subirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Automoviles/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoAutomovil.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            txtMatricula.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtCuota.Text = string.Empty;
            lblUrlFoto.InnerText = string.Empty;
            imgFotoAutomovil.ImageUrl = string.Empty;
            btnGuardar.Visible = false;
        }
    }
}