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
    public partial class c_viewitem : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=43.255.152.26;Initial Catalog=ACanteen;Persist Security Info=True;User ID=ACanteen;Password=Do5oe2#5");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["canteen"] != "yes")
            {
                Response.Redirect("MainLogin.aspx");
            }

            string s = "SELECT * from item_detail";
            SqlDataAdapter da = new SqlDataAdapter(s, conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int count = ds.Tables[0].Rows.Count;
            if (count > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                LabelErr.Visible = false;
            }
            else
            {
                LabelErr.Visible = true;
                LabelErr.Text = "Currently, No food items found...";
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
                desc1.Text = HttpUtility.HtmlDecode(gvrow.Cells[2].Text);
                Cost.Text = HttpUtility.HtmlDecode(gvrow.Cells[3].Text);
                Time.Text = HttpUtility.HtmlDecode(gvrow.Cells[4].Text);
                status.Text = HttpUtility.HtmlDecode(gvrow.Cells[5].Text);
                Popup(true);
            }
            else if (e.CommandName == "delete")
            {
                using (conn)
                {
                    string i2 = Convert.ToString(e.CommandArgument.ToString());
                    string sss = "DELETE FROM item_detail where id='" + i2 + "'";
                    SqlCommand cmd = new SqlCommand(sss, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("c_viewitem.aspx");
                }
            }
            else if (e.CommandName == "status")
            {
                string i2 = Convert.ToString(e.CommandArgument.ToString());
                string s8 = "SELECT status from item_detail where id='" + i2 + "'";
                SqlDataAdapter da8 = new SqlDataAdapter(s8,conn);
                DataSet ds8 = new DataSet();
                da8.Fill(ds8);
                string value=ds8.Tables[0].Rows[0][0].ToString();
                if (value == "enable")
                {
                    string dis="disable";
                    string s7 = "UPDATE item_detail SET status='" + dis + "'where id='" + i2 + "'";
                    SqlCommand cmd7 = new SqlCommand(s7,conn);
                    conn.Open();
                    cmd7.ExecuteNonQuery();
                    conn.Close();
                }
                else if (value == "disable")
                {
                    string en = "enable";
                    string s77 = "UPDATE item_detail SET status='" + en + "'where id='" + i2 + "'";
                    SqlCommand cmd77 = new SqlCommand(s77, conn);
                    conn.Open();
                    cmd77.ExecuteNonQuery();
                    conn.Close();
                }
                string s = "SELECT * from item_detail";
                SqlDataAdapter da = new SqlDataAdapter(s, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                int count = ds.Tables[0].Rows.Count;
                if (count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    LabelErr.Visible = false;
                }
                else
                {
                    LabelErr.Visible = true;
                    LabelErr.Text = "Currently, No food items found...";
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                if (desc1.Text != "")
                {
                    if (Cost.Text != "")
                    {
                        if (Time.Text != "")
                        {
                            string update1 = " update item_detail set name='" + name.Text + "',desc1='" + desc1.Text + "',cost='" + Cost.Text + "',time='" + Time.Text + "',status='" + status.Text + "' where id='" + id.Text + "'";
                            SqlCommand cmd = new SqlCommand(update1, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            Response.Redirect("c_viewitem.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Time.');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Cost.');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Description.');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Name.');", true);
            }
        }

        protected void btncancel_Click(object sender, EventArgs e)
        {
            Popup(false);
        }
    }
}