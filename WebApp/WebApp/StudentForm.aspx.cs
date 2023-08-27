using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebApp
{
    public partial class StudentForm : System.Web.UI.Page
    {
        SqlConnection con= new SqlConnection("data source=LTIN254607; initial catalog=DBADOPROC; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }
        public void Clear()
        {
            txtname.Text = "";
            txtcity.Text = "";
            txtage.Text = "";
            txtrollno.Text = "";
            btnsave.Text = "Submit";

                
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if(btnsave.Text=="Submit")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Student(name,city,age,rollno)values('" + txtname.Text + "','" + txtcity.Text + "','" + txtage.Text + "','" + txtrollno.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("update student set name = '"+txtname.Text+"',city='"+txtcity.Text+"', age = '"+txtage.Text+"',rollno = '"+txtrollno.Text+"' where id='"+ ViewState["Upd"] + "'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                Clear();
            }
           
        }

        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            grd.DataSource = dt;
            grd.DataBind();
        }

        protected void grd_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from student where id='"+e.CommandArgument+"'", con);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if(e.CommandName== "Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from student where id='"+e.CommandArgument+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtcity.Text = dt.Rows[0]["city"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                txtrollno.Text = dt.Rows[0]["rollno"].ToString();
                btnsave.Text = "Update";
                ViewState["Upd"] = e.CommandArgument;
            }
        }
    }
}