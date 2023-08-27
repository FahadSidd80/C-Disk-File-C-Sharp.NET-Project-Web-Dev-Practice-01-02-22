using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApp_ADO_CRUD_29_02_22
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Employee_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();
            con.Close();
        }
        public void Clear()
        {
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            btnsave.Text = "Save";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ViewState["xyz"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();

            }
           

        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                grd.DataSource = dt;
                grd.DataBind();
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                btnsave.Text = "Update";
                ViewState["xyz"] = e.CommandArgument;
            }
        }
    }
}