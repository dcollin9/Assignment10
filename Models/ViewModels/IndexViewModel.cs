using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsBowlingLeague.Models.ViewModels
{
    public class IndexViewModel
    {
        //creates a list of bowlers that we can insert into the home view
        public List<Bowlers> Bowlers { get; set; }

        //creates a PageNumberingInfo object so that we can set this info in the home controller
        public PageNumberingInfo PageNumberingInfo { get; set; }

        public string Team { get; set; }
    }
}
