using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace Web_Dev_ASP.NET_CRUD
{
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            DisplayGrid();
            DisplayCity();
            DisplayBloodgroup();
        }

      

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Save")
            {
                string blod = "";
                for (int i = 0; i < cblbloodgroup.Items.Count; i++)
                {
                    if (cblbloodgroup.Items[i].Selected == true)
                    { 
                        blod += cblbloodgroup.Items[i].Text +",";
                    }
                }
                blod = blod.TrimEnd(',');

                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Insert_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                cmd.Parameters.AddWithValue("@bloodgroup", blod);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            else if(btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Update_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", ViewState["Updt"] );
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@city", ddlcity.SelectedValue);
                //cmd.Parameters.AddWithValue("@bloodgroup", cblbloodgroup.);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                DisplayGrid();
            } 
            
        }
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id",e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                DisplayGrid();

            }
            else if (e.CommandName == "Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                ddlcity.SelectedValue = dt.Rows[0]["city"].ToString();
                cblbloodgroup.SelectedValue = dt.Rows[0]["bloodgroup"].ToString();
                btnsave.Text = "Update";
                ViewState["Updt"] = e.CommandArgument;
           
            }
        }


        public void DisplayGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Student_Display", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        public void DisplayCity()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_City_Display", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcity.DataValueField = "ctid";
            ddlcity.DataTextField = "ctname";
            ddlcity.DataSource = dt;
            ddlcity.DataBind();
        }

        public void DisplayBloodgroup()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Bloodgroup_Display", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            cblbloodgroup.DataValueField = "bid";
            cblbloodgroup.DataTextField = "banme";
            cblbloodgroup.DataSource = dt;
            cblbloodgroup.DataBind();
        }

       
    }
}