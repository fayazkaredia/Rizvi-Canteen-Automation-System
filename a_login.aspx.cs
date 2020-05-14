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
    public partial class a_login : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=43.255.152.26;Initial Catalog=ACanteen;Persist Security Info=True;User ID=ACanteen;Password=Do5oe2#5");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (idtxt.Text != "")
            {
                if (passtxt.Text != "")
                {
                    if (idtxt.Text == "admin")
                    {
                        if (passtxt.Text == "admin")
                        {
                            Session["admin"] = "yes";
                            Session["a_id"] = idtxt.Text;
                            Response.Redirect("a_addstudent.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid Password');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid Id');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Password');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Admin Id');", true);
            }
        }
    }
}