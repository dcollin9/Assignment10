using DallinCollinsBowlingLeague.Models;
using DallinCollinsBowlingLeague.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DallinCollinsBowlingLeague.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BowlingLeagueContext context { get; set; }

        public HomeController(ILogger<HomeController> logger, BowlingLeagueContext ctx)
        {
            _logger = logger;
            context = ctx;
        }

        //action for  the home page
        public IActionResult Index(long? teamId, string teamname = "All Teams", int pageNum = 0)
        {
            //var blah = "%a%";

            int pageSize = 5;


            //returns the view with the desired number of records 
            //builds an instance of the indexviewmodel with the information that we need to pass to it
            return View(new IndexViewModel

            {

                //returns all bowlers that are on a certain team, and if no team specified, all bowlers
                Bowlers = (context.Bowlers
                .Where(m => m.TeamId == teamId || teamId == null)
                .OrderBy(m => m.BowlerFirstName)
                .Skip((pageNum - 1) * pageSize) //on the first go around, skips 0
                .Take(pageSize)
                .ToList()),

                PageNumberingInfo = new PageNumberingInfo
                {
                    NumItemsPerPage = pageSize,
                    CurrentPage = pageNum,

                    //if no team is selected, get the full count of bowlers, otherwise, only count the number of bowlers from the team that has been selected
                    TotalNumItems = (teamId == null ? context.Bowlers.Count() :
                        context.Bowlers.Where(x => x.TeamId == teamId).Count())
                },

                Team = teamname
            }) ;
                
        
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
