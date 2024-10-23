using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dominio;
using Negocio;

namespace WinformAppDiscos
{
    public partial class frmDiscos : Form
    {

        //atributo
        List <Disco> listaDiscos = new List <Disco> ();
        public frmDiscos()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();
            cboCampo.Items.Add("Titulo");
            cboCampo.Items.Add("Genero");
            cboCampo.Items.Add("Cantidad de canciones");
            
        }

        //funcion para cargar la grilla
        public void cargar()
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                listaDiscos = negocio.listar();
                dgvDiscos.DataSource = listaDiscos; //cargo la grilla con los objetos de mi coleccion
                ocultarColumnas();
                cargarImagen(listaDiscos[0].UrlImagen);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ocultarColumnas()
        {
            dgvDiscos.Columns[0].Visible = false; // invisibilizo el ID 
            dgvDiscos.Columns[4].Visible = false; // idem EL STRING URL
        }

        //evento cambio de seleccion para que cambie la imagen cuando selecciono.
        private void dgvDiscos_SelectionChanged(object sender, EventArgs e)
        {
            if(dgvDiscos.CurrentRow != null)
            {
                Disco seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                cargarImagen(seleccionado.UrlImagen);
            }
        }

        //funcion generica para cargar una imagen y si no la encuentra tire una excepcion.
        private void cargarImagen(string imagen)
        {
            try
            {
                pbxImagen.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxImagen.Load("https://developers.elementor.com/docs/assets/img/elementor-placeholder-image.png");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAltaDisco alta = new frmAltaDisco();
            alta.ShowDialog();
            cargar();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Disco seleccionado;
            seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;

            frmAltaDisco modificar = new frmAltaDisco(seleccionado);
            modificar.ShowDialog();
            cargar();
        }

        private void btnEliminarFisico_Click(object sender, EventArgs e)
        {
            eliminar();
        }

        private void btnEliminarLogico_Click(object sender, EventArgs e)
        {
            eliminar(true);
        }

        private void eliminar(bool logico = false)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            Disco seleccionado;
            try
            {
                DialogResult respuesta = MessageBox.Show("De verdad queres eliminarlo?", "Eliminando registro..", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (respuesta == DialogResult.Yes)
                {
                    seleccionado = (Disco)dgvDiscos.CurrentRow.DataBoundItem;
                    
                    if (logico)
                        negocio.eliminarLogico(seleccionado.Id);
                    else
                        negocio.eliminarFisico(seleccionado.Id);

                    cargar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Disco> listaFiltrada;
            string filtro = txtFiltroRapido.Text;

            if (filtro.Length >= 3)
            {
                listaFiltrada = listaDiscos.FindAll(x => x.Titulo.ToUpper().Contains(filtro.ToUpper()) || x.Estilo.Descripcion.ToUpper().Contains(filtro.ToUpper()));
            }
            else
            {
                listaFiltrada = listaDiscos;
            }

            dgvDiscos.DataSource = null;
            dgvDiscos.DataSource = listaFiltrada;
            ocultarColumnas();
        }

        //VALIDACION BOTON FILTRAR
        private bool validarFiltro()
        {
            if (cboCampo.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un campo para continuar");
                return true;
            }
            if (cboCriterio.SelectedIndex < 0)
            {
                MessageBox.Show("Debes seleccionar un criterio para continuar");
                return true;
            }
            if (cboCampo.SelectedItem.ToString() == "Cantidad de canciones")
            {
                if (string.IsNullOrEmpty(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Debe cargar un numero para el filtro");
                    return true;
                }
                if (!(soloNumeros(txtFiltroAvanzado.Text)))
                {
                    MessageBox.Show("Debe cargar solo numeros");
                    return true;
                }
            }

            return false;
        }

        private bool soloNumeros(string cadena)
        {
            foreach (char caracter in cadena)
            {
                if (!(char.IsNumber(caracter)))
                    return false;
            }
            return true;
        }
       
        private void btnFiltro_Click(object sender, EventArgs e)
        {
            DiscosNegocio negocio = new DiscosNegocio();
            try
            {
                //si valida, vuelve atras, sino continua con el evento..
                if (validarFiltro())
                    return;

                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvDiscos.DataSource = negocio.filtrar(campo, criterio, filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Cantidad de canciones")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");

            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
    }
}
