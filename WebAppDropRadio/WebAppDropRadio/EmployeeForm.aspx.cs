using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebAppDropRadio
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["pqr"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayGridView();
                DisplayCourse();
                DisplayCountry();
            }
      
        }
        public void Clear()
        {
            txtname.Text = "";
            txtage.Text = "";
            rblgender.ClearSelection();
            ddlcourse.SelectedValue = "0"; 
            ddlcountry.SelectedValue = "0";
            btnsave.Text = "Save";
        }

        public void DisplayGridView()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Employee_Get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
           
        }
        public void DisplayCourse()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblCourse_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcourse.DataValueField = "cid";
            ddlcourse.DataTextField = "cname";
            ddlcourse.DataSource= dt;
            ddlcourse.DataBind();
            ddlcourse.Items.Insert(0, new ListItem("--Select--","0"));
        }


        public void DisplayCountry()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblcountry_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddlcountry.DataValueField = "cnid";
            ddlcountry.DataTextField = "cnname";
            ddlcountry.DataSource = dt;
            ddlcountry.DataBind();
            ddlcountry.Items.Insert(0, new ListItem("--Select--","0"));
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Save") 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@course", ddlcourse.SelectedValue);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGridView();
                Clear();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["IDD"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@course", ddlcourse.SelectedValue);
                cmd.Parameters.AddWithValue("@country", ddlcountry.SelectedValue);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGridView();
                Clear();
            }
          
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="D")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGridView();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Employee_Edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                rblgender.Text = dt.Rows[0]["gender"].ToString();
                ddlcourse.SelectedValue = dt.Rows[0]["course"].ToString();
                ddlcountry.SelectedValue = dt.Rows[0]["country"].ToString();
                btnsave.Text = "Update";
                ViewState["IDD"] = e.CommandArgument;
              
               
            }
           
        }
    }
}