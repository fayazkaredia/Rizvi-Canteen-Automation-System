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
    public partial class c_transaction : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=43.255.152.26;Initial Catalog=ACanteen;Persist Security Info=True;User ID=ACanteen;Password=Do5oe2#5");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["canteen"] != "yes")
            {
                Response.Redirect("MainLogin.aspx");
            }
            if (!IsPostBack)
            {
                string s = "SELECT * FROM trans where t_via='" + Session["c_id"].ToString() + "'";
                SqlDataAdapter da = new SqlDataAdapter(s, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int c = ds.Tables[0].Rows.Count;
                if (c > 0)
                {
                    Panel1.Visible = true;
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    LabelErr.Visible = true;
                    LabelErr.Text = "Currently, No transactions details found...";
                }
            }
        }
        

        protected void Button1_Click(object sender, EventArgs e)
        {
            string todate = Calendar1.SelectedDate.ToString("yyyy/MM/dd");
            string fromdate = Calendar2.SelectedDate.ToString("yyyy/MM/dd");
            string kk = "SELECT * from trans where t_via='" + Session["c_id"].ToString() + "'and t_date between '"+todate+"' and '"+fromdate+"'";
            SqlDataAdapter da = new SqlDataAdapter(kk, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int c = ds.Tables[0].Rows.Count;
            if (c > 0)
            {
                Panel1.Visible = true;
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                LabelErr.Visible = true;
                LabelErr.Text = "Currently, No transaction details found...";
            }
        }

        protected void Calendar1_DayRender1(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void Calendar2_DayRender1(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date > DateTime.Today)
            {
                e.Day.IsSelectable = false;
            }
        }
    }
}