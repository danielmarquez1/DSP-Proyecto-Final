using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Librerias a ocupara para la conexión sql Server 
using System.Data;//Uso para tenner acceso a los datos y administrarlos
using System.Data.SqlClient; //Uso para poder acceder a los codigos sql

namespace Proyecto_Catedra_DSP
{
    class conexionAdministradorPrincipal
    {

        // Cadena de conexión 
        private SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=BDD;Integrated Security=True"); // Establece la conexión de la base de datos.
        private DataSet DS; // Uso Guardad varias tablas llamada datatable. y mostrar los datos.

        // Metodo para mostrar los datos
        public DataTable MostrarDatos()
        {
            conexion.Open(); // Abrimos la conexión
            SqlCommand cmd = new SqlCommand("select * from Usuarios", conexion);// Abre la conexión de la tabla de los Inventario
            SqlDataAdapter ad = new SqlDataAdapter(cmd);// sirver si el comando es de tipo select
            DS = new DataSet(); //Borrar todas las talbas

            ad.Fill(DS, "tabla"); // duda LLenemos a la tabla 
            conexion.Close();// cerramos la conexión para ocupar en otro lugar
            return DS.Tables["tabla"]; // retomar el valor
        }

        // Metodo para buscar el nombre de la persona
        public DataTable Buscar(string nombre)
        {
            conexion.Open(); // Abrimos la conexión         seleccionar toda las filas de los usuarios cuando  Nombre  contenga el argumento
            SqlCommand cmd = new SqlCommand(string.Format("select * from Usuarios where Nombre like  '%{0}%' ", nombre), conexion);// Abre la conexión de la tabla de los usuarios
            SqlDataAdapter ad = new SqlDataAdapter(cmd);// sirver si el comando es de tipo select
            DS = new DataSet(); //Borrar todas las talbas

            ad.Fill(DS, "tabla"); // duda LLenemos a la tabla 
            conexion.Close();// cerramos la conexión para ocupar en otro lugar
            return DS.Tables["tabla"]; // retomar el valor
        }

        //Metodo para insetar los datos del producto
        public bool insertar( string Nombre, string Apellidos,  string direccion, string contacto, string fechaNacimiento, string usuario, string contrasena ,string Idcargo)
        {
            conexion.Open(); // Abrimos la conexión
            //comando                                      // inserta la información de los usuarios por medeio de los  argumentos se ira ingresado dicha información a los parametros
            SqlCommand cmd = new SqlCommand(string.Format("insert into Usuarios values ( '{0}' , '{1}' , '{2}', '{3}' ,'{4}', '{5}' , '{6}' , {7}  )", new string[] { Nombre, Apellidos,  direccion, contacto, fechaNacimiento, usuario, contrasena, Idcargo }), conexion);
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }

        // LLenamos combox  que traemos dese la base de datos
        public void llenearCargo(ComboBox Cargo)
        {
            conexion.Open();//abrimos la conexión
            DataTable Lista = new DataTable();// Busqueda  para información de la tabla
            SqlDataAdapter ada;                // por medio select seleccciona Id y el nombre para traer la dicha información
            SqlCommand cmd = new SqlCommand(string.Format("select ID_De_Cargo ,Nombre from Cargos "), conexion);// Abre la conexión de la tabla de cargo para traer dicha información ingrsada base de datos
            ada = new SqlDataAdapter(cmd);
            ada.Fill(Lista);// LLenamos la información
            Cargo.DataSource = Lista;
            Cargo.DisplayMember = "Nombre"; // Traemos el texto
            Cargo.ValueMember = "ID_De_Cargo"; // Treaemos el valor

            
            conexion.Close();// Cerramos la conexion


        }
        // Metodo para eliminar datos
        public bool Eliminar(string id)
        {
            conexion.Open(); // Abrimos la conexión
            //comando                                      eliminar las filas de la pieza la cuales  este en el id
            SqlCommand cmd = new SqlCommand(string.Format("delete from Usuarios where ID_de_Usuario = {0} ", id), conexion);// Formato para eliminar  a la persona por medio del IDUsuario
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }




        // Metodo para actualizar los datos
        public bool Actualizar(string id, string Nombre, string Apellidos , string direccion, string contacto, string fechaNacimiento, string usuario, string contrasena, string Idcargo)
        {
            conexion.Open(); // Abrimos la conexión
            //comando                   acutuzalizar las pieza las cauleas evaluamos por cada campo para que sean actualizado          
            String dato = string.Format("update Usuarios set Nombre = '{0}', Apellidos = '{1}', Direccion  = '{2}' , Contacto = '{3}' , Fecha_de_nacimiento = '{4}' , Usuario = '{5}', Contraseña = '{6}'  , ID_De_Cargo= {7}  where ID_de_Usuario = {8} ", Nombre, Apellidos, direccion, contacto, fechaNacimiento, usuario, contrasena, Idcargo,  id);// 
            // Problema where
            SqlCommand cmd = new SqlCommand(dato, conexion);// Formato para acutalizar los datos
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;

        }




    }// Fin de la clases






    class Sucursal 
    {
        // Cadena de conexión 
        private SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=BDD;Integrated Security=True"); // Establece la conexión de la base de datos.
        private DataSet DS; // Uso Guardad varias tablas llamada datatable. y mostrar los datos.



        // Metodo para mostrar los datos
        public DataTable MostrarDatosSucursal()
        {
            conexion.Open(); // Abrimos la conexión
            SqlCommand cmd = new SqlCommand("select * from sucursal", conexion);// Abre la conexión de la tabla de la sucursales
            SqlDataAdapter ad = new SqlDataAdapter(cmd);// sirver si el comando es de tipo select
            DS = new DataSet(); //Borrar todas las talbas

            ad.Fill(DS, "tabla"); //LLenemos a la tabla 
            conexion.Close();// cerramos la conexión para ocupar en otro lugar
            return DS.Tables["tabla"]; // retomar el valor
        }
        // Metodo para buscar los sucursales
        public DataTable BuscarSucursal(string sucursal)
        {
            conexion.Open(); // Abrimos la conexión         seleccionar toda las filas de los usuarios cuando  Nombre  contenga el argumento
            SqlCommand cmd = new SqlCommand(string.Format("select * from sucursal where Nombre like  '%{0}%' ", sucursal), conexion);// Abre la conexión de la tabla de los usuarios
            SqlDataAdapter ad = new SqlDataAdapter(cmd);// sirver si el comando es de tipo select
            DS = new DataSet(); //Borrar todas las talbas

            ad.Fill(DS, "tabla"); // duda LLenemos a la tabla 
            conexion.Close();// cerramos la conexión para ocupar en otro lugar
            return DS.Tables["tabla"]; // retomar el valor
        }
        // Metodo para insertar sucursal
        public bool insertar( string NombreSucursal, string Direccion)
        {
            conexion.Open(); // Abrimos la conexión
            //comando                                      // inserta la información de la sucursales por medeio de los  argumentos se ira ingresado dicha información a los parametros
            SqlCommand cmd = new SqlCommand(string.Format("insert into sucursal values ('{0}' , '{1}'  )", new string[] { NombreSucursal , Direccion }), conexion);
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }

        // Metodo para eliminar  sucursal
       
        public bool EliminarSucursal(string id)
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("delete from sucursal where ID_Sucursal = {0} ", id), conexion);
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }

        public bool ActualizarSucursal(string id, string NombreSucursal, string Direccion)
        {
            conexion.Open(); // Abrimos la conexión
            //comando                   acutuzalizar a los sucursales          
            String dato = string.Format("update sucursal set Nombre = '{0}', Direccion = '{1}'   where ID_Sucursal = '{2}' ", NombreSucursal,Direccion, id);
            // Problema where
            SqlCommand cmd = new SqlCommand(dato, conexion);// Formato para acutalizar los datos
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;

        }

    }


}// Fin del namespace
