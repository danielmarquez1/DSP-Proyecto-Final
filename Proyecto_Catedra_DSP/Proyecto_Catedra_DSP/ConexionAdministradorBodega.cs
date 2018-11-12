using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Librerias a ocupara para la conexión sql Server 
using System.Data;//Uso para tenner acceso a los datos y administrarlos
using System.Data.SqlClient; //Uso para poder acceder a los codigos sql

namespace Proyecto_Catedra_DSP
{
    class ConexionAdministradorBodega
    {
        // Cadena de conexión 
        private SqlConnection conexion = new SqlConnection("Data Source=(local);Initial Catalog=BDD;Integrated Security=True"); // Establece la conexión de la base de datos.
        private DataSet DS; // Uso Guardad varias tablas llamada datatable. y mostrar los datos.

        // Metodo para mostrar los datos
        public DataTable MostrarDatos()
        {
            conexion.Open(); // Abrimos la conexión
            SqlCommand cmd = new SqlCommand("select * from Inventario", conexion);// Abre la conexión de la tabla de los usuarios
            SqlDataAdapter ad = new SqlDataAdapter(cmd);// sirver si el comando es de tipo select
            DS = new DataSet(); //Borrar todas las talbas

            ad.Fill(DS, "tabla"); //  LLenemos a la tabla 
            conexion.Close();// cerramos la conexión para ocupar en otro lugar
            return DS.Tables["tabla"]; // retomar el valor
        }

        // Metodo para buscar la pieza
        public DataTable Buscar(string pieza)
        {
            conexion.Open(); // Abrimos la conexión         seleccionar toda las filas de los usuarios cuando  pieza  contenga el argumento
            SqlCommand cmd = new SqlCommand(string.Format("select * from Inventario where Pieza like  '%{0}%' ", pieza), conexion);// Abre la conexión de la tabla de los usuarios
            SqlDataAdapter ad = new SqlDataAdapter(cmd);// sirver si el comando es de tipo select
            DS = new DataSet(); //Borrar todas las talbas

            ad.Fill(DS, "tabla"); // LLenemos a la tabla 
            conexion.Close();// cerramos la conexión para ocupar en otro lugar
            return DS.Tables["tabla"]; // retomar el valor
        }

        // Metodo para insertar
        public bool insertar(string pieza , string codigo , string modelo ,string marca , string precio , string cantidad, string NumeroEstante,string Fabricante, string descripcion,string FechaRegistro )
        {
            conexion.Open(); // Abrimos la conexión          // insertamos por medio de los argumentos los datos en el orden                                  llenamos los datos pormedio de varchar
            SqlCommand cmd = new SqlCommand(string.Format("insert into Inventario values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}')", new string[] {pieza,codigo,modelo,marca,precio,cantidad,NumeroEstante,Fabricante,descripcion,FechaRegistro }),conexion);
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }

        public bool Eliminar(string id)
        {
            conexion.Open(); // Abrimos la conexión
            //comando                                      eliminar las filas de los usuarios la cuales  este en el id
            SqlCommand cmd = new SqlCommand(string.Format("delete from Inventario where ID_de_inventario = {0} ", id), conexion);// Formato para eliminar  a la persono por medio del IDUsuario
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }


        public bool Actualizar(string id, string pieza, string codigo, string modelo, string marca, string precio, string cantidad, string NumeroEstante, string Fabricante, string descripcion, string FechaRegistro)
        {
            conexion.Open(); // Abrimos la conexión

            //comando                   acutuzalizar a los usuarios para eso evaluamos por cada cada argumento y por medio de parametros          
            String dato = string.Format("update Inventario set Pieza='{0}' , Codigo = '{1}', Modelo = '{2}', Marca = '{3}' , Precio = '{4}' , Cantidad = '{5}' , Numero_de_estante = '{6}', Fabricante='{7}', Descripcion ='{8}', Fecha_de_registro = '{9}'  where ID_de_inventario = {10} ", pieza,codigo,modelo,marca,precio,cantidad,NumeroEstante,Fabricante,descripcion,FechaRegistro,id);
            // Problema where
            SqlCommand cmd = new SqlCommand(dato, conexion);// Formato para acutalizar los datos
            int FilasAfectadas = cmd.ExecuteNonQuery();// uso para ver las filas ha sido afectadas
            conexion.Close(); // cerrramos la conexión 
            if (FilasAfectadas > 0) return true; // isnetar datos
            else return false;
        }


    }
}
