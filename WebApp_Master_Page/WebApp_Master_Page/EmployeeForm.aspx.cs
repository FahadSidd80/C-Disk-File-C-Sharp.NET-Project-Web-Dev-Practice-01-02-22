using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApp_Master_Page
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            DisplayGrid();
            DisplayBloodGroup();
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

        public void DisplayBloodGroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tbl_bloodgroup_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            rblbg.DataValueField = "bid";
            rblbg.DataTextField = "bname";

        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Employee_Insert", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@name", txtname.Text);
            cmd.Parameters.AddWithValue("@age", txtage.Text);
            cmd.Parameters.AddWithValue("@bloodgroup", rblbg.SelectedValue);
            cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
            cmd.Parameters.AddWithValue("@state", ddlstate.SelectedValue);
            cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }
    }
}