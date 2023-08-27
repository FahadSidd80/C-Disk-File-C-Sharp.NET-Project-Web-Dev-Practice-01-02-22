using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace WebAppEdit
{
    public partial class EmployeeForm : System.Web.UI.Page
    {
        
        SqlConnection con = new SqlConnection("Data source=LTIN254607; initial catalog=DPADO232022; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Clear()
        {
            txtname.Text = "";
            txtage.Text = "";
            txtcity.Text = "";
            btnsave.Text = "Submit";
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Employee(name,age,city)values('" + txtname.Text + "','" + txtage.Text + "','" + txtcity.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            else if(btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update Employee set name='"+txtname.Text+"',age='"+txtage.Text+"',city='"+txtcity.Text+"' where id='"+ ViewState["abc"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }

        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Employee ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Employee where id='" + e.CommandArgument + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if(e.CommandName == "Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Employee where id='" + e.CommandArgument + "' ", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text= dt.Rows[0][1].ToString();
                txtage.Text= dt.Rows[0][2].ToString();
                txtcity.Text= dt.Rows[0][3].ToString();
                btnsave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;
                
            }
           
        }
    }
}