using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Net.Mail;
using System.Net;
using System.Collections.Specialized;


namespace Canteen_Automation_System
{
    public partial class a_addstudent : System.Web.UI.Page
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
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Student details added and Login credentails sent via mail');", true);
                Session["Add"] = "";
            }
            if (!IsPostBack)
            {
                Random r = new Random();
                int pass = r.Next(1000, 9999);
                string id = "1001";
                string m = "SELECT TOP 1 s_id from student_detail Order By s_id Desc";
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
                    id = "1001";
                }
                conn.Close();
                TextBox1.Text = id;
                TextBox2.Text = pass.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (stu_TextBox3.Text != "")
            {
                if (DropDownList1.SelectedItem.Text != "---SELECT---")
                {
                    if (email_TextBox1.Text != "")
                    {
                        if (mo_TextBox3.Text != "")
                        {
                            if (bal_TextBox3.Text != "")
                            {
                                string data1 = "INSERT INTO student_detail VALUES('" + TextBox1.Text + "','" + stu_TextBox3.Text + "','" + DropDownList1.SelectedItem.Text + "','" + email_TextBox1.Text + "','" + mo_TextBox3.Text + "','" + bal_TextBox3.Text + "','" + TextBox2.Text + "')";
                                SqlCommand cmd = new SqlCommand(data1, conn);
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                //string finalpassword = "Hello " + stu_TextBox3.Text + ",\r\n\r\nPlease find your login credentails below:\r\n\r\nID : " + TextBox1.Text + "\r\nPassword : " + TextBox2.Text + ".\r\n\r\nYour current available balance is " + bal_TextBox3.Text + ".\r\n\r\nYou are successfully registered with Canteen Management System.";
                                //MailMessage msg = new MailMessage();
                                //string senderemail = "fayazgamer@gmail.com";///sender email id
                                //msg.From = new MailAddress(senderemail);
                                //string mypass = "786110786110";//sender password
                                //msg.To.Add(email_TextBox1.Text);///receiver email id
                                //msg.Subject = "Canteen Management";
                                //msg.Body = finalpassword;
                                //SmtpClient sc = new SmtpClient("smtp.gmail.com");
                                //sc.Port = 587;
                                //sc.Credentials = new NetworkCredential(senderemail, mypass);
                                //sc.EnableSsl = true;
                                //sc.UseDefaultCredentials = true;
                                //sc.Send(msg);
                                //conn.Close();

                                string finalpassword = "Hello " + stu_TextBox3.Text + ",\r\n\r\nPlease find your login credentails below:\r\n\r\nID : " + TextBox1.Text + "\r\nPassword : " + TextBox2.Text + ".\r\n\r\nYour current available balance is " + bal_TextBox3.Text + ".\r\n\r\nYou are successfully registered with Canteen Management System.";
                                MailMessage msg = new MailMessage();
                                string senderemail = "rizvicanteen@gmail.com";///sender email id
                                msg.From = new MailAddress(senderemail);
                                string mypass = "rizvi@123";//sender password
                                msg.To.Add(email_TextBox1.Text);///receiver email id
                                msg.Subject = "Canteen Management";
                                msg.Body = finalpassword;
                                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                                sc.Port = 587;
                                sc.Credentials = new NetworkCredential(senderemail, mypass);
                                sc.EnableSsl = true;
                                sc.Send(msg);
                                conn.Close();

                                //
                                conn.Open();
                                cmd.ExecuteNonQuery();
                                string destinationaddr = "91" + mo_TextBox3.Text;

                                string message = "Hello From RizviCanteen" + stu_TextBox3.Text + ",ID : " + TextBox1.Text + "\r\nPassword : " + TextBox2.Text + ".\r\n\r\nYour current available balance is " + bal_TextBox3.Text + "You are registered ";


                                // string message = "Hi " + stu_TextBox3.Text + " , You Have Been Registered For The Rizvi College Canteen. Thanks!!";

                                String message1 = HttpUtility.UrlEncode(message);
                                using (var wb = new WebClient())
                                {
                                    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                                {
                                {"apikey" , "jXWo5oa82Gk-uTseSSQov4SPuerGRKBMztCgUYXg3N"},
                                {"numbers" , destinationaddr},
                                {"message" , message1},
                                {"sender" , "TXTLCL"}
                                });
                                    string result = System.Text.Encoding.UTF8.GetString(response);
                                }

                                conn.Close();

                                //






                                Session["Add"] = "Data";
                                Response.Redirect("a_addstudent.aspx");


                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Balance field cannot be left blank');", true);
                            }
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
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Classfield cannot be left blank');", true);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Name field cannot be left blank');", true);
            }
        }
    }
}