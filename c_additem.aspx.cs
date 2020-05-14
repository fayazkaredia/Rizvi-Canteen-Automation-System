using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Canteen_Automation_System
{
    public partial class c_additem : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=43.255.152.26;Initial Catalog=ACanteen;Persist Security Info=True;User ID=ACanteen;Password=Do5oe2#5");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["canteen"] != "yes")
            {
                Response.Redirect("MainLogin.aspx");
            }
            if(Session["Add"]=="Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Food Item details added');", true);
                Session["Add"] = "";
            }

            string id = "301";
            string m = "SELECT TOP 1 id from item_detail Order By id Desc";
            SqlCommand cmd1 = new SqlCommand(m, conn);
            conn.Open();
            SqlDataReader dr = cmd1.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                int ids = Convert.ToInt32(dr[0].ToString());
                ids++;
                id = "" + ids;
            }
            else
            {
                id = "301";
            }
            conn.Close();
            id_TextBox3.Text = id;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (food_TextBox3.Text != "")
            {
                if (des_TextBox3.Text != "")
                {
                    if (cost_TextBox1.Text != "")
                    {
                        if (time_TextBox3.Text != "")
                        {
                            string er="enable";
                            string s = "INSERT INTO item_detail VALUES('" + id_TextBox3.Text + "','" + food_TextBox3.Text + "','" + des_TextBox3.Text + "','" + cost_TextBox1.Text + "','" + time_TextBox3.Text + "','" + er + "')";
                            SqlCommand cmd = new SqlCommand(s,conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Session["Add"] = "Data";
                            Response.Redirect("c_additem.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Time required for food to get Ready');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Cost field cannot be left blank');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Description field cannot be left blank.');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Item Name field cannot be left blank');", true);
            }
        }
    }
}