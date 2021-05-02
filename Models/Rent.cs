using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace bookies.Models
{
    public class Rent
    {
        public int Id { get; set; }

        [Required]
        public DateTime RentDate { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public ApplicationUser User { get; set; }
    }
}