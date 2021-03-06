﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using UserAccess;
using TweetsAndTrends;

namespace Views
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblError.Text = "";
        }
        protected void loginbtn(object sender, EventArgs e)
        {


            UserAccess.Login login = new UserAccess.Login();
            String email = Request.Form["email"];
            String password = Request.Form["password"];

            User u = null;
            Task.Run(async () =>
            {
                try
                {
                   u = await login.getLogin(email, password);

              

                }
                catch (Exception eee)
                {
                    
                }

            }).Wait();

            if(u != null)
            {
                
                Session["FName"] = u.FirstName;
                Session["LName"] = u.LastName;
                Session["Email"] = u.Email;
              
                Session["EmailConfirm"] = u.EmailConfirm;
                Session["Type"] = "User";


                Response.Redirect("~/User-Dashboard.aspx", false);
                Context.ApplicationInstance.CompleteRequest();
            }
            else
            {
                lblError.Text = "Email or Password is incorrect";
            }


        }
       
       
    }
}