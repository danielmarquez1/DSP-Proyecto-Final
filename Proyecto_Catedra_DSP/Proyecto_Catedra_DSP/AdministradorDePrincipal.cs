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
    public partial class AdministradorDePrincipal : Form
    {
        public AdministradorDePrincipal()
        {
            InitializeComponent();
        }

        // Variables locales
        int dia, mes, año;
        string fechaNacimiento;

        // Instancia 
        conexionAdministradorPrincipal sqlConexion = new conexionAdministradorPrincipal(); // instancia de la clase de conexión AdministradorPrincipal
        Sucursal sqlConexionSucusal = new Sucursal(); // Instancia de la clase derivada de la conexión de administradorPrincipal 
        ValidacionesDeCampos Validar = new ValidacionesDeCampos(); // Instancia de la clase de validar los campos

        //Metodos Publicos
        public void Fecha() // Metodo para sacar la fecha de nacimiento del empleado
        {
            dia = dtpFechaNac.Value.Day; // Evalua el dia
            mes = dtpFechaNac.Value.Month; // Evalua mes
            año = dtpFechaNac.Value.Year; // Evalua Año
            fechaNacimiento = dia + "/" + mes + "/" + año; // Une la fachas
        }

        //Metodo para bloquear las pestañas
        public void BloqueoDePestaña()
        {
            ((Control)this.tabPage1).Enabled = true; // Habilita la pestaña  principal
            ((Control)this.tabPage2).Enabled = false; // bloquea la pestaña de ver los usuario
            ((Control)this.tabPage3).Enabled = false; // bloquea la pestaña de los socursales
            ((Control)this.txtID).Enabled = false; // Bloquea la caja de texto del id de los usuario
            ((Control)this.txtIDSucursal).Enabled = false; // Bloquea la caja de texto id sucursales
           
            
        }

        // Metodo para Dirigir a la pestaña ver usuario
        public void DirigirPestañasUser()
        {
            tbcFormularioAdm.SelectedIndex = 1; // dirige a la pestaña  para ver a los usuario
            ((Control)this.tabPage1).Enabled = false;// Bloquea la pestaña principal
            ((Control)this.tabPage2).Enabled = true; // habilita la pestaña de los usuario

        }

        //Metodo para Dirigir a la pestañas de ver Sucursales
        public void DirigirPestañaSucursales()
        {
            tbcFormularioAdm.SelectedIndex = 2;// Dirigi a la pestaña  de los sucursales
            ((Control)this.tabPage1).Enabled = false; //bloqua la pestaña principal 
            ((Control)this.tabPage3).Enabled = true; // habilita la pestaña de la sucursales
        }

        // Metodo para Regresar al Inicio
        public void DirigirPestañaRegreso()
        {
            tbcFormularioAdm.SelectedIndex = 0;// dirige a la pestaña principal del administrdor
            ((Control)this.tabPage1).Enabled = true; // habilita la pestaña principal
            ((Control)this.tabPage2).Enabled = false; //bloquea la pestañas de los usuario
            ((Control)this.tabPage3).Enabled = false; // bloquea la pestañas de la sucursales
        }
        //Metodo para Regresar Inicar Sesión
        public void CerrarSesion()
        {
            Login RegrearLogin = new Login(); // Instancia del formulario del login
            RegrearLogin.Show(); //Dirigi al formulario del login
            this.Hide(); // Cerramos el formulario Actual
        }

        //Metodo para borrar los campos del usuario
        public void BorrarCamposUser()
        {  // Limipa las cajas 
            txtNombre.Clear();
            txtApellido.Clear();
            txtDireccion.Clear();
            txtContacto.Clear();
            txtUser.Clear();
            txtPasword.Clear();
            txtCargo.Text = "";
       

        }
        // Metodo para borrar los campos de la Sucursal
        public void BorrarCamposSucursal()
        { // limpiar la caja de textos
            txtNombreSucur.Clear();
            txtDireccionSucursal.Clear();
        }

        // Metodo para verificar los campos 
        public void ValidarCamposUser_RegistrarUser()
        {
           
              

            if (Validar.CamposVacio(txtNombre.Text)) // Verifica el campo del nombre si esta vacio
            {
                if (Validar.CamposVacio(txtApellido.Text)) // verifica el campo del apellido si esta vacio
                {
                    if (Validar.CamposVacio(txtCargo.Text)) // verifica el campo del cargo si esta vacio
                    {
                        if (Validar.CamposVacio(txtDireccion.Text)) // verifica el campo de la dirección si esta vacio
                        {
                            if (Validar.CamposVacio(txtContacto.Text)) // Verifica el campo de contacto si esta vacio
                            {
                                if (Validar.CamposVacio(txtUser.Text)) // Verificar el campo de user si esta vacio
                                {
                                    if (Validar.CamposVacio(txtPasword.Text)) // Verificar el campo de password si esta vacio
                                    {
                                        Fecha();// Metodo para sacar la fecha de nacimiento del usuario

                                        // Insertamos los datos hacia la base de datos
                                        txtID.Text = dgv_tablauser.Rows.Count.ToString(); // Mostrar el indice del Usuario es decir el ID del Usuario  // Insertamos la dicha información que sera dirigido a la clase por medio de parametros
                                        if (sqlConexion.insertar(txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtContacto.Text, fechaNacimiento, txtUser.Text, txtPasword.Text, txtCargo.SelectedValue.ToString()))// Insertamos los datos hacia la base de datos 
                                        {
                                            MessageBox.Show("Datos Insertados con exito");// Mensaje que se inserto los datos
                                            dgv_tablauser.DataSource = sqlConexion.MostrarDatos(); // El resultado se mostrara datagriview
                                        }
                                        else
                                        {
                                            MessageBox.Show("No se han podido Insetar los datos"); // No se ha podido insetar los datos
                                        }
                                    }
                                    else
                                    {
                                        txtPasword.Focus(); // Le indica donde le falta de llenar el espacio vacio del password
                                    }

                                }
                                else
                                {
                                    txtUser.Focus();// Le indica donde le falta de llenar el espacio vacio  //User
                                }
                            }
                            else
                            {
                                txtContacto.Focus(); // Le indica donde le falta de llenar el espacio vacio del //contacto
                            }
                        }
                        else
                        {
                            txtDireccion.Focus(); // Le indica donde le falta de llenar el espacio vacio del // Dirección
                        }
                    }
                    else
                    {
                        txtCargo.Focus();// Le indica donde le falta de llenar el espacio vacio del //Cargo
                    }
                }
                else
                {
                    txtApellido.Focus(); // Le indica donde le falta de llenar el espacio vacio del //Apellidos
                }
            }
            else
            {
                txtNombre.Focus(); // Le indica donde le falta de llenar el espacio vacio del  //Nombre
            }
        } // Fin del Metodo para verificar los campos y de insertar los datos



        // Metodo para verificar los campos y de registrar los sucurales
        public void VericarCampos_RegistrarSucursal()
        {
            if (Validar.CamposVacio(txtNombreSucur.Text)) // Verifica el campo de la sucursal
            {
                if (Validar.CamposVacio(txtDireccionSucursal.Text))// Verifica el campo de la dirección de la sucursal
                {
                    // Insetamos los datos hacia la base de datos de la sucursal
                    txtIDSucursal.Text = dgvSucursales.Rows.Count.ToString();// Mostrar el indice de la sucurales es decir el ID de la sucursales
                    if (sqlConexionSucusal.insertar(txtNombreSucur.Text, txtDireccionSucursal.Text))
                    {
                        MessageBox.Show("Datos Insertados con exito");// Mensaje que se inserto los datos
                        dgvSucursales.DataSource = sqlConexionSucusal.MostrarDatosSucursal();
                    }
                    else
                    {
                        MessageBox.Show("No se han podido Insetar los datos"); // No se ha podido insetar los datos
                    }
                }
                else
                {
                    //Dirección de la sucursal
                }
            }
            else
            {
                // Nombre sucursal
            }
        }

        // Fin de los Metodos Publicos






        // Programa Basicos de los botones

        // Boton dirigir a la pestaña para crear los usuario
        private void btnCrearUser_Click(object sender, EventArgs e)
        {
            DirigirPestañasUser(); // Metodo para dirigise a la pestañas de los usuario
        }
        // Boton para dirigir a la pestaña para crear los usuario
        private void btnCrearSucursales_Click(object sender, EventArgs e)
        {
            DirigirPestañaSucursales();// Metodo para dirigirse a la pestañas de los sucursales
        }
        // Boton para regresar al login
        private void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            CerrarSesion(); // Ir al formulario de login
        }
        // Boton para salir  de la aplicación
        private void btnsalir_Click(object sender, EventArgs e)
        {
            Application.Exit(); // cierra la aplicación
        }

        // Pestañas de los USUARIOS
        // Boton crear cuentas de la base de datos
        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            ValidarCamposUser_RegistrarUser(); // Metodos para verificar los datos y de igual forma ingresa los datos hacia a la base de datos
        }
        // Borrar los campos de los usuarios
        private void btnBorrarDatos_Click(object sender, EventArgs e)
        {
            BorrarCamposUser(); // Borrar los campos de los usuarios
        }
         // Boton para eliminar  los datos de los usuario desde los usuario
        private void btnEliminar_Click(object sender, EventArgs e)
        {// Por medio de la id  va seleccionar todo la fila para elimar los datos  la cual metodo hara la  función que es traido por la clase
            if (sqlConexion.Eliminar(txtID.Text))// Eliminamos los datos hacia la base de datos 
            {
                MessageBox.Show("Datos Eliminados");// Mensaje que se inserto los datos
                dgv_tablauser.DataSource = sqlConexion.MostrarDatos(); // El resultado mostrara datagriview
            }
            else
            {
                MessageBox.Show("No se han podido eliminar los datos"); // No se ha podido eliminar los datos
            }
        }
         // Boton para Actualizar los datos  de los usuario 
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Fecha();// Metodo para sacar la fecha de nacimiento del usuario  // vuelve a vericar por cada campo si hay un cambio  para poder insertar de nuevo la información
            if (sqlConexion.Actualizar(txtID.Text, txtNombre.Text, txtApellido.Text, txtDireccion.Text, txtContacto.Text, fechaNacimiento, txtUser.Text, txtPasword.Text, txtCargo.SelectedValue.ToString()))// Insertamos los datos hacia la base de datos 
            {
                MessageBox.Show("Datos actualizados");// Mensaje que se inserto los datos
                dgv_tablauser.DataSource = sqlConexion.MostrarDatos(); // El resultado mostrara datagriview
            }
            else
            {
                MessageBox.Show("No se han podido actualizar los datos"); // No se ha podido insetar los datos
            }
        }
        // Regresar  a la pestañas de inico
        private void btnRegresar2_Click(object sender, EventArgs e)
        {
            DirigirPestañaRegreso(); // Metodo para dirigise a pestañas de inicio
        }


        // Evento CellClick user muestra la información en los textbox 
        private void dgv_tablauser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_tablauser.Rows[e.RowIndex]; // A la filas seleccionada
            
            txtID.Text = Convert.ToString(fila.Cells[0].Value); // La primera columnas de datagridview de la ID
            txtNombre.Text = Convert.ToString(fila.Cells[1].Value); // La segunda columnas de datagridviwe del nombre de la persona
            txtApellido.Text = Convert.ToString(fila.Cells[2].Value); // La tercera columnas de tadagridviwe del apellidos
            txtDireccion.Text = Convert.ToString(fila.Cells[3].Value); // La quitna colunas de datagridview de la Dirección
            txtContacto.Text = Convert.ToString(fila.Cells[4].Value); // La sexta columnas de la datagridview del contacto
            dtpFechaNac.Text = Convert.ToString(fila.Cells[5].Value); // La septima columnas de la datagridview la fecha de nacimiento
            txtUser.Text = Convert.ToString(fila.Cells[6].Value); // La octava columnas de la datagridviwe muestra el nombre usario login
            txtPasword.Text = Convert.ToString(fila.Cells[7].Value); // La novena columnas de la datagridview muestra la contraseña del usuario usado para login
            txtCargo.Text = Convert.ToString(fila.Cells[8].Value); // La cuarta columnas de la datagridview del Cargo

           
        }



        //****************************************************************************************************************************************************************************

        // Pestañas de los Sucursales

        // Evento CellClick Sucursal muestra la información en los textbox 
        private void dgvSucursales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow filaSuc = dgvSucursales.Rows[e.RowIndex]; // A la filas seleccionada
            txtIDSucursal.Text = Convert.ToString(filaSuc.Cells[0].Value);// columna de la Id de la sucursal
            txtNombreSucur.Text = Convert.ToString(filaSuc.Cells[1].Value); // Columna del nombre de la sucursal
            txtDireccionSucursal.Text = Convert.ToString(filaSuc.Cells[2].Value); // Columa de la dirección de la sucursal
        }




        // Boton para insertar los datos  desde la base de datos.
        private void btnCrearSucursal_Click(object sender, EventArgs e)
        {
            VericarCampos_RegistrarSucursal();// Metodo par averificar los campos y registrar los Sucursales
        }

        // Boton para borrar los datos de los campos 
        private void btnBorrarDatosSuc_Click(object sender, EventArgs e)
        {
            BorrarCamposSucursal(); // Metodo para borrar los campos de Sucursal
        }
        // Eliminar  los datos desde la base de datos 
        private void bntElimarSuc_Click(object sender, EventArgs e)
        {
            if (sqlConexionSucusal.EliminarSucursal(txtIDSucursal.Text))// Por medio de la id  va seleccionar todo la fila para elimar los datos 
            {                                                          // donde se realizara por medio del metodo traido por clase
                MessageBox.Show("Datos Eliminados");
                dgvSucursales.DataSource = sqlConexionSucusal.MostrarDatosSucursal();
            }
            else
            {
                MessageBox.Show("No se han podido actualizar los datos"); // No se ha podido insetar los datos
            }
        }

       

        // Boton para acutalizar los datos desde la bases de datos 
        private void btnActualizarSuc_Click(object sender, EventArgs e)
        {         // vuelve a vericar por cada campo si hay un cambio  para poder insertar de nuevo la información
            if (sqlConexionSucusal.ActualizarSucursal(txtIDSucursal.Text, txtNombreSucur.Text, txtDireccionSucursal.Text))
            {
                MessageBox.Show("Datos actualizados");// Mensaje que se inserto los datos
                dgvSucursales.DataSource = sqlConexionSucusal.MostrarDatosSucursal();
            }
            else
            {
                MessageBox.Show("No se han podido actualizar los datos"); // No se ha podido insetar los datos
            }
        }

        private void txtBuscadorSucursal_TextChanged(object sender, EventArgs e)
        {
            // Tinene que ser disto a vacio           Si ingresa la información  se mostrara la dicha información que busca
            if (txtBuscadorSucursal.Text != "") dgvSucursales.DataSource = sqlConexionSucusal.BuscarSucursal(txtBuscadorSucursal.Text);
            else dgvSucursales.DataSource = sqlConexionSucusal.MostrarDatosSucursal(); // si no existe que no muestre nada que se mantega igual
        }

        private void txtBuscadorUser_TextChanged(object sender, EventArgs e)
        {    // Tiene que ser distinto a vacio    si ingresa la información se mostrar la dica información que busca
            if (txtBuscadorUser.Text != "") dgv_tablauser.DataSource = sqlConexion.Buscar(txtBuscadorUser.Text);
            else dgv_tablauser.DataSource = sqlConexion.MostrarDatos(); // si no existe que no muestra nada 
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); // Validar el campo de la letra 
        }

        private void txtContacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoNumeros(e); // Validar el campo solo numero


        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); // Validar el campo solo de letras
        }

        private void txtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); // Validar el campo  solo de letras 
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        // Boton para regresar el inicio
        private void btnRegresoInicio_Click(object sender, EventArgs e)
        {
            DirigirPestañaRegreso(); // Metodo para dirigise a pestañas de inicio
        }

        // Form Load 
        private void AdministradorDePrincipal_Load(object sender, EventArgs e)
        {
            // Mostrar Datos que trae a la base de datos de los usuarios
            dgv_tablauser.DataSource = sqlConexion.MostrarDatos();
            // Mostrar Datos que trae a la base de datos de los sucursales
            dgvSucursales.DataSource = sqlConexionSucusal.MostrarDatosSucursal();


            //
            sqlConexion.llenearCargo(txtCargo);

            // Metodo para bloquear las pestañas
            BloqueoDePestaña();
        }// Fin form load 


       


    }
}
