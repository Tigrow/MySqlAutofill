using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System;
using System.Data;

namespace PrilaguXa
{
    static class SqlAdapter
    {
        static string connStr;

        public static bool IsConnect(string con)
        {
            bool connected;
            try
            {
                MySqlConnection mcon = new MySqlConnection(con);
                mcon.Open();                
                mcon.Close();
                connected = true;
                connStr = con;
            }
            catch (Exception)
            {
                connected = false;   
            }
            return connected;
        }
        public static List<string> GetTabels()
        {
            List<string> tabels = new List<string>();
            try
            {
                MySqlConnection mcon = new MySqlConnection(connStr);
                mcon.Open();

                MySqlCommand cmd = new MySqlCommand("SHOW TABLES", mcon);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tabels.Add(reader.GetString(0));
                }
                mcon.Close();
            }
            catch (Exception)
            {
                //
            }
            return tabels;
        }
        public static DataSet GetTabel(string nameTabel)
        {
            DataSet ds = new DataSet();

            try
            {
                MySqlConnection mcon = new MySqlConnection(connStr);
                mcon.Open();

                MySqlDataAdapter mda = new MySqlDataAdapter("select * from "+nameTabel, mcon);
                mda.Fill(ds, nameTabel);
                
                mcon.Close();
            }
            catch (Exception)
            {
                //
            }

            return ds;
        }
    }
}
