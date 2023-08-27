using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp_ADO_CRUD_29_02_22
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
            DisplayBloodgroup();
            DisplayCourse();
        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Registration_Get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grd.DataSource=dt;
            grd.DataBind();
            con.Close();
        }

        public void DisplayBloodgroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Tbl_bloodgroup_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rblbg.DataValueField = "bid";
            rblbg.DataTextField = "bname";
            rblbg.DataSource = dt;
            rblbg.DataBind();
            con.Close();
        }

        public void DisplayCourse()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_course_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlcourse.DataValueField = "cid";
            ddlcourse.DataTextField = "cname";
            ddlcourse.DataSource = dt;
            ddlcourse.DataBind();
            con.Close();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Registration_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@bloodgroup", rblbg.SelectedValue);
            cmd.Parameters.AddWithValue("@course", ddlcourse.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
            Display();
        }
    }
}