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
    public partial class LibraryForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["lmn"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DisplayGrid();
                DisplaySubject();
                DisplayDepartment();
            }
            
        }
        public void Clear()
        {
            txtname.Text = "";
            txtage.Text = "";
            txtrollno.Text = "";
            rblgender.ClearSelection();
            ddlsubject.SelectedValue = "0";
            ddldepartment.SelectedValue = "0";
            btnsave.Text = "Save";
        }

        public void DisplayGrid()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Library_Get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        public void DisplaySubject()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tblsubject_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new  DataTable();
            da.Fill(dt);
            con.Close();
            ddlsubject.DataValueField = "sid";
            ddlsubject.DataTextField = "sname";
            ddlsubject.DataSource = dt;
            ddlsubject.DataBind();
            ddlsubject.Items.Insert(0, new ListItem("--Select--","0"));
        }

        public void DisplayDepartment()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_tbldepartment_get", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            ddldepartment.DataValueField = "did";
            ddldepartment.DataTextField = "dname";
            ddldepartment.DataSource = dt;
            ddldepartment.DataBind();
            ddldepartment.Items.Insert(0, new ListItem("--Select--","0"));
        }
        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName=="Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Library_delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@did", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Library_edit", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@eid", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txtrollno.Text = dt.Rows[0]["rollno"].ToString();
                rblgender.SelectedValue = dt.Rows[0]["gender"].ToString();
                ddlsubject.SelectedValue = dt.Rows[0]["subject"].ToString();
                ddldepartment.SelectedValue = dt.Rows[0]["department"].ToString();
                btnsave.Text = "Update";
                ViewState["IDD"] = e.CommandArgument;
              
            }
           
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text=="Save") 
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Library_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@subject", ddlsubject.SelectedValue);
                cmd.Parameters.AddWithValue("@department", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@rollno", txtrollno.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
                Clear();
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Library_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@uid", ViewState["IDD"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.Parameters.AddWithValue("@gender", rblgender.SelectedValue);
                cmd.Parameters.AddWithValue("@subject", ddlsubject.SelectedValue);
                cmd.Parameters.AddWithValue("@department", ddldepartment.SelectedValue);
                cmd.Parameters.AddWithValue("@rollno", txtrollno.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                DisplayGrid();
                Clear();
            }
        
        }
    }
}