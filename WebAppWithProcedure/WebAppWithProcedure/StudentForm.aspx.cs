using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebAppWithProcedure
{
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LTIN254607; initial catalog=DBPROCEDURE; integrated security= true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        public void clear()
        {
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            txtrollno.Text = "";
            btnsave.Text = "Submit";
        }

        

        protected void tbtnsave_Click(object sender, EventArgs e)
        {
            if(btnsave.Text=="Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Insert_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@city", txtcity.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("rollno", txtrollno.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                clear();
            }
            else if(btnsave.Text== "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Update_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["Updt"]);
                cmd.Parameters.AddWithValue("@name",txtname.Text);
                cmd.Parameters.AddWithValue("@city",txtcity.Text);
                cmd.Parameters.AddWithValue("@age",txtage.Text);
                cmd.Parameters.AddWithValue("@rollno",txtrollno.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                clear();
            }
            

        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_delete_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@sid", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if(e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new  SqlCommand("sp_edit_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txtrollno.Text = dt.Rows[0]["rollno"].ToString();
                btnsave.Text = "Update";
                ViewState["Updt"] = e.CommandArgument;


            }
           
        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_get_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();


        }



    }
}