using GigHub.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GigHub.ViewModel
{
    public class GigViewModel
    {
        [Required]
        public string Venue { get; set; }

        [Required]
        [FutureDate]
        public string Date { get; set; }

        [Required]
        public string Time { get; set; }

        [Required]
        public byte Genre { get; set; }

        public IEnumerable<Genre> Genres { get; set; }

        public string Heading { get; set; }


        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }
    }
}