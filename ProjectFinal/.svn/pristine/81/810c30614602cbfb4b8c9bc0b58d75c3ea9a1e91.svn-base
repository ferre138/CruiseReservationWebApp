using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CruiseReservationApplication
{
    public partial class HomePage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Traveller traveller = (Traveller)Session["traveller"];
            TravellerDAO travellerDAO = new TravellerDAO(traveller.Id, traveller.Password);
            Traveller t = travellerDAO.FindById();
            if (traveller.IsAdmin)
            {
                lblAdmin.Text = t.ToString();

            }

            else
                Response.Redirect("~/Reservations.aspx");

        }

        protected void btnReservation_Click(object sender, EventArgs e)
        {
            Traveller traveller = (Traveller)Session["traveller"];
            TravellerDAO travellerDAO = new TravellerDAO(traveller.Id, traveller.Password);
            Traveller t = travellerDAO.FindById();

            List<Reservation> reservations = travellerDAO.GetReservations();
            if (0 == reservations.Count)
                Response.Redirect("~/ReserveCruise.aspx");
            else
                Response.Redirect("~/Reservations.aspx");
        }
    }
}