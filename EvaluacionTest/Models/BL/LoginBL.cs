using EvaluacionTest.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionTest.Models.BL
{
    public class LoginBL
    {
        LoginDAL dal = new LoginDAL();
        public int verifyUserAndPassword(string usuario, string password)
        {
            int response;
            if (dal.verifyUserAndPassword(usuario, password).ToString().Length > 0)
            {
                response = dal.verifyUserAndPassword(usuario, password);
            }
            else {
                response = 0;
            }
            return response;
        }

        public string setLog(int id) {
            string response;
            if (dal.setLog(id).Equals("OK"))
            {
                response = "Bienvenido!!";
            }
            else if (dal.setLog(id).Equals("NO OK"))
            {
                response = "Usuario existe pero no se registro en base log";
            }
            else {
                response = "No existe usuario enviado";
            }
            return response;
        }

        public List<ChartModel> getLog(int id) {
            if (dal.getLog(id).Count > 0) {
                return dal.getLog(id);
            }
            return null;
        }
    }
}