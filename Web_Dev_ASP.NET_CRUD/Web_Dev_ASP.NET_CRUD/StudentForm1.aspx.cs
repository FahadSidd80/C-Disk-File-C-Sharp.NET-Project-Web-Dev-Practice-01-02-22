using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Web_Dev_ASP.NET_CRUD
{
    public partial class StudentForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr2"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayCity();
            DisplayHobbies();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_proc_Insert_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name",txtname.Text);
            cmd.Parameters.AddWithValue("@city",ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@age",txtage.Text);
            cmd.Parameters.AddWithValue("@rollno",txtrollno.Text);
            cmd.Parameters.AddWithValue("@gender",rblgender.SelectedValue);
            cmd.Parameters.AddWithValue("@hobbies",cblhobbies.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void DisplayCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Select_tbl_city", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "ctid";
            ddlcity.DataTextField = "ctname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();

        }
        public void DisplayHobbies()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_hobbies_select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblhobbies.DataValueField = "hid";
            cblhobbies.DataTextField = "hname";
            cblhobbies.DataSource = dt;
            cblhobbies.DataBind();

        }
    }
}