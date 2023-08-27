using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Web_ASP_CRUD_Query
{
    public partial class RegistrationForm : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("data source=LTIN254607; initial catalog=DBADOCRUD; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
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
            if(btnsave.Text== "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Registration(name,city,age)values('" + txtname.Text + "','" + txtcity.Text + "','" + txtage.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            else if(btnsave.Text=="Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update registration set name='"+txtname.Text+"', city='"+txtcity.Text+"', age='"+txtage.Text+"' where rid='"+ ViewState["Updt"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear(); 
            }
           

        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Registration", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName=="del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Registration where rid = '" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if(e.CommandName=="Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from registration where rid = '"+e.CommandArgument+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                btnsave.Text = "Update";
                ViewState["Updt"] = e.CommandArgument;

            }
           
        }
    }
}