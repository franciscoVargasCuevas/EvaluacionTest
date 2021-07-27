using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvaluacionTest.Models.DAL
{
    public class LoginDAL
    {

        public int verifyUserAndPassword(string usuario, string password) {
            LoginModel modelo = new LoginModel();
            using (var context = new EvaluacionTecnicaEntities4())
            {
                var response = context.LOGIN_PRINCIPAL(usuario, password);
                
                foreach(var lm in response)
                {
                     modelo.id = lm.Value;
                }
            }
            return modelo.id;
        }

        public string setLog(int id)
        {
            LogModel log = new LogModel();
            using (var context = new EvaluacionTecnicaEntities4())
            {
                var response = context.LOG_USER(id);

                foreach (var lm in response)
                {
                    log.res = lm;
                }
            }
            return log.res;
        }

        public List<ChartModel> getLog(int id)
        {
            using (var context = new EvaluacionTecnicaEntities4())
            {
                var response = context.GET_LOG(id);
                return response.Select(x => new ChartModel
                {
                    fecha = x.FECHA_REGISTRO,
                    nombre = x.USUARIO,
                }).ToList();
            }
        }
            
        

    }

    
}