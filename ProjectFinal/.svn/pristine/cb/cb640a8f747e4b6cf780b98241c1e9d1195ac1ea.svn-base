using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CruiseReservationApplication
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    Traveller traveller = DatabaseHelper.Login(txtUserName.Text, txtPassword.Text);
                    Session.Add("traveller", traveller); // Save traveller information into session
                    Response.Redirect("~/HomePage.aspx");
                   // Response.Redirect("~/Reservations.aspx");

                }
                catch (Exception)
                {
                    lblInvalid.Visible = true;
                }
            }
        }
    }
}