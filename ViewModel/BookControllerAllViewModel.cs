using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookies.ViewModel
{
    public class BookControllerAllViewModel
    {
        public bool IsAdmin { get; set; }

        public IList<Models.Book> Books { get; set; }
    }
}