using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_Catedra_DSP
{
    public partial class EmpleadoDeBodega : Form
    {
        public EmpleadoDeBodega()
        {
            InitializeComponent();
        }

        // Metodos Publicos

            public void BloqueoPestaña()// Bloque de pestañas 
        {
            ((Control)this.tabPage1).Enabled = true;//  habilita la pestaña del empleado
            ((Control)this.tabPage2).Enabled = false; // bloque de pestaña
            ((Control)this.dgvProductos).Enabled = false; // bloque de dgv
        }

        public void DirigirPestaña()
        {
            tbcEmpleado.SelectedIndex = 1; // dirige a pestaña de inventario
            ((Control)this.tabPage1).Enabled = false; // bloquea la pestaña
            ((Control)this.tabPage2).Enabled = true; // habilita la pestaña
        }


        public void Regresar()
        {
            tbcEmpleado.SelectedIndex = 0;// Regresa a la pestaña acutal
            ((Control)this.tabPage1).Enabled = true; // habilita la pestaña 
            ((Control)this.tabPage2).Enabled = false; // bloquea la pestaña
        }

        public void CerrarSesion()
        {
            Login RegrearLogin = new Login(); // Instancia del formulario del login
            RegrearLogin.Show(); //Dirigi al formulario del login
            this.Hide(); // Cerramos el formulario Actual
        }


        // Instancia de la clase de conexión Administrador Bodega
        ConexionAdministradorBodega sqlConexion = new ConexionAdministradorBodega();
        private void EmpleadoDeBodega_Load(object sender, EventArgs e)
        {
            BloqueoPestaña();
            // Mostrar los datos que trea a la base de datos de los productos
            dgvProductos.DataSource = sqlConexion.MostrarDatos(); // Llamaos al metodo de mostrar los productos
        }
        // Buscador Usuario
        private void txtBuscarDeProducto_TextChanged(object sender, EventArgs e)
        {
            // Tinene que ser disto a vacio           Si ingresa la información  se mostrara la dicha información que busca
            if (txtBuscarDeProducto.Text != "") dgvProductos.DataSource = sqlConexion.Buscar(txtBuscarDeProducto.Text);
            else dgvProductos.DataSource = sqlConexion.MostrarDatos(); // si no existe que no muestre nada que se mantega igual
        }

        private void btnInvnentario_Click(object sender, EventArgs e)
        {
            DirigirPestaña(); // Metodo a dirigir a la pestaña de inventario
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesion();// Metodo para dirigir al formulario de login
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Cerrar la aplicación
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            Regresar();// Regresar a la pestaña principal
        }
    }
}
