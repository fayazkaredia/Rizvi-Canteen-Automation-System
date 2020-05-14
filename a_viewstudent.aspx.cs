using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace Canteen_Automation_System
{
    public partial class a_viewstudent : System.Web.UI.Page
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
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Student details updated successfully');", true);
                Session["Add"] = "";
            }
            if (Session["Del"] == "Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Student details deleted');", true);
                Session["Del"] = "";
            }
            string s = "SELECT s_id,s_name,s_class,s_email,s_mobile,s_bal from student_detail";
            SqlDataAdapter da = new SqlDataAdapter(s,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int count=ds.Tables[0].Rows.Count;
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
                class1.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                email.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                contact.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                Popup(true);
            }
            else if (e.CommandName == "delete")
            {
                using (conn)
                {
                    string i2 = Convert.ToString(e.CommandArgument.ToString());
                    string sss = "DELETE FROM student_detail where s_id='" + i2 + "'";
                    SqlCommand cmd = new SqlCommand(sss, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Session["Del"] = "Data";
                    Response.Redirect("a_viewstudent.aspx");
                }
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                if (class1.Text != "")
                {
                    if (email.Text != "")
                    {
                        if (contact.Text != "")
                        {
                            string update1 = " update student_detail set s_name='" + name.Text + "',s_class='" + class1.Text + "',s_email='" + email.Text + "',s_mobile='" + contact.Text + "' where s_id='" + id.Text + "'";
                            SqlCommand cmd = new SqlCommand(update1, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Session["Add"] = "Data";
                            Response.Redirect("a_viewstudent.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Mobile No. field cannot be left blank');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Email Id field cannot be left blank');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Class field cannot be left blank');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Name field cannot be left blank');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Popup(false);
        }
    }
}