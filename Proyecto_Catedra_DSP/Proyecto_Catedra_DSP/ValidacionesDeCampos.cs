using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;// Libreria para usar los diferentes herraminetas

namespace Proyecto_Catedra_DSP
{
    class ValidacionesDeCampos
    {
        //Validar si son letras  por medio de los eventos 
        public void ValidarCampoLetras(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsLetter(e.KeyChar)) // verifica si es una letra que la escriba
                {
                    e.Handled = false;  // si no es un numero que escriba la letra
                }
                else if (char.IsControl(e.KeyChar))// tecla de control que permita borrar
                {
                    e.Handled = false; // permite borrar 
                }
                else if (char.IsSeparator(e.KeyChar)) // permiter el uso de espaciador
                {
                    e.Handled = false; //si presiona el espaciador dejara un espacio
                }

                else
                {
                    e.Handled = true; // Si no es letra, ni borrar ni espacio entonce que no lo escriba. 
                }
            }
            catch { }
        }// Fin de validar campos de letras



        // Validar un número por medio de los eventos KeyPress
        public void ValidarCampoNumeros(KeyPressEventArgs e)
        {
            try
            {
                if (char.IsNumber(e.KeyChar)) // verifica si es un numero 
                {
                    e.Handled = false; // Si no es una letra que escriba el número
                }
                else if (char.IsControl(e.KeyChar))// tecla de control que permita borrar
                {
                    e.Handled = false;
                }
                else if (char.IsSeparator(e.KeyChar)) // permiter los  espacio 
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = true; // Si no es un número que no escriba   
                }
            }
            catch { } // Fin de validar campos de letras
        }// Fin del Metodo validar Número

        // Verifica los camposVacio 
        public bool CamposVacio(string campo) // en el parametro envia la información la cual es verificada en el form
        {
            try
            {
                // Codigo comprovación de textbox
                if (campo == "")
                {
                    MessageBox.Show("Campo vacio");

                    return false; // si el campo esta vacio no permitara guardar el dato

                }

            }// Fin del try

            catch { }
            return true;
        }// fin del meto campos vacio


    }
}
