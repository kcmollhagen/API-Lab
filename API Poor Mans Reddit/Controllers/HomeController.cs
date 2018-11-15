using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace API_Lab___Poor_Man_s_Reddit.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //This method gets data from an API (Reddit)
        public ActionResult Reddit()
        {
            //**update Using statements up top**
            //calls API from remote server; gets response from server/asks server for data
            HttpWebRequest request = WebRequest.CreateHttp("https://www.reddit.com/r/aww/.json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //reads in raw data; stores raw data into string
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            //converts string into a JSON object
            JObject redditJson = JObject.Parse(data);
            List<JToken> singlePost = redditJson["data"]["children"].ToList();

            ViewBag.dat = singlePost[6]["data"]["title"];
            ViewBag.img = singlePost[6]["data"]["thumbnail"];

            return View();
        }
    }
}