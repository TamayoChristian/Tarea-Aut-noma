using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursoSM.LogicaNegocio;
using System.Collections;
using System.Web.Services;

namespace WebApp1
{
    public partial class postdata : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        [WebMethod]
        public static IList BuscarUsuario(string pFullname)
        {
            try
            {
                CtrlUsuarios negocio = new CtrlUsuarios();
                return negocio.BuscarUsario(pFullname);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static int RegistrarUsuario(string pUsername, string pPassword, string pFullname, string pCelular, string pEmail, DateTime pFechaNac)
        {
            try
            {
                CtrlUsuarios negocio = new CtrlUsuarios();
                return negocio.RegistrarUsuario(pUsername, pPassword, pFullname, pCelular, pEmail, pFechaNac);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}