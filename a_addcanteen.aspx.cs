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
    public partial class a_addcanteen : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "yes")
            {
                Response.Redirect("a_addcanteen.aspx");
            }
            if (Session["Add"] == "Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Student details added and Login credentails sent via mail');", true);
                Session["Add"] = "";
            }
            if (!IsPostBack)
            {
                Random r = new Random();
                int pass = r.Next(1000, 9999);
                string id = "101";
                string m = "SELECT TOP 1 c_id from canteen_detail Order By c_id Desc";
                SqlCommand cmd = new SqlCommand(m, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    int ids = Convert.ToInt32(dr[0].ToString());
                    ids++;
                    id = "" + ids;
                }
                else
                {
                    id = "101";
                }
                conn.Close();
                TextBox1.Text = id;
                TextBox2.Text = pass.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (m_TextBox1.Text != "")
            {
                if (h_TextBox2.Text != "")
                {
                    if (mo_TextBox3.Text != "")
                    {
                        if (wo_TextBox4.Text != "")
                        {
                            if (bal_TextBox3.Text != "")
                            {
                                string data1 = "INSERT INTO canteen_detail VALUES('" + TextBox1.Text + "','" + m_TextBox0.Text + "','" + m_TextBox1.Text + "','" + h_TextBox2.Text + "','" + mo_TextBox3.Text + "','" + wo_TextBox4.Text + "','" + bal_TextBox3.Text + "','" + TextBox2.Text + "')";
                                SqlCommand cmd = new SqlCommand(data1, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                Session["Add"] = "Data";
                                Response.Redirect("a_addcanteen.aspx");
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Amount');", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Number Of Worker.');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Mobile Number.');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Handler's Name.');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Manage Name.');", true);
            }
        }
    }
}
