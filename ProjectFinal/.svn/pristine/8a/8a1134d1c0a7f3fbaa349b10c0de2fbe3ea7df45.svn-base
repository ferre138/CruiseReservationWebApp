using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CruiseReservationApplication
{
    public class Traveller
    {
        public string Id { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }

        public Traveller(string Id, string Password, string FirstName, string LastName, string Email, bool IsAdmin)
        {
            this.Id = Id;
            this.Password = Password;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.IsAdmin = IsAdmin;
        }

        public override string ToString(){
            return FirstName + " " + LastName;
        }
    }
}