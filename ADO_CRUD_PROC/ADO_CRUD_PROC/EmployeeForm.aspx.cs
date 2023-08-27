using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


namespace ADO_CRUD_PROC
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LTIN254607; initial catalog=DBADOPROC1; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(btnsave.Text=="Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_insert_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                CLear();
            }
            else if (btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_update_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["abc"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@mobile", txtmobile.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                CLear();
            }
      

        }

        public void CLear()
        {
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            txtmobile.Text = "";
            btnsave.Text = "Save";

        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_get_employee", con);
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
            if(e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if(e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_edit_employee", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid",e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txtmobile.Text = dt.Rows[0]["mobile"].ToString();
                btnsave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;

            }
           
        }
    }
}