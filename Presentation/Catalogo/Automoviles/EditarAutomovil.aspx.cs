using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BussinesLogic;
using Entities;

namespace Presentation.Catalogo.Automoviles
{
    public partial class EditarAutomovil : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Response.Redirect("ListaAutomoviles.aspx");
                }
                else
                {
                    var idAutomovil = Request.QueryString["Id"].ToString();
                    var automovil = BLLAutomovil.ConsultarAutomovilPorId(idAutomovil);
                    CargarFormulario(automovil);
                    var disponibilidad = (bool)automovil.Disponibilidad;
                    lblAutomovil.ForeColor = disponibilidad ? Color.Green: Color.Red;
                    btnEliminar.Visible = disponibilidad;
                }
            }
        }

        private void CargarFormulario(VOAutomovil automovil)
        {
            lblAutomovil.Text = automovil.IdAutomovil.ToString();
            txtMatricula.Text = automovil.Matricula;
            txtModelo.Text = automovil.Modelo;
            txtMarca.Text = automovil.Marca;
            txtCuota.Text = automovil.Cuota.ToString();
            lblUrlFoto.InnerText = automovil.UrlFoto;
            imgFotoAutomovil.ImageUrl = automovil.UrlFoto;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                var automovil = new VOAutomovil
                {
                    IdAutomovil = int.Parse(lblAutomovil.Text),
                    Matricula = txtMatricula.Text,
                    Modelo = txtModelo.Text,
                    Marca = txtMarca.Text,
                    Cuota = double.Parse(txtCuota.Text),
                    UrlFoto = lblUrlFoto.InnerText,
                    Disponibilidad = true
                };
                BLLAutomovil.ActualizarAutomovil(automovil);
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
            if (SubirImagen.Value.Length > 0)
            {
                var fileName = Path.GetFileName(SubirImagen.PostedFile.FileName);
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
                SubirImagen.PostedFile.SaveAs(path + fileName);
                var url = "/Imagenes/Automoviles/" + fileName;
                lblUrlFoto.InnerText = url;
                imgFotoAutomovil.ImageUrl = url;
                btnGuardar.Visible = true;
            }
        }

        private void LimpiarFormulario()
        {
            lblAutomovil.Text = string.Empty;
            txtMatricula.Text = string.Empty;
            txtModelo.Text = string.Empty;
            txtMarca.Text = string.Empty;
            txtCuota.Text = string.Empty;
            lblUrlFoto.InnerText = string.Empty;
            imgFotoAutomovil.ImageUrl = string.Empty;
            btnGuardar.Visible = false;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var idAuto = lblAutomovil.Text;
                var autoEliminado = BLLAutomovil.EliminarAutomovil(idAuto);
                LimpiarFormulario();
                Response.Redirect("ListaAutomoviles.aspx");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterClientScriptBlock(this, GetType(), $"Mensaje de error",
                    "alert(Se registró un error al realizar la operación " + ex.Message + ");", true);
            }
        }
    }
}