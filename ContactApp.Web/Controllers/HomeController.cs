using ContactApi.Domain.Models;
using ContactApp.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Contact = ContactApp.Web.Models.Contact;

namespace ContactApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient client = new HttpClient();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }
        public async Task<IActionResult> IndexDisplay()
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
 
            IEnumerable<Contact> contact = null;
            HttpResponseMessage response = await client.GetAsync("api/v1/Contract/GetAllContacts");
            var contacts = response.Content;
            if (response.IsSuccessStatusCode)
            {
                // contact = serializer.DeserializeJson<Contact>(contacts);
                //var objResponse1 = JsonConvert.DeserializeObject<List<Contact>>(contacts);
                contact = await response.Content.ReadAsAsync<List<Contact>>();
            }
            return View(contact);
        }

        public async Task<IActionResult> AddContact()
        {
            return View();
        }

        public async Task<IActionResult> DeleteContact(int Id)
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Contact report = null;
            HttpResponseMessage response = await client.GetAsync($"api/v1/Contract/{Id}");
            var contacts = response.Content;
            if (response.IsSuccessStatusCode)
            {
                report = await response.Content.ReadAsAsync<Contact>();
            }

            return View(report);
        }

        public async Task<IActionResult> DetailsContact(int Id)
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            Contact report = null;
            HttpResponseMessage response = await client.GetAsync($"api/v1/Contract/{Id}");
            var contacts = response.Content;
            if (response.IsSuccessStatusCode)
            {
                report = await response.Content.ReadAsAsync<Contact>();
            }

            return View(report);
        }
        public async Task<IActionResult> CreateContact(ContactDTO contact) {
            var serializer = new Serialize();
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var report = string.Empty;
            HttpResponseMessage response = await client.PostAsJsonAsync("api/v1/Contract/AddContacts", contact);
            var contacts = response.Content;
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                report  = await response.Content.ReadAsAsync<string>();
                return RedirectToAction("AddContact", "Home");
            }
            // return URI of the created resource.
            return View();
        }

        public async Task<IActionResult> RealDeleteContact(int Id)
        {
            client.BaseAddress = new Uri("http://localhost:5000/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            var report = string.Empty;
            HttpResponseMessage response = await client.DeleteAsync($"api/v1/Contract/{Id}", CancellationToken.None);
            var contacts = response.Content;
            //response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                report = await response.Content.ReadAsAsync<string>();
                return RedirectToAction("IndexDisplay", "Home");
            }
            // return URI of the created resource.
            return View();
        }


    }
}
