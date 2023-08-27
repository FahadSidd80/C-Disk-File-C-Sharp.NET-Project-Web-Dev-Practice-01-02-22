﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ADO_CRUD_PROC
{
    public partial class StudentForm : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection("data source=LTIN254607; initial catalog=SINGLEPROC; integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Display();
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (btnsave.Text == "Save")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Insert");
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                CLear();
            }
            else if (btnsave.Text == "Update")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Update");
                cmd.Parameters.AddWithValue("@id", ViewState["abc"]);
                cmd.Parameters.AddWithValue("@name", txtname.Text);
                cmd.Parameters.AddWithValue("@age", txtage.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
                CLear();
            }

        }

        public void CLear()
        {
            txtname.Text = "";
            txtage.Text = "";
            btnsave.Text = "Save";

        }
        public void Display()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Student", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@action", "Get");
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
                SqlCommand cmd = new SqlCommand("sp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Delete");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                cmd.ExecuteNonQuery();
                con.Close();
                Display();
            }
            else if (e.CommandName == "Edt")
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("sp_Student", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@action", "Edit");
                cmd.Parameters.AddWithValue("@id", e.CommandArgument);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                con.Close();
                txtname.Text = dt.Rows[0]["name"].ToString();
                txtage.Text = dt.Rows[0]["age"].ToString();
                btnsave.Text = "Update";
                ViewState["abc"] = e.CommandArgument;

            }
        }
    }
}