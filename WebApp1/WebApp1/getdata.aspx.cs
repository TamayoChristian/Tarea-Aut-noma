using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CursoSM.LogicaNegocio;
using System.Web.Script.Serialization;

namespace WebApp1
{
    public partial class getdata : System.Web.UI.Page
    {
        public string retVal = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();

            if (!IsPostBack)
            {
                try
                {
                    string usuario = Request.Params["usuario"].ToString();

                    if (usuario != null)
                    {
                        CtrlUsuarios negocio = new CtrlUsuarios();
                        string fullname = negocio.getFullName(usuario);

                        if (fullname != "")
                        {
                            retVal = "[{\"id\":\"1\",\"fullname\":\"" + fullname + "\"}]";
                        }
                        else
                        {
                            retVal = "{{\"id\":\"1\",\"fullname\":\"El usuario + usuario + no existe.\"}]";
                        }

                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                    retVal = "ERROR PARAMS";
                }
            }
        }
    }
}