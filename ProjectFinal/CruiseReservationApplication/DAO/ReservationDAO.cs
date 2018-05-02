using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace CruiseReservationApplication
{
    public class ReservationDAO
    {
        private string UserName { get; set; }
        private string Password { get; set; }

        public ReservationDAO(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public List<Destination> GetAvailableDestinations(int ShipId)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("SELECT destination.destination FROM destination, cruise_destination WHERE ship_id = :ship_id AND destination.destination != cruise_destination.destination", conn);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            List<Destination> destinations = new List<Destination>();

            cmd.Parameters.AddWithValue(":ship_id", ShipId);
            da.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string destinationName = Convert.ToString(dr["destination"]);
                destinations.Add(new Destination(destinationName));
            }

            return destinations;
        }

        /// <summary>
        /// Calls CREATE_RESERVATION stored procedure to create the cruise reservation 
        /// </summary>
        /// <returns>False if the success status is 0, true otherwise.</returns>
        public bool CreateReservation(int ShipId, int CabinNo)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("CREATE_RESERVATION", conn);

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("pship_id", ShipId);
            cmd.Parameters.AddWithValue("pcabin_no", CabinNo);
            cmd.Parameters.AddWithValue("ptraveller_id", UserName);

            cmd.Parameters.Add("psuccess", OracleType.Number).Direction = ParameterDirection.Output;
            
            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                bool success = Convert.ToBoolean(cmd.Parameters["psuccess"].Value); // Get the return value
                return success;
            }
            finally
            {
                conn.Close();
            }
        }

        public void CancelReservation(int ShipId, int CabinNo)
        {
            OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", UserName, Password));
            OracleCommand cmd = new OracleCommand("DELETE FROM reservation WHERE ship_id = :ship_id AND cabin_no = :cabin_no", conn);

            cmd.Parameters.AddWithValue(":ship_id", ShipId);
            cmd.Parameters.AddWithValue(":cabin_no", CabinNo);

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }
    }
}