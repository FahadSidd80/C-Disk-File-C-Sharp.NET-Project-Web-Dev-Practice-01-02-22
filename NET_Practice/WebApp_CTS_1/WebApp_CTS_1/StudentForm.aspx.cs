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
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["xyz"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGrid();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Insert_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@rollno", txtrollno.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
                ClearTextValue();
            }
            else if (btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Update_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["xyz"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@mobileno", txtmobile.Text);
                cmd.Parameters.AddWithValue("@country", txtcountry.Text);
                cmd.Parameters.AddWithValue("@dob", txtdob.Text);
                cmd.Parameters.AddWithValue("@rollno", txtrollno.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
                ClearTextValue();
            }
            
            
        }

        public void DisplayGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Display_Student", con);
            cmd.CommandType=CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            grd.DataSource = dt;
            grd.DataBind();
            con.Close();

        }

        public  void ClearTextValue()
        {
            txtname.Text = "";
            txtage.Text = "";
            txtcity.Text = "";
            txtmobile.Text = "";
            txtcountry.Text = "";
            txtdob.Text = "";
            txtrollno.Text = "";
            btnsave.Text = "Submit";
            
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Delete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            else if (e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Edit_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtname.Text=dt.Rows[0][1].ToString();
                txtage.Text=dt.Rows[0]["age"].ToString();
                txtcity.Text =dt.Rows[0]["city"].ToString();
                txtmobile.Text = dt.Rows[0]["mobileno"].ToString();
                txtcountry.Text = dt.Rows[0]["country"].ToString();
                txtdob.Text = dt.Rows[0]["dob"].ToString();
                txtrollno.Text = dt.Rows[0]["rollno"].ToString();
                con.Close();
                btnsave.Text = "Update";
                ViewState["xyz"] = e.CommandArgument;
                
            }
            
        }
    }
}