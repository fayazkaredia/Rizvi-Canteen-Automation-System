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
    public partial class c_neworder : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=43.255.152.26;Initial Catalog=ACanteen;Persist Security Info=True;User ID=ACanteen;Password=Do5oe2#5");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["canteen"] != "yes")
            {
                Response.Redirect("MainLogin.aspx");
            }
            if(Session["Add"]== "Data")
            {
                Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Payment Successful');", true);
                Session["Add"] = "";
            }
            string s = "SELECT * FROM order_detail where canteen_id='"+Session["c_id"].ToString()+"'";
            SqlDataAdapter da = new SqlDataAdapter(s,conn);
            DataSet ds = new DataSet();
            da.Fill(ds);
            int c = ds.Tables[0].Rows.Count;
            if (c > 0)
            {
                GridView1.DataSource = ds;
                GridView1.DataBind();
                
            }
            else
            {
                LabelErr.Visible = true;
                LabelErr.Text = "Currently, No orders found...";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string pp = "SELECT * from order_detail where order_id='"+TextBox1.Text+"'and canteen_id='"+Session["c_id"].ToString()+"'";
            SqlDataAdapter da1 = new SqlDataAdapter(pp,conn);
            DataSet ds1 = new DataSet();
            da1.Fill(ds1);
            int c = ds1.Tables[0].Rows.Count;
            if (c > 0)
            {
                //withdraw student bal
                string stu = "SELECT s_bal,s_email,s_name from student_detail where s_id='" + ds1.Tables[0].Rows[0][1].ToString() + "'";
                SqlDataAdapter da_s = new SqlDataAdapter(stu,conn);
                DataSet ds_s = new DataSet();
                da_s.Fill(ds_s);
                int v = ds_s.Tables[0].Rows.Count;
                if (v > 0)
                {
                    int current = Convert.ToInt32(ds_s.Tables[0].Rows[0][0].ToString());
                    int amt = Convert.ToInt32(ds1.Tables[0].Rows[0][4].ToString());
                    
                    if (amt <= current)
                    {
                        int total=current-amt;
                        string oo = "UPDATE student_detail SET s_bal='" + total + "'where s_id='" + ds1.Tables[0].Rows[0][1].ToString() + "'";
                        SqlCommand cmd3 = new SqlCommand(oo,conn);
                        conn.Open();
                        cmd3.ExecuteNonQuery();


                        string finalpassword = "Hello '" + ds_s.Tables[0].Rows[0][2].ToString() + "', \r\n\r\nYou have withdrawn Rs. '" + amt + "'. Your available balance is Rs. '" + total + "'";
                        MailMessage msg = new MailMessage();
                        string senderemail = "mailtestingw@gmail.com";///sender email id
                        msg.From = new MailAddress(senderemail);
                        string mypass = "testmail123";//sender password
                        msg.To.Add(ds_s.Tables[0].Rows[0][1].ToString());///receiver email id
                        msg.Subject = "Canteen Management";
                        msg.Body = finalpassword;
                        SmtpClient sc = new SmtpClient("smtp.gmail.com");
                        sc.Port = 587;
                        sc.Credentials = new NetworkCredential(senderemail, mypass);
                        sc.EnableSsl = true;
                        sc.Send(msg);
                        conn.Close();

                        //update transaction
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
                        string d = "Order Payment";
                        string kk = "INSERT INTO trans VALUES('" + id + "','" + a + "','" + ds1.Tables[0].Rows[0][1].ToString() + "','" + ds1.Tables[0].Rows[0][4].ToString() + "','" + date + "','" + time + "','" + d + "')";
                        SqlCommand cmd2 = new SqlCommand(kk, conn);
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        conn.Close();
                        //credit canteen bal

                        string ssa = "SELECT c_bal from canteen_detail where c_id='" + Session["c_id"].ToString() + "' ";
                        SqlDataAdapter dda = new SqlDataAdapter(ssa, conn);
                        DataSet dds = new DataSet();
                        dda.Fill(dds);
                        int current1 = Convert.ToInt32(dds.Tables[0].Rows[0][0].ToString());
                        int amt1 = Convert.ToInt32(ds1.Tables[0].Rows[0][4].ToString());
                        int total1 = current1 + amt1;
                        string jj = "UPDATE canteen_detail SET c_bal='" + total1 + "' where c_id='" + Session["c_id"].ToString() + "'";
                        SqlCommand ccmd = new SqlCommand(jj, conn);
                        conn.Open();
                        ccmd.ExecuteNonQuery();
                        conn.Close();


                        // Update order detail status
                        string paid = "Paid";
                        string data2 = "UPDATE order_detail SET status='" + paid + "' where order_id='" + TextBox1.Text + "'";
                        SqlCommand cmd33 = new SqlCommand(data2, conn);
                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();

                        Panel1.Visible = false;
                        Session["Add"] = "Data";
                        Response.Redirect("c_neworder.aspx");
                    }
                    else
                    {
                        int cash = amt - current;
                        LabelCash.Text = cash.ToString();
                        LabelBal.Text = current.ToString();
                        LabelAD.Text = " (Amount Deducted)";
                        Panel1.Visible = true;
                        Panel4.Visible = true;


                        string oo = "UPDATE student_detail SET s_bal='0' where s_id='" + ds1.Tables[0].Rows[0][1].ToString() + "'";
                        SqlCommand cmd3 = new SqlCommand(oo, conn);
                        conn.Open();
                        cmd3.ExecuteNonQuery();

                        string finalpassword = "Hello " + ds_s.Tables[0].Rows[0][2].ToString() + ", \r\n\r\n Rs. " + LabelBal.Text + " is deducted from your account balance for order payment. \r\n\r\nYour available balance is Rs. '0'";
                        MailMessage msg = new MailMessage();
                        string senderemail = "mailtestingw@gmail.com";///sender email id
                        msg.From = new MailAddress(senderemail);
                        string mypass = "testmail123";//sender password
                        msg.To.Add(ds_s.Tables[0].Rows[0][1].ToString());///receiver email id
                        msg.Subject = "Canteen Management";
                        msg.Body = finalpassword;
                        SmtpClient sc = new SmtpClient("smtp.gmail.com");
                        sc.Port = 587;
                        sc.Credentials = new NetworkCredential(senderemail, mypass);
                        sc.EnableSsl = true;
                        sc.Send(msg);
                        conn.Close();

                        //update transaction
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
                        string d = "Order Payment";
                        string kk = "INSERT INTO trans VALUES('" + id + "','" + a + "','" + ds1.Tables[0].Rows[0][1].ToString() + "','" + ds1.Tables[0].Rows[0][4].ToString() + "','" + date + "','" + time + "','" + d + "')";
                        SqlCommand cmd2 = new SqlCommand(kk, conn);
                        conn.Open();
                        cmd2.ExecuteNonQuery();
                        conn.Close();
                        //credit canteen bal

                        string ssa = "SELECT c_bal from canteen_detail where c_id='" + Session["c_id"].ToString() + "' ";
                        SqlDataAdapter dda = new SqlDataAdapter(ssa, conn);
                        DataSet dds = new DataSet();
                        dda.Fill(dds);
                        int current1 = Convert.ToInt32(dds.Tables[0].Rows[0][0].ToString());
                        int amt1 = Convert.ToInt32(ds1.Tables[0].Rows[0][4].ToString());
                        int total1 = current1 + amt1;
                        string jj = "UPDATE canteen_detail SET c_bal='" + total1 + "' where c_id='" + Session["c_id"].ToString() + "'";
                        SqlCommand ccmd = new SqlCommand(jj, conn);
                        conn.Open();
                        ccmd.ExecuteNonQuery();
                        conn.Close();


                        // Update order detail status
                        string paid = "Paid";
                        string data2 = "UPDATE order_detail SET status='" + paid + "' where order_id='" + TextBox1.Text + "'";
                        SqlCommand cmd33 = new SqlCommand(data2, conn);
                        conn.Open();
                        cmd33.ExecuteNonQuery();
                        conn.Close();

                        Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Rs. " + LabelBal.Text + " Deducted from Balance. Payable cash " + LabelCash.Text + "');", true);
                        Button1.Enabled = false;

                        string s = "SELECT * FROM order_detail where canteen_id='" + Session["c_id"].ToString() + "'";
                        SqlDataAdapter da = new SqlDataAdapter(s, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        int c1 = ds.Tables[0].Rows.Count;
                        if (c1 > 0)
                        {
                            GridView1.DataSource = ds;
                            GridView1.DataBind();

                        }
                        else
                        {
                            LabelErr.Visible = true;
                            LabelErr.Text = "Currently, No orders found...";
                        }
                    }
                }

               
            }
            else
            {
                LabelErr.Visible = true;
                LabelErr.Text = "Currently, No food items found...";
            }
        }

        protected void GridViewData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "status")
            {
                string i2 = Convert.ToString(e.CommandArgument.ToString());
                string kk = "SELECT status,amount from order_detail where order_id='" + i2 + "'";
                SqlDataAdapter da = new SqlDataAdapter(kk,conn);
                DataSet ds = new DataSet();
                da.Fill(ds);
                if (ds.Tables[0].Rows[0][0].ToString() == "Ordered")
                {
                    string R = "Preparing";
                    string ss = "UPDATE order_detail SET status='" + R + "'where order_id='" + i2 + "'";
                    SqlCommand cmd = new SqlCommand(ss, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("c_neworder.aspx");
                }
                else if (ds.Tables[0].Rows[0][0].ToString() == "Preparing")
                {
                    string R = "Ready";
                    string ss = "UPDATE order_detail SET status='" + R + "'where order_id='" + i2 + "'";
                    SqlCommand cmd = new SqlCommand(ss, conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("c_neworder.aspx");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Order is already Paid or in Ready state.');", true);
                }
            }
            else if (e.CommandName == "payment")
            {
                string i21 = Convert.ToString(e.CommandArgument.ToString());
                string kk1 = "SELECT status,amount,user_id from order_detail where order_id='" + i21 + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(kk1, conn);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);
                if (ds1.Tables[0].Rows[0][0].ToString() == "Paid")
                {
                    Page.ClientScript.RegisterStartupScript(GetType(), "msgbox", "alert('Order is already Paid.');", true);
                }
                else
                {
                    Panel1.Visible = true;
                }
            }
        }
    }
}