using CardOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace CardsUIApp.Controllers
{
    public class CardsController : Controller
    {
        string webApiUrl = "http://localhost:59471/api";
        // GET: Cards
        public ActionResult Index()
        {
            ViewBag.message = "Hello World";
            return View();
        }

        [HttpGet]
        public ActionResult GetTopCard()
        {
            Card crd = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApiUrl);
                var responseTask = client.GetAsync("cards/topcard");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Card>();
                    readTask.Wait();

                    crd = readTask.Result;
                }
                else 
                {
                    crd = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult GetCards(int numberOfCards)
        {
            List<Card> crds = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApiUrl);
                var responseTask = client.GetAsync(string.Format("cards/{0}", numberOfCards));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<Card>>();
                    readTask.Wait();

                    crds = readTask.Result;
                }
                else
                {
                    crds = null;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult ShuffleCards()
        {
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApiUrl);
                var responseTask = client.GetAsync("cards/ShuffleCards");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();
                    readTask.Wait();

                    isSuccess = readTask.Result;
                }
                else
                {
                    isSuccess = false;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View("Index");
        }

        [HttpGet]
        public ActionResult CheckCardExists(int num, string type)
        {
            bool isSuccess = false;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(webApiUrl);
                var responseTask = client.GetAsync(string.Format("cards/cardexists/{0}/{1}", num, type));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<bool>();
                    readTask.Wait();

                    isSuccess = readTask.Result;
                }
                else
                {
                    isSuccess = false;
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View("Index");
        }

    }
}