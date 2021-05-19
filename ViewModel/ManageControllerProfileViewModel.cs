using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookies.Models;

namespace bookies.ViewModel
{
    public class ManageControllerProfileViewModel
    {
        public IList<Sale> Sales { get; set; }

        public IList<Rent> Rents { get; set; }

        public bool HasPassword { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }
    }
}