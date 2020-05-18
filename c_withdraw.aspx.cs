﻿using System;
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
    public partial class c_withdraw : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["canteen"] != "yes")
            {
                Response.Redirect("MainLogin.aspx");
            }
            if (Session["Add"] == "Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Transaction successful');", true);
                Session["Add"] = "";
            }
            Label5.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (id_TextBox1.Text != "")
            {
                if (bal_TextBox2.Text != "")
                {
                    string s = "select s_bal from student_detail where s_id='" + id_TextBox1.Text + "'";
                    SqlDataAdapter da = new SqlDataAdapter(s, conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    int c = ds.Tables[0].Rows.Count;
                    if (c > 0)
                    {
                        int amt = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
                        int value = Convert.ToInt32(bal_TextBox2.Text);
                        if (value <= amt)
                        {
                            int total = amt - value;
                            string s2 = "UPDATE student_detail SET s_bal='" + total.ToString() + "'where s_id='" + id_TextBox1.Text + "'";
                            SqlCommand cmd = new SqlCommand(s2, conn);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                            conn.Close();
                            if(Session["canteen"]=="yes")
                            {
                                string str = "select c_bal from canteen_detail where c_id='" + Session["c_id"].ToString() + "'";
                                SqlDataAdapter das = new SqlDataAdapter(str, conn);
                                DataSet dss = new DataSet();
                                das.Fill(dss);
                                if(dss.Tables[0].Rows.Count>0)
                                {
                                    string cbal = dss.Tables[0].Rows[0][0].ToString();
                                    int add = Convert.ToInt32(cbal) + Convert.ToInt32(bal_TextBox2.Text);
                                    string up = "UPDATE canteen_detail SET c_bal='" + add.ToString() + "'where c_id='" + Session["c_id"].ToString() + "'";
                                    SqlCommand cmds = new SqlCommand(up, conn);
                                    conn.Open();
                                    cmds.ExecuteNonQuery();
                                    conn.Close();
                                }
                            }

                            string stu1 = "SELECT s_bal,s_email,s_name from student_detail where s_id='" + id_TextBox1.Text + "'";
                            SqlDataAdapter da_s1 = new SqlDataAdapter(stu1, conn);
                            DataSet ds_s1 = new DataSet();
                            da_s1.Fill(ds_s1);

                            string finalpassword = "Hello " + ds_s1.Tables[0].Rows[0][2].ToString() + ",\r\n\r\nRs. " + value + " has been debited from your account.\r\n\r\nYour current available balance is Rs. " + ds_s1.Tables[0].Rows[0][0].ToString() + "";
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
                            string a = Session["c_id"].ToString();
                            string w = "Withdraw";

                            string kk = "INSERT INTO trans VALUES('" + id + "','" + id_TextBox1.Text + "','" + a + "','" + bal_TextBox2.Text + "','" + date + "','" + time + "','" + w + "')";
                            SqlCommand cmd2 = new SqlCommand(kk, conn);
                            conn.Open();
                            cmd2.ExecuteNonQuery();
                            conn.Close();
                            id_TextBox1.Text = "";
                            bal_TextBox2.Text = "";

                            string del = "delete from temp where qrcode='" + TextBoxQR.Text + "'";
                            SqlCommand cmd4 = new SqlCommand(del, conn);
                            conn.Open();
                            cmd4.ExecuteNonQuery();
                            conn.Close();

                            Session["Add"] = "Data";
                            Response.Redirect("c_withdraw.aspx");

                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Insufficient Balance');", true);
                        }
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Invalid Id.');", true);
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

        protected void TextBoxQR_TextChanged(object sender, EventArgs e)
        {
            string str = "select userid,amount from temp where qrcode='" + TextBoxQR.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(str,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if(ds.Tables[0].Rows.Count>0)
            {
                Label5.Visible = false;
                Panel1.Visible = true;
                id_TextBox1.Text = ds.Tables[0].Rows[0][0].ToString();
                bal_TextBox2.Text = ds.Tables[0].Rows[0][1].ToString();
                id_TextBox1.ReadOnly = true;
                bal_TextBox2.ReadOnly = true;
            }
            else
            {
                Panel1.Visible = false;
            }
        }
    }
}
