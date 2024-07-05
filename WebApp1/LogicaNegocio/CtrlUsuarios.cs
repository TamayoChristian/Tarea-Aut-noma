using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CursoSM.AccesoDatos;
using System.Collections;

namespace CursoSM.LogicaNegocio
{
    public class CtrlUsuarios
    {
        RESERVAMEEntities1 DBContext = new RESERVAMEEntities1();

        public string getFullName(String pUsername)
        {
            try
            {
                var query = (from c in DBContext.USUARIO
                             where c.Username.Equals(pUsername)
                             select new
                             {
                                 Fullname = c.Fullname
                             }
                             ).FirstOrDefault();
                if(query == null)
                {
                    return "";
                }
                else
                {
                    return query.Fullname;
                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        public IList BuscarUsario(String pFullName)
        {
            try
            {
                var query = (from c in DBContext.USUARIO
                             where c.Fullname.Contains(pFullName)
                             orderby c.Fullname
                             select new
                             {
                                 cUsername = c.Username,
                                 cFullname = c.Fullname,
                                 cCelular = c.Celular,
                                 cEmail = c.Email,
                                 dFechaNac = c.FechaNac,
                             }
                             ).Take(10).ToList().Select(x => new
                             {
                                 cUsername = x.cUsername,
                                 cFullname = x.cFullname,
                                 cCelular = x.cCelular,
                                 cEmail = x.cEmail,
                                 dFechaNac = string.Format("{0:dd/MM/yyyy}", x.dFechaNac),
                             }
                             ).ToList();
                return query;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return null;
            }
        }
        public int RegistrarUsuario(string pUsername, string pPassword, string pFullname, string pCelular,  string pEmail, DateTime pFechaNac)
        {
            try
            {
                USUARIO query = new USUARIO();
                query.Username = pUsername;
                query.Password = pPassword;
                query.Fullname = pFullname;
                query.Celular = pCelular;
                query.Email = pEmail;
                query.FechaNac = pFechaNac;
                DBContext.USUARIO.Add(query);
                DBContext.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                return -1;
            }
        }

    }
}
