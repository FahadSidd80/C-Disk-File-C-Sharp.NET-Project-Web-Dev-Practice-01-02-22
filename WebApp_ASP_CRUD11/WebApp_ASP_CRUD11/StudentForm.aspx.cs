using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace WebApp_ASP_CRUD11
{
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
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

        public void Clear()
        {
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            btnsave.Text = "Submit";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            else if (btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["xyz"]);
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
            if (e.CommandName == "Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display(); 
            }
            else if(e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
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