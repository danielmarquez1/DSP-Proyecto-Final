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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        

        private void btnLogin_Click(object sender, EventArgs e)
        {    // Si los campos estan vacio
            if (txtUser.Text == "" && txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese su usurio o  contraseña");
            }
            else
            {
                // Vericar la condiciones donde sera dirigi a la diferntes formularios
                switch(txtUser.Text)
                {
                    case "Bodega":
                        if(txtPassword.Text== "1234")
                        {
                            AdministradorDeBodega adm = new AdministradorDeBodega();
                            adm.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña incorrecto");
                        }

                        break;

                    case "Empleado":
                        if (txtPassword.Text == "1234")
                        {
                            EmpleadoDeBodega Emp = new EmpleadoDeBodega();
                            Emp.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña incorrecto");
                        }
                        break;

                    case "Administrador":
                        if(txtPassword.Text == "1234")
                        {
                            AdministradorDePrincipal master = new AdministradorDePrincipal();
                            master.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contraseña incorrecto");
                        }
                        break;

                    default:
                        MessageBox.Show("Usuario o Contraseña incorrecto");
                        break;
                        
                        

                }

             
            }
        }



        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
