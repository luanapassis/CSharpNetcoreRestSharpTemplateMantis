using System;
using System.Collections.Generic;
using System.Text;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.DBSteps
{
    public class DataBaseSteps : DBHelpers
    {
        DBHelpers dbHelpers = new DBHelpers();

        #region carga inicial
        public void cargaTabelaUsuario()
        {
            string consulta1 = string.Format(@"select username from mantis_user_mantis where username = 'usuario1'");
            List<string> resultado1 = dbHelpers.retornaDadosQuery(consulta1);
            if (resultado1 == null)
            {
                string query1 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario1', 'Teste','luana.assis1@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc68', 1574199190, 1574199190)");
                dbHelpers.executaQuery(query1);
            }

            string consulta2 = string.Format(@"select username from mantis_user_mantis where username = 'usuario2'");
            List<string> resultado2 = dbHelpers.retornaDadosQuery(consulta2);
            if (resultado2 == null)
            {
                string query2 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usuario2', 'Teste','luana.assis2@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc6L', 1574199190, 1574199190)");
                dbHelpers.executaQuery(query2);
            }

            string consulta3 = string.Format(@"select username from mantis_user_mantis where username = 'luana.assis'");
            List<string> resultado3 = dbHelpers.retornaDadosQuery(consulta3);
            if (resultado3 == null)
            {

                string query3 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('luana.assis', 'Luana Assis','luana.assis@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowjc7L', 1574199190, 1574199190)");
                dbHelpers.executaQuery(query3);
            }
            string consulta4 = string.Format(@"select username from mantis_user_mantis where username = 'usu.inativo'");
            List<string> resultado4 = dbHelpers.retornaDadosQuery(consulta4);
            if (resultado4 == null)
            {

                string query4 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('usu.inativo', 'Usuario inativo','usu.inativo@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 0, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjowsc7L', 1574199190, 1574199190)");
                dbHelpers.executaQuery(query4);
            }
            string consulta5 = string.Format(@"select username from mantis_user_mantis where email = 'alteraNome@gmail.com'");
            List<string> resultado5 = dbHelpers.retornaDadosQuery(consulta5);
            if (resultado5 == null)
            {

                string query5 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('testeAlteraNome', 'TesteAlteraNomeReal','alteraNome@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjokkc7L', 1574199190, 1574199190)");
                dbHelpers.executaQuery(query5);
            }
            string consulta6 = string.Format(@"select username from mantis_user_mantis where username = 'testeAPIDeletar'");
            List<string> resultado6 = dbHelpers.retornaDadosQuery(consulta6);
            if (resultado6 == null)
            {

                string query6 = string.Format(@" INSERT INTO mantis_user_mantis ( username, realname, email,
                PASSWORD, enabled, protected, access_level, login_count, lost_password_request_count, failed_login_count, cookie_string, last_visit, date_created)
                VALUES('testeAPIDeletar', 'testeAPIDeletarNomeReal','testeAPIDeletar@gmail.com', 'e10adc3949ba59abbe56e057f20f883e', 1, 0, 90, 1, 0, 0, 'JCIfQbZ9Wdq0eONcOMkSOR17wMSjokkk7L', 1574199190, 1574199190)");
                dbHelpers.executaQuery(query6);
            }
            //
        }
        #endregion

        public List<string> retornaTarefaAleatoria()
        {
            String query = "SELECT * from mantis_bug_mantis bm INNER join mantis_bug_text_mantis btm ON bm.id = btm.id ORDER BY RAND() LIMIT 1";
            List<String> resultado = dbHelpers.retornaListaDadosQuery(query);
            return resultado;
        }

        public string retornaidUsuario(string nome)
        {
            string consulta = string.Format(@"SELECT id FROM mantis_user_mantis where username = '{0}'", nome);
            List<string> resultado = dbHelpers.retornaDadosQuery(consulta);
            return resultado[0];
        }
    }
}
