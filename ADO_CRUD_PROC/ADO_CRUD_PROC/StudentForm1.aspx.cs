using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ADO_CRUD_PROC
{
    public partial class StudentForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(btnsave.Text=="Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();

            }
            else
            {

            }
           

        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
        }



        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Student_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();

        }
    }
}