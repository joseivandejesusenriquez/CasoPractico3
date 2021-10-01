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
        [WebMethod(Description = "OBTENER TODA LA LISTA DE PELICULAS")]
        public List<tabla_pelicula> GetPelicula()
        {
            using (peliculaEntities conexion = new peliculaEntities())
            {
                var consulta = (from a in conexion.tabla_peliculas select a);
                return consulta.ToList();

            }
        }
        //metodoCreate
        [WebMethod(Description = "Agregar una PELICULA")]
        public bool CreatePelicula(string Nombre,string fecha_de_estreno, string director,string genero)
        {
            try
            {
                using (peliculaEntities conexion = new peliculaEntities())
                {
                    tabla_pelicula nuevo = new tabla_pelicula();
                    nuevo.id = Guid.NewGuid();
                    nuevo.nombre = Nombre;
                    nuevo.Fecha_de_estreno = fecha_de_estreno;
                    nuevo.Director = director;
                    nuevo.Genero = genero;
                    conexion.tabla_peliculas.Add(nuevo);
                    conexion.SaveChanges();//Aqui se guarda
                    return true;

                }

            }
            catch (Exception)
            {

                return false;

            }
           


        }
        [WebMethod(Description = "Modificar una PELICULA")]
        public bool UpdatePelicula(Guid Id, string Nombre, string fecha_de_estreno, string director, string genero)
        {
            try
            {
                using (peliculaEntities conexion = new peliculaEntities())
                {
                    var consulta = (from a in conexion.tabla_peliculas where a.id == Id select a).FirstOrDefault();
                    if (consulta!=null)
                    {
                        consulta.nombre = Nombre;
                        consulta.Fecha_de_estreno = fecha_de_estreno;
                        consulta.Director = director;
                        consulta.Genero = genero;
                        conexion.SaveChanges();//Aqui se guarda
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        [WebMethod(Description = "Eliminar una PELICULA")]
        public bool DeletePelicula(Guid Id)
        {
            try
            {
                using (peliculaEntities conexion = new peliculaEntities())
                {

                    var consulta=(from a in conexion.tabla_peliculas where a.id == Id select a).FirstOrDefault();
                    if (consulta != null)
                    {
                        conexion.tabla_peliculas.Remove(consulta);
                        conexion.SaveChanges();
                        return true;

                    }else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
        #endregion
    }
}
