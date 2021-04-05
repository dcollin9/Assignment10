using DallinCollinsBowlingLeague.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsBowlingLeague.Components
{



   

    //inherits from the ViewComponent type in general
    public class TeamViewComponent : ViewComponent
    {
        private BowlingLeagueContext context;

        //sets the context equal to the context that is passed in
        public TeamViewComponent(BowlingLeagueContext ctx)
        {
            context = ctx;
            
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamname"];

            //returns the default view (the view that corresponds to this vew component)
            //pulls the information in about the teams and sets up the data
            return View(context.Teams
               .Distinct()
               .OrderBy(x => x));
        }
    }
}
