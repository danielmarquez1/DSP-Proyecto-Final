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
    public partial class InicioDePrograma : Form
    {
        public InicioDePrograma()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            // Instanciamos  Login 
            Login Inicio = new Login();
            Inicio.Show(); //Dirigi al formulario del login
            this.Hide(); // Cerramos el formulario Actual
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // Salir de la aplicación.
        }

        private void InicioDePrograma_Load(object sender, EventArgs e)
        {
           

        }
    }
}
