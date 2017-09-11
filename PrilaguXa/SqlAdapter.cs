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
            //"CREATE TABLE animals(id MEDIUMINT NOT NULL AUTO_INCREMENT,name CHAR(30) NOT NULL, PRIMARY KEY(id));"
            return ds;
        }
        public static string AddRow(string tabelName, List<string> NameColumn, List<string> NameRow)
        {
            string s1, s2,error;
            s1 = "INSERT INTO `DataBasa`.`"+tabelName + "`(";
            s2 = " VALUES(";
            for (int i = 0; i < NameColumn.Count; i++)
            {
                if (i != 0)
                {
                    s1 = s1 + ",";
                    s2 = s2 + ",";
                }
                s1 = s1 + "`" + NameColumn[i] + "`";
                s2 = s2 + "'" + NameRow[i] + "'";
            }
            error = "GOOD";
            string Command = s1 + ")" + s2 + ")";
                try
                {
                MySqlConnection mcon = new MySqlConnection(connStr);
                mcon.Open();

                MySqlCommand cmd = new MySqlCommand(Command, mcon);
                cmd.ExecuteNonQuery();

                mcon.Close();

                }
                catch (Exception)
                {
                error = Command;
                    Console.WriteLine("Count not insert.");
                }
            return error;
        }
        public static void NewTabel(string name,string[] rows)
        {
            string Command = "CREATE TABLE " + name + "(id MEDIUMINT NOT NULL AUTO_INCREMENT";
            for (int i = 0; i < rows.Length; i++)
            {
                Command = Command + "," + rows[i] + " CHAR(30) NOT NULL";
            }
            Command = Command + ");";
            try
            {
                MySqlConnection mcon = new MySqlConnection(connStr);
                mcon.Open();
                MySqlCommand cmd = new MySqlCommand(Command, mcon);
                cmd.ExecuteNonQuery();
                mcon.Close();
            }
            catch (Exception)
            {
                //
            }
        }
    }
}
