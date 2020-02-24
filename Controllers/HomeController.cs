using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyStatz.Models;
//using static MyStatz.Models.PaginationModel;

namespace MyStatz.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public async Task<IActionResult> LeaderBoard(int region, int page)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    var globalLeaderBoard = new GlobalLeaderBoard();
                    globalLeaderBoard.CurrentPage = page;
                    HttpResponseMessage responseMessage = null;
                    int skip = (page - 1) * 20;
                    switch (region)
                    {
                        case 1:
                            responseMessage = await client.GetAsync($"https://api.stratz.com/api/v1/Player/seasonLeaderBoard?leaderBoardDivision=1&skip={skip}");
                            globalLeaderBoard.SEAsiaLeaderBoard = await responseMessage.Content.ReadAsAsync<LeaderBoard>();
                            break;
                        case 2:
                            responseMessage = await client.GetAsync($"https://api.stratz.com/api/v1/Player/seasonLeaderBoard?leaderBoardDivision=2&skip={skip}");
                            globalLeaderBoard.EuropeLeaderBoard = await responseMessage.Content.ReadAsAsync<LeaderBoard>();
                            break;
                        case 3:
                            responseMessage = await client.GetAsync($"https://api.stratz.com/api/v1/Player/seasonLeaderBoard?leaderBoardDivision=3&skip={skip}");
                            globalLeaderBoard.ChinaLeaderBoard = await responseMessage.Content.ReadAsAsync<LeaderBoard>();
                            break;
                        default:
                            responseMessage = await client.GetAsync($"https://api.stratz.com/api/v1/Player/seasonLeaderBoard?leaderBoardDivision=0&skip={skip}");
                            globalLeaderBoard.AmericaLeaderBoard = await responseMessage.Content.ReadAsAsync<LeaderBoard>();
                            break;
                    }
                    ViewData["Error"] = false;
                    return View(globalLeaderBoard);
                }
            }catch (Exception ex)
            {
                ViewData["Error"] = true;
                return View();
            }
            

           
    }


        public async Task<IActionResult> MyProfile()
        {
            //HttpContext.User;
            if (User.Identity.IsAuthenticated) 
            {
                if (User.Claims.Count() > 0)
                {
                    string phrase = User.Claims.First().Value;
                    string[] sp = phrase.Split('/');
                    var comid = sp[sp.Length - 1];
                    var cti = Convert.ToInt64(comid);
                    var convertid = cti - 76561197960265728;
                    
                    var myprofile = new MyProfile();

                    using (HttpClient client = new HttpClient())
                    {                        
                        HttpResponseMessage responseMessage = null;
                        responseMessage = await client.GetAsync($"https://api.stratz.com/api/v1/Player/{convertid}");
                        myprofile.PlayerInfo = await responseMessage.Content.ReadAsAsync<PlayerInfo>();

                        TempData["name"] = myprofile.PlayerInfo.SteamAccount.Name;
                        TempData.Keep("name");

                        responseMessage = await client.GetAsync($"https://api.stratz.com/api/v1/Player/{convertid}/matches");
                        myprofile.PlayerMatches = await responseMessage.Content.ReadAsAsync<List<PlayerMatches>>();


                        return View(myprofile);
                    }
                }
                else
                {
                    return Redirect("~/");
                }
            }
            else
            {
                return Redirect("~/Authentication/Signin");
            }
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
