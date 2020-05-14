using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Canteen_Automation_System
{
    public partial class a_viewcanteen : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=43.255.152.26;Initial Catalog=ACanteen;Persist Security Info=True;User ID=ACanteen;Password=Do5oe2#5");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "yes")
            {
                Response.Redirect("MainLogin.aspx");
            }
            if (Session["Add"] == "Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Canteen details updated successfully');", true);
                Session["Add"] = "";
            }
            string s = "SELECT c_id,c_manager,c_handler,c_mobile,c_worker,c_bal from canteen_detail";
            SqlDataAdapter da = new SqlDataAdapter(s, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('No Data Available.');", true);
            }

        }

        void Popup(bool isDisplay)
        {
            StringBuilder builder = new StringBuilder();
            if (isDisplay)
            {
                builder.Append("<script language=JavaScript> ShowPopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "ShowPopup", builder.ToString());
            }
            else
            {
                builder.Append("<script language=JavaScript> HidePopup(); </script>\n");
                Page.ClientScript.RegisterStartupScript(this.GetType(), "HidePopup", builder.ToString());
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                if (h_txt.Text != "")
                {
                    if (contact.Text != "")
                    {
                        if (w_txt.Text != "")
                        {
                            if (balance.Text != "")
                            {
                                string update1 = " update canteen_detail set c_manager='" + name.Text + "',c_handler='" + h_txt.Text + "',c_mobile='" + contact.Text + "',c_worker='" + w_txt.Text + "',c_bal='" + balance.Text + "' where c_id='" + id.Text + "'";
                                SqlCommand cmd = new SqlCommand(update1, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                conn.Close();
                                Session["Add"] = "Data";
                                Response.Redirect("a_viewcanteen.aspx");
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Balance.');", true);
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter No. of worker.');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Mobile No.');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Handler Name.');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Manage Name');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Popup(false);
        }

        protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ShowPopup")
            {
                LinkButton btndetails = (LinkButton)e.CommandSource;
                GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;
                id.Text = GridView1.DataKeys[gvrow.RowIndex].Value.ToString();
                // DataRow dr = dt.Select("CustomerID=" + GridViewData.DataKeys[gvrow.RowIndex].Value.ToString())[0];
                id.Text = HttpUtility.HtmlDecode(gvrow.Cells[0].Text);
                name.Text = HttpUtility.HtmlDecode(gvrow.Cells[1].Text);
                h_txt.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                contact.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                w_txt.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                balance.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
                Popup(true);
            }
            else if (e.CommandName == "delete")
            {
                using (conn)
                {
                    string i2 = Convert.ToString(e.CommandArgument.ToString());
                    string sss = "DELETE FROM canteen_detail where s_id='" + i2 + "'";
                    SqlCommand cmd = new SqlCommand(sss, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("a_viewcanteen.aspx");
                }
            }
        }
    }
}