using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;
using System.Configuration;

namespace WinformAppDiscos
{
    public partial class frmAltaDisco : Form
    {
        //CREO ATRIBUTO DISCO NULL PARA VALIDACION POSTERIOR
        private Disco disco = null;
        private OpenFileDialog archivo = null;

        public frmAltaDisco()
        {
            InitializeComponent();
        }
        //CONSTRUCTOR CON SOBRECARGA (MODIFICAR DISCO)
        public frmAltaDisco(Disco disco)
        {
            InitializeComponent();
            Text = "Modificar Disco";
            this.disco = disco;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Disco nuevo = new Disco();    YA NO LO NECESITO..
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                if (disco == null)
                {
                    disco = new Disco();
                }
                disco.Titulo = txtTitulo.Text;
                disco.FechaLanzamiento = dtpFecha.Value;
                disco.CantidadCanciones = int.Parse(txtCantidadCanciones.Text);
                disco.UrlImagen = txtUrlImagen.Text;
                disco.Estilo = (Estilo)cboEstilo.SelectedItem;
                disco.TipoEdicion = (TipoEdicion)cboTipoEdicion.SelectedItem;

                if (disco.Id != 0)
                {
                    negocio.modificarDisco(disco);
                    MessageBox.Show("Disco modificado exitosamente");
                }
                else
                {
                    negocio.agregarDisco(disco);
                    MessageBox.Show("Disco agregado exitosamente"); 
                }

                //Guardo la imagen si se levanto LOCALMENTE
                if (archivo != null && !(txtUrlImagen.Text.ToUpper().Contains("HTTP")))
                {
                    File.Copy(archivo.FileName, ConfigurationManager.AppSettings["Imagenes-Discos"] + archivo.SafeFileName);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }        

        //metodo para cargar comboBox
        public void cargarComboBox()
        {
            EstiloNegocio estiloNegocio = new EstiloNegocio();
            TipoEdicionNegocio tipoEdicionNegocio = new TipoEdicionNegocio();

            try
            {
                cboEstilo.DataSource = estiloNegocio.listar();
                cboEstilo.ValueMember = "Id";
                cboEstilo.DisplayMember = "Descripcion";
                cboTipoEdicion.DataSource = tipoEdicionNegocio.listar();
                cboTipoEdicion.ValueMember = "Id";
                cboTipoEdicion.DisplayMember = "Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //metodo para cargar la imagen
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxAltaImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxAltaImagen.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }
        private void frmAltaDisco_Load(object sender, EventArgs e)
        {
            cargarComboBox();
            if (disco != null)
            {
                txtTitulo.Text = disco.Titulo;
                dtpFecha.Value = disco.FechaLanzamiento;
                txtCantidadCanciones.Text = disco.CantidadCanciones.ToString();
                txtUrlImagen.Text = disco.UrlImagen;
                cargarImagen(disco.UrlImagen);
                cboEstilo.SelectedValue = disco.Estilo.Id;
                cboTipoEdicion.SelectedValue = disco.TipoEdicion.Id;
            }
        }

        private void txtUrlImagen_Leave(object sender, EventArgs e)
        {
            cargarImagen(txtUrlImagen.Text);
        }

        private void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            archivo = new OpenFileDialog();
            archivo.Filter = "JPG|*.jpg|JPEG|*.jpeg";
            if (archivo.ShowDialog() == DialogResult.OK)
            {
                txtUrlImagen.Text = archivo.FileName;
                cargarImagen(archivo.FileName);
            }
        }
    }
}
