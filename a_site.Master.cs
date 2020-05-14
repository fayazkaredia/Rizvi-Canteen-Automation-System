using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Canteen_Automation_System
{
    public partial class a_site : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == "yes")
            {
                Panel1.Visible = true;
                Panel2.Visible = false;
            }
            else if (Session["canteen"] == "yes")
            {
                Panel1.Visible = false;
                Panel2.Visible = true;
            }
            else
            {
                Panel1.Visible = false;
                Panel2.Visible = false;
            }
        }
    }
}