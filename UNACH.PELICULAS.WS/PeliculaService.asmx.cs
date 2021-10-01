using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using UNACH.PELICULAS.WS.models;

namespace UNACH.PELICULAS.WS
{
    /// <summary>
    /// Descripción breve de PeliculaService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class PeliculaService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        #region CRUD PELICULAS
        [WebMethod(Description ="OBTENER TODA LA LISTA DE PELICULAS")]
        public List<tabla_pelicula> GetPelicula()
        {
            using (peliculaEntities conexion = new peliculaEntities())
            {
                var consulta = (from a in conexion.tabla_peliculas select a);
                return consulta.ToList();
                
            }
        }
        #endregion
    }
}
