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
    public partial class AdministradorDeBodega : Form
    {
        public AdministradorDeBodega()
        {
            InitializeComponent();
        }
        // Variables locales
        int dia, mes, año;
        string fechaRegistro;

        // Instancia de la clase de conexión Administrador Bodega
        ConexionAdministradorBodega sqlConexion = new ConexionAdministradorBodega();
        ValidacionesDeCampos Validar = new ValidacionesDeCampos();// instancia de la clase para validar los campos


        //Metodos Publicos 

            public void Fechas() // Metodo para sacar la fehca de los registros
        {
            dia = dtpFechaRigistro.Value.Day; // Evalua el dia
            mes = dtpFechaRigistro.Value.Month; // Evalua mes
            año = dtpFechaRigistro.Value.Year; // Evalua Año
            fechaRegistro = dia + "/" + mes + "/" + año; // Une la fachas
        }
        // Metodo para bloquear las pestañas
        public void BloqueoDePestañas()
        {
            ((Control)this.tabPage2).Enabled = false; // Inabilitamos la pestañas de ver Bodega
            ((Control)this.tabPage1).Enabled = true; // Inabilitamos la pestañas principal
            ((Control)this.txtIDInventario).Enabled = false; // bloquea la caja de texto del id inventario
        }
        // Metodo para Dirigir a la pestañas de Ver los productos
        public void DirigirPestaña()
        {
            tbcFormularioAdm.SelectedIndex = 1; // direge a la pestaña del inventario
            ((Control)this.tabPage1).Enabled = false;// Habilita la pestaña del administrador principal
            ((Control)this.tabPage2).Enabled = true; // deshabilita la pestaña del ver los registro del inventario
        }

        //Metodo para regresar a la pestañas de inico
        public void RegresarInicio()
        {
            tbcFormularioAdm.SelectedIndex = 0; // Regresa la pestaña principal de administrador
            ((Control)this.tabPage1).Enabled = true; // Habilita la pestaña
            ((Control)this.tabPage2).Enabled = false; // Deshabilita la pestaña de los registro de productos
        }
        // Metodo para regresar al login
        public void CerrarSesion()
        {
            Login RegrearLogin = new Login(); // Instancia del formulario del login
            RegrearLogin.Show(); //Dirigi al formulario del login
            this.Hide(); // Cerramos el formulario Actual
        }
        // Metodo para borrar los campos de los textos
        public void BorrarCampos()
        {
            txtPieza.Clear();
            txtFabricante.Clear();
            txtCodigo.Clear();
            txtCantidad.Clear();
            txtModelo.Clear();
            txtMarca.Clear();
            txtPrecio.Clear();
            txtNumeroEstante.Clear();
            txtDescipcion.Clear();
        }

       public void ValidarCampos_InsertarDatos()
        {
            if (Validar.CamposVacio(txtPieza.Text)) // Verifica  campo de la pieza
            {
                if (Validar.CamposVacio(txtFabricante.Text)) // Verifica el campo del fabricante
                {
                    if (Validar.CamposVacio(txtCantidad.Text)) // Verifica el campo de cantidad
                    {
                        if (Validar.CamposVacio(txtModelo.Text)) // Verifia el campo del modelo
                        {
                            if (Validar.CamposVacio(txtMarca.Text)) //Verifca el campo de la marca
                            {
                                if (Validar.CamposVacio(txtPrecio.Text)) //  Verifica el campo del precio
                                {
                                    if (Validar.CamposVacio(txtNumeroEstante.Text)) // Verifica campo del numero de estante
                                    {
                                        if (Validar.CamposVacio(txtDescipcion.Text)) //  Verifica el campo de la descripción
                                        {
                                            // BASE DE DATOS INSERTAMOS LA INOFORMACIÓN

                                            Fechas(); // Sacar la fecha

                                            txtIDInventario.Text = dgvProductos.Rows.Count.ToString(); // Mostrar numero del producto es decir el ID Producto 
                                                                                                       // Por medio de la condición insertamos la información que le  pasmos por parametros  hacia a la clase  sqlConexión hacia al metodo de insertar
                                            if (sqlConexion.insertar( txtPieza.Text, txtCodigo.Text, txtModelo.Text, txtMarca.Text, txtPrecio.Text, txtCantidad.Text, txtNumeroEstante.Text, txtFabricante.Text, txtDescipcion.Text, fechaRegistro))
                                            {
                                                MessageBox.Show("Inserto la información con exito");
                                                dgvProductos.DataSource = sqlConexion.MostrarDatos(); // Una vez ingresa los datos se recargar mostrarDatos
                                            }
                                            else
                                            {
                                                MessageBox.Show("No se han podido insertar los datos");// Mensaje de Error al ingresar los datos
                                            }



                                        }
                                        else
                                        {
                                            //Le indica el campo deonde debe lllenar la información Descripción
                                            txtDescipcion.Focus();
                                        }
                                    }
                                    else
                                    {
                                        //  //Le indica el campo deonde debe lllenar la información nEstante
                                        txtNumeroEstante.Focus();
                                    }

                                }
                                else
                                {
                                    //  //Le indica el campo deonde debe lllenar la información  Precio
                                    txtPrecio.Focus();
                                }
                            }
                            else
                            {
                                // //Le indica el campo deonde debe lllenar la informació Marca
                                txtMarca.Focus();
                            }
                        }
                        else
                        {
                            //Modelo //Le indica el campo deonde debe lllenar la información
                            txtModelo.Focus();
                        }
                    }
                    else
                    {
                        // //Le indica el campo deonde debe lllenar la informacióCantidad
                        txtCantidad.Focus();
                    }
                }
                else
                {
                    // //Le indica el campo deonde debe lllenar la información Fabricante
                    txtFabricante.Focus();
                }
            }
            else
            {
                // //Le indica el campo deonde debe lllenar la informació Pieza
                txtPieza.Focus();
            }
        }// Fin del meto de validar los datos




        // Fin de los Metodos Publicos


        // BASICO DEL PROGRAMA

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            RegresarInicio(); //Metodo para regresar al inicio
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            CerrarSesion();// Metodo para regresar al login
        }

        private void btnBorrarDatos_Click(object sender, EventArgs e)
        {
            BorrarCampos(); // Metodo para limpiar los campos
        }

        private void btnAñadirProducto_Click(object sender, EventArgs e)
        {
            DirigirPestaña(); // Metodo para dirigirse a la pestañas
        }

        private void btnCerrarAplicación_Click(object sender, EventArgs e)
        {
            Application.Exit(); // salir de la aplicación
        }


        // Inicio de gestión de la base de datos.
        // Formulario de arranque
        private void AdministradorDeBodega_Load(object sender, EventArgs e)
        {   // Mostrar los datos que trea a la base de datos de los productos
            dgvProductos.DataSource = sqlConexion.MostrarDatos(); // Llamaos al metodo de mostrar los productos
            BloqueoDePestañas();// Metodo para bloquear la pestañas
        }

        // Evento CellClick muestra la información en los texbox
        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgvProductos.Rows[e.RowIndex]; //Filas seleccionada  por columnas
            txtIDInventario.Text = Convert.ToString(fila.Cells[0].Value); // Columna invnetario
            txtPieza.Text = Convert.ToString(fila.Cells[1].Value); // Columna Pieza
            txtCodigo.Text = Convert.ToString(fila.Cells[2].Value);// Columa de codigo
            txtModelo.Text = Convert.ToString(fila.Cells[3].Value);// Columa de Modelo
            txtMarca.Text = Convert.ToString(fila.Cells[4].Value);// Columna Marca
            txtPrecio.Text = Convert.ToString(fila.Cells[5].Value);// Columna Precio
            txtCantidad.Text = Convert.ToString(fila.Cells[6].Value);// Columna cantidad
            txtNumeroEstante.Text = Convert.ToString(fila.Cells[7].Value); // Columna Eestante
            txtFabricante.Text = Convert.ToString(fila.Cells[8].Value);  // Columna Fabricante
            txtDescipcion.Text = Convert.ToString(fila.Cells[9].Value);// Columna Descripción
            dtpFechaRigistro.Text = Convert.ToString(fila.Cells[10].Value);// Columna Fecha
          
        }

        // Boton para Registrar los productos
        private void btnRegistroProducto_Click(object sender, EventArgs e)
        {
            ValidarCampos_InsertarDatos();// Metodo para verificar los campos y insertar los datos en la base de datos


        }// Fin del boton de Registrar los Productos

        // Boton para eliminar los datos
        private void bntEliminarProductos_Click(object sender, EventArgs e)
        {
            if(sqlConexion.Eliminar(txtIDInventario.Text)) // Eliminamos los datos hacia la base de datos
            {
                MessageBox.Show("Datos Eliminados");
                dgvProductos.DataSource = sqlConexion.MostrarDatos(); // Se recargar los datos y vuelve mostrar los datos que estan en la base de datos
            }
            else
            {
                MessageBox.Show("No se han podido eliminar los datos"); // No se ha podido elimar los datos
            }
        }// Fin del boton de eliminar los prdouctos

      

        // Boton para actualizar los datos
        private void btnActualizarDatosProductos_Click(object sender, EventArgs e)
        {
            Fechas();

            if (sqlConexion.Actualizar(txtIDInventario.Text, txtPieza.Text, txtCodigo.Text, txtModelo.Text, txtMarca.Text, txtPrecio.Text, txtCantidad.Text, txtNumeroEstante.Text, txtFabricante.Text, txtDescipcion.Text, fechaRegistro))
            {
                MessageBox.Show("Datos Actualizados"); // Mensaje que se inserto los datos
                dgvProductos.DataSource = sqlConexion.MostrarDatos(); // Recargar la base de datos para mostrar los datos ingresado 
            }
            else
            {
                MessageBox.Show("No se han podido actualizar los datos");
            }
        }

        //TextBoX del Buscador
        private void txtBuscadorInventario_TextChanged(object sender, EventArgs e)
        {
            // Tinene que ser disto a vacio           Si ingresa la información  se mostrara la dicha información que busca
            if (txtBuscadorInventario.Text != "") dgvProductos.DataSource = sqlConexion.Buscar(txtBuscadorInventario.Text);
            else dgvProductos.DataSource = sqlConexion.MostrarDatos(); // si no existe que no muestre nada que se mantega igual
        }// Fin del boton de buscar.

        // Fin de gestión de la base de datos



        //Eventos de KeyPress
        private void txtPieza_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); //Desde la clase trae el metodo para validar el campo de letras
        }

        private void txtFabricante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); //Desde la clase trae el metodo para validar el campo de letras
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoNumeros(e);//Desde la clase trae el metodo para validar el campo de numero
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); //Desde la clase trae el metodo para validar el campo de letras
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoNumeros(e); //Desde la clase trae el metodo para validar el campo de numeros
        }

        
        private void txtNumeroEstante_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoNumeros(e);//Desde la clase trae el metodo para validar el campo de numero
        }

        private void txtDescipcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.ValidarCampoLetras(e); //Desde la clase trae el metodo para validar el campo de letras
        }

        // Fin de los eventos KeyPress



    }
}
