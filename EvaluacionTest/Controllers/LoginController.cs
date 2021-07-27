using EvaluacionTest.Models.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EvaluacionTest.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string usuario, string password)
        {
            LoginBL bl = new LoginBL();
            int compare = bl.verifyUserAndPassword(usuario, password);
            if (compare > 0)
            {
                Session["id"] = compare;
                string logResponse = bl.setLog(compare);
                return Content("<script language='javascript' type='text/javascript'>alert('" + logResponse + "');location.href='VisualizarLog';</script>");
            }
            else {
                return Content("<script language='javascript' type='text/javascript'>alert('Usuario o pass incorrecto');location.href='/Login/Index';</script>");
            }
            return View();
        }

        public ActionResult VisualizarLog()
        {
            LoginBL bl = new LoginBL();
            if(Session["id"] == null)
            {
                return Content("<script language='javascript' type='text/javascript'>alert('No tienes sesión para acceder');location.href='/Home/Index';</script>");
            }
            var data = bl.getLog(Convert.ToInt32(Session["id"]));
            List<DateTime> fecha = new List<DateTime>();
            fecha = data.Select(d => d.fecha).ToList();
            List<string> collection = new List<string>();
            foreach (var item in fecha) {
                collection.Add(Convert.ToString(item));

            }
            ViewBag.FECHA = collection;
            return View(data);

        }


    }
}
