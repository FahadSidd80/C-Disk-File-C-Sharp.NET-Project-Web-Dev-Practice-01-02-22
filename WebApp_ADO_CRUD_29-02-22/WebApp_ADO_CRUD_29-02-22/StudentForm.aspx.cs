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
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["abc"].ConnectionString);
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void Clear()
        {
            btnsave.Text = "Save";
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            txtmobile.Text = "";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_student_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            else if(btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_student_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["abc"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            
        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_student_Get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

  

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_student_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if(e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_student_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txtmobile.Text = dt.Rows[0]["mobileno"].ToString();
                btnsave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;
                con.Close();
                
            }
        }

      
    }
}