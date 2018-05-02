using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace CruiseReservationApplication
{
    public class TravellerDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public TravellerDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        /// <summary>
        /// Returns the Traveller corresponding to the Oracle username
        /// </summary>
        /// <returns>Corresponding traveller in the database</returns>
        public Traveller FindById()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT id, first_name, last_name, email, administrator FROM traveller", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string id = Convert.ToString(dr["id"]);
                if(id==UserName){
                    string first_name = Convert.ToString(dr["first_name"]);
                    string last_name = Convert.ToString(dr["last_name"]);
                    string email = Convert.ToString(dr["email"]);
                    int admin = Convert.ToInt32(dr["administrator"]);//JUST TO MAKE SURE IT WORKS
                    bool administrator = admin==1 ? true : false;
                    System.Diagnostics.Debug.WriteLine("traveller found and created");//testing for user found in the database
                    return new Traveller(id, Password, first_name, last_name, email, administrator);
                }
            }
            return null;
        }

        public List<Reservation> GetReservations()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT reservation.ship_id AS ship_id, cabin_no, ship_name FROM reservation INNER JOIN cruise ON reservation.ship_id=cruise.ship_id ORDER BY ship_name", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Reservation> reservations = new List<Reservation>();

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows) 
            {
                int ship_id = Convert.ToInt32(dr["ship_id"]);
                string ship_name = Convert.ToString(dr["ship_name"]);
                int cabin_no = Convert.ToInt32(dr["cabin_no"]);
                List<Destination> destinationsList = GetDestinations(ship_id);
                string destinations = string.Join(",", destinationsList);//CSV

                reservations.Add(new Reservation(ship_id,ship_name,cabin_no,destinations));
            }
            return reservations;
        }

        public List<Destination> GetDestinations(int ShipId)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT destination FROM cruise_destination WHERE ship_id=:ship_id", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Destination> destinations = new List<Destination>();

            cmd.Parameters.AddWithValue(":ship_id", ShipId);
            da.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                string destinationName = Convert.ToString(dr["destination"]);
                destinations.Add(new Destination(destinationName));
            }

            return destinations;
        }

        public List<CruiseShip> GetShips()
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT UNIQUE cruise.ship_id AS ship_id, ship_name FROM cruise_destination INNER JOIN cruise ON cruise_destination.ship_id=cruise.ship_id ORDER BY ship_name", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<CruiseShip> cruises = new List<CruiseShip>();

            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                int ship_id = Convert.ToInt32(dr["ship_id"]);
                string ship_name = Convert.ToString(dr["ship_name"]);
                cruises.Add(new CruiseShip(ship_id,ship_name));
            }

            return cruises;
        }
    }
}