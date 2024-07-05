using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoSM.AccesoDatos;
using System.Collections;

namespace CursoSM.LogicaNegocio
{
    public class CtrlRestaurante
    {
        RESERVAMEEntities1 DBContext = new RESERVAMEEntities1();

        /*Lista de restaurantes*/
        public IList ListaRestaurantes()
        {
            try
            {
                var query = (from c in DBContext.RESTAURANTE
                             orderby c.Nombre
                             select new
                             {
                                 Nombre = c.Nombre,
                                 Direccion = c.Direccion,
                                 Telefono = c.Telefono
                             }
                             ).Take(10).ToList();
                return query;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}
