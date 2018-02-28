using Fidelitas.DO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fidelitas.UI
{
    public partial class frmMantenimiento : Form
    {
                #region Atributos
                private Persona persona;
                #endregion

        #region Eventos
        public frmMantenimiento()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarGrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPersona();
                BS.Mantenimiento.Instancia.Insertar(persona);
                mostrarGrid();
            }
            catch (Exception ee)
            {
                
                throw;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPersona();
                BS.Mantenimiento.Instancia.Actualizar(persona);
                mostrarGrid();
            }
            catch (Exception ee)
            {

                throw;
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                cargarPersona();
                BS.Mantenimiento.Instancia.Borrar(persona);
                mostrarGrid();
            }
            catch (Exception ee)
            {

                throw;
            }

        }

        private void dgvTabla_SelectionChanged(object sender, EventArgs e)
        {
            foreach( DataGridViewRow row in dgvTabla.SelectedRows ){
                int value1 = Convert.ToInt32(row.Cells[0].Value.ToString());
                string value2 = row.Cells[1].Value.ToString();
                bool value3 = Convert.ToBoolean(row.Cells[2].Value.ToString());
                DateTime value4 = Convert.ToDateTime(row.Cells[3].Value.ToString());
                int value5 = Convert.ToInt32(row.Cells[4].Value.ToString());
                string value6 = row.Cells[5].Value.ToString();

                txtCedula.Text = value1.ToString();
                txtNombre.Text = value2;
                cbMuerto.Checked = value3;
                dtpNacimiento.Value = value4;
                nudEdad.Value = value5;
                txtEmail.Text = value6;
               
            }
        }

        #endregion

        #region Metodos

        private void cargarPersona() {
            persona = new Persona();
           persona.ICedula = Convert.ToInt32(txtCedula.Text);
            persona.BMuerto = cbMuerto.Checked;
            persona.VNombre = txtNombre.Text;
            persona.DTNacimiento = dtpNacimiento.Value;
            persona.VEmail = txtEmail.Text;
            persona.IEdad = Convert.ToInt32(nudEdad.Value);
        }

        private void mostrarGrid() {
            try
            {
                dgvTabla.DataSource = BS.Mantenimiento.Instancia.Mostrar();
            }
            catch (Exception ee)
            {
                
                throw;
            }
        }
        #endregion






    }
}
