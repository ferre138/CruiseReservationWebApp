using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CruiseReservationApplication
{
    public partial class Reservations : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                FillPage();
        }

        private void FillPage()
        {
            Traveller traveller = (Traveller)Session["traveller"];
            TravellerDAO travellerDAO = new TravellerDAO(traveller.Id, traveller.Password);
            List<Reservation> reservations = travellerDAO.GetReservations();
            gvReservations.DataSource = reservations;
            gvReservations.Columns[0].Visible = true;
            gvReservations.DataBind();
            gvReservations.Columns[0].Visible = false;
            if (0 == reservations.Count)
                lblNoReservations.Visible = true;
            else
                lblNoReservations.Visible = false;
            Traveller t = travellerDAO.FindById();
            lblFullName.Text = t.ToString();
            hyperLinkHome.Text = traveller.IsAdmin ? "Home" : "Log Out";
        }

        protected void hyperLinkHome_Click(object sender, EventArgs e)
        {
            if (hyperLinkHome.Text == "Home")
                Response.Redirect("~/HomePage.aspx");
            else
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }
        }

        protected void gvReservations_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Traveller traveller = (Traveller)Session["traveller"];
            ReservationDAO reservationDAO = new ReservationDAO(traveller.Id, traveller.Password);
            int index = Convert.ToInt32(e.CommandArgument);
            int shipId = Convert.ToInt32(gvReservations.Rows[index].Cells[0].Text);
            int cabinNo = Convert.ToInt32(gvReservations.Rows[index].Cells[2].Text);
            if (e.CommandName == "CANCEL")
            {
                try
                {
                    reservationDAO.CancelReservation(shipId, cabinNo);
                    FillPage();
                    hyperLinkHome_Click(sender, e);
                }
                catch (Exception ex)
                {
                    lblError.Text = ex.Message;
                }
            }
        }

        protected void gvReservations_RowEditing(object sender, GridViewEditEventArgs e)
        {
            e.Cancel = true; // to prevent on-screen row editing
        }

        protected void gvReservations_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            e.Cancel = true; // to prevent on-screen row deleting
        }
    }
}