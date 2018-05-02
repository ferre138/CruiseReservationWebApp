using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CruiseReservationApplication
{
    public partial class ReserveCruise : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Traveller traveller = (Traveller)Session["traveller"];
                TravellerDAO travellerDAO = new TravellerDAO(traveller.Id, traveller.Password);
                List<CruiseShip> cruises = travellerDAO.GetShips();

                if (0 == cruises.Count)
                {
                    lblDestinations.Text = "There are no destinations available for the chosen cruise.";
                    lblDestTitle.Visible = false;
                    btnReserve.Enabled = false;
                }
                else
                {
                    ddlCruise.DataSource = cruises;
                    ddlCruise.DataTextField = "ShipName";
                    ddlCruise.DataValueField = "ShipId";
                    ddlCruise.DataBind();
                    lblDestTitle.Visible = true;
                    ddlCruise_SelectedIndexChanged(null, null);
                }
            }
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                try
                {
                    Traveller traveller = (Traveller)Session["traveller"];
                    ReservationDAO reservationDAO = new ReservationDAO(traveller.Id, traveller.Password);
                    int shipId = Convert.ToInt32(ddlCruise.SelectedValue);
                    int cabinNo = Convert.ToInt32(txtCabinNo.Text);

                    bool success = reservationDAO.CreateReservation(shipId, cabinNo);
                    if (success)
                    {
                        Response.Redirect("~/Reservations.aspx");
                    }
                    else
                    {
                        lblError.Text = "The specified cabin is not available.";
                        lblError.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                } 
            }
        }

        protected void ddlCruise_SelectedIndexChanged(object sender, EventArgs e)
        {
            Traveller traveller = (Traveller)Session["traveller"];
            TravellerDAO travellerDAO = new TravellerDAO(traveller.Id, traveller.Password);
            int shipId = Convert.ToInt32(ddlCruise.SelectedValue);
            List<Destination> destinationsList = travellerDAO.GetDestinations(shipId);
            string destinations = string.Join(",", destinationsList);
            lblDestinations.Text = destinations;
        }
    }
}