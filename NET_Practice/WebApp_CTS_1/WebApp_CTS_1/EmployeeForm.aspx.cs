using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebApp_CTS_1
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGrid();
        }

        public void DisplayGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_DisplayGrid_Employee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();
            con.Close();

        }

        public void ClearText()
        {
            txtname.Text = "";
            txtage.Text = "";
            txtcity.Text = "";
            txtcountry.Text = "";
            txtdob.Text = "";
            txtmobile.Text = "";
            btnsave.Text = "Submit";
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Insert_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
                ClearText();
            }
            else if (btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Update_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["abc"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
                ClearText();
            }
            
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delet_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            else if (e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Edit_Employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtcountry.Text = dt.Rows[0]["country"].ToString();
                txtdob.Text = dt.Rows[0]["dob"].ToString();
                txtmobile.Text = dt.Rows[0]["mobileno"].ToString();
                con.Close();
                btnsave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;
            }
            
        }
    }
}