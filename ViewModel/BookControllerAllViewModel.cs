using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bookies.ViewModel
{
    public class BookControllerAllViewModel
    {
        public bool HasLib { get; set; }

        public IList<Models.Book> Books { get; set; }
    }
}