using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace FinalCapstoneMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpWebRequest WR4 = WebRequest.CreateHttp($"http://localhost:57743/api/Car/ListofYears");
            WR4.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response4 = (HttpWebResponse)WR4.GetResponse();
            StreamReader data4 = new StreamReader(Response4.GetResponseStream());
            string JsonData4 = data4.ReadToEnd();
            JObject CarData4 = JObject.Parse("{years:" + JsonData4 + "}");
            ViewBag.CarYears = CarData4["years"];

            HttpWebRequest WR3 = WebRequest.CreateHttp($"http://localhost:57743/api/Car/ListofColors");
            WR3.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response3 = (HttpWebResponse)WR3.GetResponse();
            StreamReader data3 = new StreamReader(Response3.GetResponseStream());
            string JsonData3 = data3.ReadToEnd();
            JObject CarData3 = JObject.Parse("{colors:" + JsonData3 + "}");
            ViewBag.CarColors = CarData3["colors"];

            HttpWebRequest WR2 = WebRequest.CreateHttp($"http://localhost:57743/api/Car/ListofMakes");
            WR2.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response2 = (HttpWebResponse)WR2.GetResponse();
            StreamReader data2 = new StreamReader(Response2.GetResponseStream());
            string JsonData2 = data2.ReadToEnd();
            JObject CarData2 = JObject.Parse("{makes:" + JsonData2 + "}");
            ViewBag.CarMakes = CarData2["makes"];

            HttpWebRequest WR = WebRequest.CreateHttp($"http://localhost:57743/api/Car/ListofModels");
            WR.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response = (HttpWebResponse)WR.GetResponse();
            StreamReader data = new StreamReader(Response.GetResponseStream());           
            string JsonData= data.ReadToEnd();
            JObject CarData = JObject.Parse("{models:" + JsonData + "}");
            ViewBag.CarModels = CarData["models"];


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

        public ActionResult ListAllCars()
        {
            HttpWebRequest WR = WebRequest.CreateHttp("http://localhost:57743/api/Car/GetAllCars");
            WR.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response = (HttpWebResponse)WR.GetResponse();
            StreamReader data = new StreamReader(Response.GetResponseStream());
            string JsonData = data.ReadToEnd();
            JObject CarData = JObject.Parse("{cars:"+JsonData+"}");
            ViewBag.Cars = CarData;
            return View("ListofCars"); 
        }

        public ActionResult ListCarsByMakeandModel(string make, string model)
        {
            HttpWebRequest WR = WebRequest.CreateHttp("http://localhost:57743/api/Car/GetCarsbyMakeandModel?make="+ make + "&model="+ model);
            WR.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response = (HttpWebResponse)WR.GetResponse();
            StreamReader data = new StreamReader(Response.GetResponseStream());
            string JsonData = data.ReadToEnd();
            JObject CarData = JObject.Parse("{cars:"+JsonData+"}");
            ViewBag.Cars = CarData;
            return View("ListofCars");
        }

        public ActionResult GetCarsByMake(string make)
        {
            HttpWebRequest WR = WebRequest.CreateHttp("http://localhost:57743/api/Car/GetCarsbyMake?make=" + make);
            WR.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
            HttpWebResponse Response = (HttpWebResponse)WR.GetResponse();
            StreamReader data = new StreamReader(Response.GetResponseStream());
            string JsonData = data.ReadToEnd();
            JObject CarData = JObject.Parse("{cars:" + JsonData + "}");
            ViewBag.Cars = CarData;
            return View("ListofCars");
        }
    }
}