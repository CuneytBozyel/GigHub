using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModel
{
    public class HomeViewModel
    {
        public IEnumerable<Gig> upComingGigs { get; set; }

        public bool ShowAction { get; set; }
    }
}