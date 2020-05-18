using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Canteen_Automation_System
{
    public partial class c_login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (idtxt.Text != "")
            {
                if (passtxt.Text != "")
                {
                    string s = "SELECT * from canteen_detail where c_id='" + idtxt.Text + "'and c_pass='" + passtxt.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(s,conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int c = ds.Tables[0].Rows.Count;
                    if (c > 0)
                    {
                        Session["canteen"] = "yes";
                        Session["c_id"] = idtxt.Text;
                        Response.Redirect("c_additem.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid Id or Password.');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Password.');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Id.');", true);
            }
        }
    }
}
