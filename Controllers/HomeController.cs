﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using MyStatz.Models;
using static MyStatz.Models.PaginationModel;

namespace MyStatz.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> LeaderBoard(int region, int page)
        {
            using (HttpClient client = new HttpClient())
            {
                //var pagenumber = new PaginationModel();
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

                
                return View(globalLeaderBoard);
            }

           
    }


        [HttpPost("~/signin")]
        public IActionResult SignIn()//[FromForm] string provider)
        {
            // Note: the "provider" parameter corresponds to the external
            // authentication provider choosen by the user agent.
            //if (string.IsNullOrWhiteSpace(provider))
            //{
            //    return BadRequest();
            //}

            //if (!await HttpContext.IsProviderSupportedAsync("Steam"))
            //{
            //    return BadRequest();
            //}

            // Instruct the middleware corresponding to the requested external identity
            // provider to redirect the user agent to its own authorization endpoint.
            // Note: the authenticationScheme parameter must match the value configured in Startup.cs


            var providers = HttpContext.RequestServices.GetService(typeof(IAuthenticationSchemeProvider));
            return Challenge(new AuthenticationProperties { RedirectUri = "/Home/MyProfile" }, "Steam");
        }


        public IActionResult MyProfile()
        {
            //HttpContext.User;
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
