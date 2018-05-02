using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseReservationApplication
{
    public class CruiseShip
    {
        public int ShipId { get; private set; }
        public string ShipName { get; private set; }
        public CruiseShip(int ShipId, string ShipName)
        {
            this.ShipId = ShipId;
            this.ShipName = ShipName;

        }
        public override string ToString()
        {
            return ShipName;
        }
    }

    
      
}