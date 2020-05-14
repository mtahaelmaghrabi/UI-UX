using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SBAdmin.Models;
using SBAdmin.ModelView;

namespace SBAdmin.Controllers
{
    public class HomeController : Controller
    {
        private HttpClient _apiClient;
        public HttpClient ApiClient
        {
            get
            {
                return _apiClient;
            }
        }

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            //https://localhost:44331/weatherforecast
            _logger = logger;

            InitializeClient();

        }

        private void InitializeClient()
        {
            string api = "https://localhost:44331/";//ConfigurationManager.AppSettings["api"];

            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(api);
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> GetLoggedInUserInfo(string token)
        {
            _apiClient.DefaultRequestHeaders.Clear(); // Added
            _apiClient.DefaultRequestHeaders.Accept.Clear();
            _apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_apiClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

            using (HttpResponseMessage response = await _apiClient.GetAsync("api/Inbox/101"))
            {
                string inbox = "0";
                if (response.IsSuccessStatusCode)
                {
                    inbox = await response.Content.ReadAsStringAsync();
                    //_loggedInUser.Token = token;

                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }

                return inbox;
            }
        }

        public async Task<IActionResult> IndexAsync()
        {
            var inbox = await GetLoggedInUserInfo("xoxo");

            EmployeeHomeModelView employeeHome = new EmployeeHomeModelView
            {
                EmployeeName = "Mohamed Taha",
                InboxCount = Convert.ToInt32(inbox),
                ProfilePicture = @"/profiles/mtaha.jpg"
            };
            employeeHome.Messages.AddRange(new List<UserMessages>() { 
                new UserMessages() { SenderName = "Mohamed Taha", SenderProfile = @"/profiles/mtaha.jpg", MessageBody = "Hi there! I am wondering if you can help me with a problem I've been having." }, 
                new UserMessages() { SenderName = "Morgan Alvarez", SenderProfile = "https://source.unsplash.com/CS2uCrpNzJY/60x60", MessageBody = "Last month's report looks great, I am very happy with the progress so far, keep up the good work!" }, 
                new UserMessages() { SenderName = "Jae Chun", SenderProfile = "https://source.unsplash.com/AU4VPcFN4LE/60x60", MessageBody = "I have the photos that you ordered last month, how would you like them sent to you?" } });

            //ViewBag.UserInboxCount = inbox;
            //ViewBag.UserName = "Mohamed Taha";
            return View(employeeHome);
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
