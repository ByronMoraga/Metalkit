
//using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SistemaMVC.Utilitarios
{
    public static class Utilidades
    {
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