
//using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.ModelBinding;

namespace Proyecto.Utilitarios
{
    public static class Utilidades
    {
            public static string GenerarPassword(int longitud)
            {
                string contraseña = string.Empty;
                string[] letras = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "ñ", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
                                "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
                Random EleccionAleatoria = new Random();

                for (int i = 0; i < longitud; i++)
                {
                    int LetraAleatoria = EleccionAleatoria.Next(0, 100);
                    int NumeroAleatorio = EleccionAleatoria.Next(0, 9);

                    if (LetraAleatoria < letras.Length)
                    {
                        contraseña += letras[LetraAleatoria];
                    }
                    else
                    {
                        contraseña += NumeroAleatorio.ToString();
                    }
                }
                return contraseña;
            }

            public static string GenerateHTMLRecuperarContrasena(string PassTemporal)
            {
                string HTML = String.Concat("<!DOCTYPE html>", "<html xmlns='http://www.w3.org/1999/xhtml'>",
                                                    "<head><meta http-equiv='Content-Type' content='text/html;charset=utf-8'/><title></title></head><body><form id='form2'><div class='logo'></div><div class='campos'><div class='fila-login'>",
                                                    "<center><label>Contraseña Temporal :", PassTemporal, "</label></center>",
                                                    "</div></div></form></body></html>");
                return HTML;

            }

            /// <summary>
            /// Método que retorna número de Rut sin dígito verificador
            /// </summary>
            /// <param name="rut">Rut</param>
            /// <returns>Número de Rut sin dígito verificador</returns>
            public static int RutSinDV(string rut)
            {
            int rutnumero = 0;
            try
            {
                if (rut.IndexOf("-") != -1)
                {
                    rut = rut.Replace(".", "").Replace("-", "").Trim();
                    rut = rut.Substring(0, rut.Length - 1);
                }
            
                rutnumero = int.Parse(rut);
            }
            catch (Exception)
            {
                rutnumero = 0;
            }
            return rutnumero;
        }
        /// <summary>
        /// Método que retorna el dígito verificador
        /// </summary>
        /// <param name="rut">Rut</param>
        /// <returns>Dígito verificador de un rut</returns>
        public static string DV(string rut)
            {
                var dv = rut.Substring(rut.Length - 1, 1);
                return dv;
            }

            public static bool ValidateForm(List<string> list)
            {
                bool retorno = false;
                foreach (var item in list)
                {
                    retorno = !String.IsNullOrEmpty(item);

                    if (!retorno) break;
                }

                return retorno;
            }

        //private static readonly ILog Log = Logs.GetLogger();

        /// <summary>
        /// Metodo que trunca un string a la cantidad de caracteres ingresado
        /// </summary>
        /// <param name="value">se ingresa automaticamente el mismo valor del string</param>
        /// <param name="maxLength">int largo Maximo</param>
        /// <returns>String truncado</returns>
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        //public static void RecorrerObjeto(object obj)
        //{
        //    try
        //    {
        //        var aa = obj.GetType().BaseType.Name;
        //        string[] propertyNames = obj.GetType().GetProperties().Select(p => p.Name).ToArray();
        //        string[] datos = { };
        //        int cantidad = 1;
        //        foreach (var prop in propertyNames)
        //        {
        //            try
        //            {
        //                var propValue = obj.GetType().GetProperty(prop).GetValue(obj, null);
        //                Log.Debug(prop + ": " + propValue);
        //            }
        //            catch (Exception)
        //            {

        //                var error = "si";
        //            }
        //            cantidad++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }           
        //}

    }
}