using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace ElectricityConsoleApp
{
    public class DBHandler
    {
        //Implement the methods as per the description
        public DBHandler() { }
      public  OleDbConnection conn = new OleDbConnection (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\2101917\Downloads\ElectricityConsoleApp\ElectricityConsoleApp\ElectricityConsoleApp\bin\Debug\DB_ElectrictConsole.accdb");
        public OleDbConnection GetConnection()
        {
            
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                return conn;
            


//            OleDbConnection con = new OleDbConnection();
            //  String Connection = DBConnection.connStr;
   //         string Connection = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\2101811\source\repos\ElectricityConsoleApp\ElectricityConsoleApp\bin\Debug\DB_ElectrictConsole.accdb";
     //       con = new OleDbConnection(Connection);
       //     return con;
        }
        public int ExecuteNonQuery(OleDbCommand cmd)
        {
            cmd.Connection = GetConnection();
            int num;
            num = cmd.ExecuteNonQuery();
            conn.Close();
            return num;
        }
        public DataTable ExecuteReader(OleDbCommand cmd)
        {
            cmd.Connection = GetConnection();
            OleDbDataReader dr;
            DataTable dt = new DataTable();
            dr = cmd.ExecuteReader();
            dt.Load(dr);
            conn.Close();
            return dt;
        }
    }
}
