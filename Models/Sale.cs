using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace bookies.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public byte SaleType { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public ApplicationUser User { get; set; }

        [Required]
        public int Amount { get; set; }
    }
}