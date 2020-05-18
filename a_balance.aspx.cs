using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Canteen_Automation_System
{
    public partial class a_balance : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != "yes")
            {
                Response.Redirect("a_login.aspx");
            }
            if (Session["Add"] == "Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Amount added successfully');", true);
                Session["Add"] = "";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_TextBox1.Text != "")
            {
                if (bal_TextBox2.Text != "")
                {
                    if (bal_TextBox2.Text != "0")
                    {
                        string s = "SELECT s_bal from student_detail where s_id='" + id_TextBox1.Text + "'";
                        SqlDataAdapter da = new SqlDataAdapter(s, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        int c = ds.Tables[0].Rows.Count;
                        if (c > 0)
                        {
                            int amt = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                            int value = Convert.ToInt32(bal_TextBox2.Text);
                            int total = amt + value;
                            string data1 = "UPDATE student_detail SET s_bal='" + total.ToString() + "'where s_id='" + id_TextBox1.Text + "'";
                            SqlCommand cmd = new SqlCommand(data1, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();

                            string stu1 = "SELECT s_bal,s_email,s_name from student_detail where s_id='" + id_TextBox1.Text + "'";
                            SqlDataAdapter da_s1 = new SqlDataAdapter(stu1, conn);
                            DataSet ds_s1 = new DataSet();
                            da_s1.Fill(ds_s1);

                            string finalpassword = "Hello " + ds_s1.Tables[0].Rows[0][2].ToString() + ",\r\n\r\nRs. " + value + " has been credited in your account.\r\n\r\nYour current available balance is Rs. " + ds_s1.Tables[0].Rows[0][0].ToString() + "";
                            MailMessage msg = new MailMessage();
                            string senderemail = "mailtestingw@gmail.com";///sender email id
                            msg.From = new MailAddress(senderemail);
                            string mypass = "testmail123";//sender password
                            msg.To.Add(ds_s1.Tables[0].Rows[0][1].ToString());///receiver email id
                            msg.Subject = "Canteen Management";
                            msg.Body = finalpassword;
                            SmtpClient sc = new SmtpClient("smtp.gmail.com");
                            sc.Port = 587;
                            sc.Credentials = new NetworkCredential(senderemail, mypass);
                            sc.EnableSsl = true;
                            sc.Send(msg);
                            conn.Close();


                            string id = "10001";
                            string m = "SELECT TOP 1 t_id from trans Order By t_id Desc";
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
                                id = "10001";
                            }
                            conn.Close();
                            string date = DateTime.Now.ToString("yyyy/MM/dd");
                            string time = DateTime.Now.ToString("HH:mm:ss");
                            string a = "Admin";
                            string d = "Credited";
                            string kk = "INSERT INTO trans VALUES('" + id + "','" + a + "','" + id_TextBox1.Text + "','" + bal_TextBox2.Text + "','" + date + "','" + time + "','" + d + "')";
                            SqlCommand cmd2 = new SqlCommand(kk, conn);
                            conn.Open();
                            cmd2.ExecuteNonQuery();
                            conn.Close();
                            id_TextBox1.Text = "";
                            bal_TextBox2.Text = "";
                            Session["Add"] = "Data";
                            Response.Redirect("a_balance.aspx");
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid Id.');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Kindly enter a valid amount');", true);
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Amount.');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Enter Id.');", true);
            }
        }
    }
}
