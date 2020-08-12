using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace RestSharpNetCoreTemplate.Helpers
{
    public class DBHelpers
    {
        //private static SqlConnection GetDBConnection()
        //{
        //    string connectionString = "Data Source=" + Properties.Settings.Default.DB_URL + ";" +
        //                              "Initial Catalog=" + Properties.Settings.Default.DB_NAME + ";" +
        //                              "User ID=" + Properties.Settings.Default.DB_USER + "; " +
        //                              "Password=" + Properties.Settings.Default.DB_PASSWORD + ";";

        //    SqlConnection connection = new SqlConnection(connectionString);

        //    return connection;
        //}
        MySqlConnection conn = null;
        string connectionString = "Server=" + JsonBuilder.ReturnParameterAppSettings("DB_URL") +";" +
                                  "Port=" + JsonBuilder.ReturnParameterAppSettings("DB_PORT") +";" +
                                  "Database=" + JsonBuilder.ReturnParameterAppSettings("DB_NAME") +";" +
                                  "UID=" + JsonBuilder.ReturnParameterAppSettings("DB_USER") +"; " +
                                  "SslMode=" + JsonBuilder.ReturnParameterAppSettings("SSL_MODE");

        private MySqlConnection GetDBConnection()
        {
            try
            {
                return conn = new MySqlConnection(connectionString);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void executaQuery(String query)
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();


                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
            Console.WriteLine("Done.");
        }

        public List<string> retornaDadosQuery(String query)
        {
            conn = GetDBConnection();

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();


            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = Int32.Parse(JsonBuilder.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));
            conn.Open();
            MySqlDataReader rdr = cmd.ExecuteReader();



            DataTable table = new DataTable();
            table.Load(rdr);
            ds.Tables.Add(table);
            cmd.Connection.Close();

            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    lista.Add(ds.Tables[0].Rows[0][i].ToString());
                }
            }
            catch (Exception)
            {

                return null;
            }

            return lista;
        }


        public List<string> retornaListaDadosQuery(String query)
        {

            DataSet ds = new DataSet();
            List<string> lista = new List<string>();
            conn = GetDBConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.CommandTimeout = Int32.Parse(JsonBuilder.ReturnParameterAppSettings("DB_CONNECTION_TIMEOUT"));



            cmd.Connection.Open();

            MySqlDataReader rdr = cmd.ExecuteReader();
            DataTable table = new DataTable();
            table.Load(rdr);
            ds.Tables.Add(table);
            cmd.Connection.Close();


            if (ds.Tables[0].Columns.Count == 0)
            {
                return null;
            }

            try
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    for (int j = 0; j < ds.Tables[0].Columns.Count; j++)
                    {
                        lista.Add(ds.Tables[0].Rows[i][j].ToString());
                    }
                }

            }
            catch (Exception)
            {

                return null;
            }
            return lista;
        }
    }
}
