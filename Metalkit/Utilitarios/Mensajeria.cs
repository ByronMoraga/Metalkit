using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Proyecto.Utilitarios
{
    public class Mensajeria
    {
        private static readonly string SessionKey = "__Mensajeria__";

        public static void SetMensaje(string mensaje = "informacion", TiposMensajes tipo = TiposMensajes.Informacion)
        {
            MensajeInfo info = new MensajeInfo { Mensaje = mensaje, TipoMensaje = tipo };
            HttpContext.Current.Session[Mensajeria.SessionKey] = info;
        }

        public static string MostrarMensaje()
        {

            object obj = HttpContext.Current.Session[Mensajeria.SessionKey];
            if (obj is MensajeInfo)
            {
                MensajeInfo info = obj as MensajeInfo;
                string code = String.Format("<script>mostrarMensaje('{0}','{1}');</script>",
                    HttpUtility.JavaScriptStringEncode(info.Mensaje),
                    info.TipoMensaje);
                HttpContext.Current.Session[Mensajeria.SessionKey] = null;
                return code;
            }


            HttpContext.Current.Session[Mensajeria.SessionKey] = null;
            return String.Empty;
        }

        public enum TiposMensajes
        {
            Informacion = 1,
            Exito = 2,
            Error = 3,
            Accion = 4,
            ErrorLoginAdmin = 5,
            ErrorLoginFuncionario = 6
        }
    }

    public class MensajeInfo
    {
        public string Mensaje { get; set; }
        public Mensajeria.TiposMensajes TipoMensaje { get; set; }
    }
}