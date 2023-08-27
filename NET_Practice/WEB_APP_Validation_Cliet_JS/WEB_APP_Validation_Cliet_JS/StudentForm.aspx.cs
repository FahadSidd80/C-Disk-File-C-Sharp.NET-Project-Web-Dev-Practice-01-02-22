using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace WEB_APP_Validation_Cliet_JS
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGrid();
        }
        public void DisplayGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Student_Get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();         
            SqlCommand cmd = new SqlCommand("sp_Stdent_Insert", con);
            cmd.CommandType=CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",txtname.Text);
            cmd.Parameters.AddWithValue("@email",txtemail.Text);
            cmd.Parameters.AddWithValue("@password",txtpassword.Text);
            cmd.Parameters.AddWithValue("@cpassword",txtcpassword.Text);
            cmd.Parameters.AddWithValue("@salary",txtsalary.Text);
            cmd.Parameters.AddWithValue("@age",txtage.Text);
            cmd.Parameters.AddWithValue("@mobileno",txtmobile.Text);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
            DisplayGrid();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            else
            {

            }
               
          
           
        }
    }
}