using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using bookies.Models;

namespace bookies.ViewModel
{
    public class BookControllerDetailsViewModel
    {
        public bool IsAdmin { get; set; }

        public Book Book { get; set; }
    }
}