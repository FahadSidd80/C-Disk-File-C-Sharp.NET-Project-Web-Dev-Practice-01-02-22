using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Master_Page_With_Login
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGrid();
            DisplayBloodgroup();
        }

        public void DisplayBloodgroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_Bloodgroup_Select", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblbg.DataValueField = "bid";
            rblbg.DataTextField = "bname";
            rblbg.DataSource = dt;
            rblbg.DataBind();
        }
        public void DisplayGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Employee_get", con);
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
            SqlCommand cmd = new SqlCommand("sp_Employee_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@age", txtage.Text);
            cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
            cmd.Parameters.AddWithValue("@bloodgroup", rblbg.SelectedValue );
            cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue );
            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
            cmd.Parameters.AddWithValue("@email", txtemail.Text);
            cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            

        }
    }
}