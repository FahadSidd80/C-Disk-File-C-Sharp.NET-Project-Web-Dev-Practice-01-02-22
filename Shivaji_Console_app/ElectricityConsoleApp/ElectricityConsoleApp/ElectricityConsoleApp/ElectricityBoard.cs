using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Security.Principal;
using System.Data;

namespace ElectricityConsoleApp
{
    public class ElectricityBoard
    {
        //Implement the property as per the description

        //Implement the methods as per the description   
       // public OleDbConnection oleconn { get; set; }

        public ElectricityBoard() { }
        DBHandler db  = new DBHandler();
        ElectricityBill selectebill = new ElectricityBill();


      
        public int AddBill(ElectricityBill ebill)
        {
                string queryInsert = $"insert into ElectricityBill(consumer_number, consumer_name, units_consumed,bill_amount) values('" + ebill.ConsumerNumber + "', '" + ebill.ConsumerName + "', " + ebill.UnitsConsumed + "," + ebill.BillAmount + ")";
                OleDbCommand cmd = new OleDbCommand(queryInsert);
                return db.ExecuteNonQuery(cmd);
            
            
        }



        public void CalculateBill(ElectricityBill ebill)
        {
            if (ebill.UnitsConsumed <= 100)
                ebill.BillAmount = 0;
            else if (ebill.UnitsConsumed > 100 && ebill.UnitsConsumed <= 300)
            {
                int temp = ebill.UnitsConsumed - 100;
                ebill.BillAmount = temp * 1.5;
            }
            else if (ebill.UnitsConsumed > 300 && ebill.UnitsConsumed <= 600)
            {
                int temp200 = ebill.UnitsConsumed - 100;
                int temp300 = temp200 - 200;
                ebill.BillAmount = (200 * 1.5) + (temp300 * 3.5);
            }
            else if (ebill.UnitsConsumed > 600 && ebill.UnitsConsumed <= 1000)
            {
                int temp200 = ebill.UnitsConsumed - 100;
                int temp400 = temp200 - 500;

                ebill.BillAmount = (200 * 1.5) + (300 * 3.5) + (temp400 * 5.5);
            }
            else if (ebill.UnitsConsumed > 1000)
            {

                int temp200 = ebill.UnitsConsumed - 100;
                int temp400 = temp200 - 900;

                ebill.BillAmount = (200 * 1.5) + (300 * 3.5) + (400 * 5.5) + (temp400 * 7.5);
            }
        }


        public DataTable SelectQuery(ElectricityBill ebill)
        {
            //string querystring = "Select * from(select * from ElectricityBill ORDER BY consumer_number desc)ElectricityBill2 where rownum<=" + ebill;
            string querystring = "select * from ElectricityBill ORDER BY consumer_number";
            OleDbCommand cmd = new OleDbCommand(querystring);
            return db.ExecuteReader(cmd);


        }


        public List<ElectricityBill> Generate_N_BillDetails(int num)
        {
            try
            {
                //string querystring = "Select * from(select * from ElectricityBill ORDER BY consumer_number desc)ElectricityBill2 where rownum<=" + num;
                //string querystring = "Select * from ElectricityBill order by consumer_number desc";
                // OleDbCommand cmd = new OleDbCommand(querystring);
                DataTable ds = SelectQuery(selectebill);
               // OleDbDataReader reader = ds;


                List<ElectricityBill> l1 = new List<ElectricityBill>();

                foreach(DataRow dr in ds.Rows)
                {
                    ElectricityBill eb1 = new ElectricityBill();
                    eb1.ConsumerNumber = dr[0].ToString();
                    eb1.ConsumerName = dr[1].ToString();
                    eb1.UnitsConsumed = Convert.ToInt32(dr[2]);
                    eb1.BillAmount = Convert.ToDouble(dr[3]);
                    l1.Add(eb1);
                }
                //while (reader.Rows.Count()>0)
                //{
                //    ElectricityBill eb1 = new ElectricityBill();
                //    eb1.ConsumerNumber = reader[0].ToString();
                //    eb1.ConsumerName = reader[1].ToString();
                //    eb1.UnitsConsumed = Convert.ToInt32(reader[2]);
                //    eb1.BillAmount = Convert.ToDouble(reader[3]);
                //    l1.Add(eb1);
                //}

               // oleconn.Close();
                return l1;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error 1: " + e.Message);
            }
            return null;
        }
    }
}

