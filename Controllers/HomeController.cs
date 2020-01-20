using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyStatz.Models;

namespace MyStatz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LeaderBoard()
        {
            using (HttpClient client = new HttpClient())
            {                
                HttpResponseMessage responseMessage = await client.GetAsync("https://api.stratz.com/api/v1/Player/seasonLeaderBoard?leaderBoardDivision=" );

                LeaderBoard leaderBoards = await responseMessage.Content.ReadAsAsync<LeaderBoard>();

                //var player = new Player();
                //TimeSpan ts = TimeSpan.FromTicks(player.LastUpdateDateTime);
                
                return View(leaderBoards);
            }
        }

        public IActionResult MyProfile()
        {
            
            return View();
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
