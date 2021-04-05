using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsBowlingLeague.Models.ViewModels
{
    public class PageNumberingInfo
    {

        //with the numitemsperpage and totalnumitems, i can calculate the number of pages
        public int NumItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalNumItems { get; set; }

        //calculates the number of pages
        //need to force one of the variables to be a decimal by casting
        public int NumPages => (int) Math.Ceiling((decimal) TotalNumItems / NumItemsPerPage);
    }
}
