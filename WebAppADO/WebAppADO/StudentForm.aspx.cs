using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebAppADO
{
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source= LTIN254607; initial catalog=DBNET; integrated security= true ");
        protected void Page_Load(object sender, EventArgs e)
        {

            Display();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into student(name,city,age)values('"+txtname.Text+"','"+txtcity.Text+"','"+txtage.Text+"')",con);
            cmd.ExecuteNonQuery();
            con.Close();
            Display();

        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }



    }
}