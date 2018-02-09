﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Text;

namespace YoHablaEspanol.Controllers
{
    public class APIController : Controller
    {
        public IActionResult Index()
        {

            HttpWebRequest req = null;

            string PrimeUrl = "https://od-api.oxforddictionaries.com/api/v1";
            string word = "test";
            string endPoint = string.Format("/entries/en/{0}/translations=es", word);
            req = (HttpWebRequest)HttpWebRequest.Create(string.Format("{0}{1}", PrimeUrl, endPoint));

            //These are not network credentials, just custom headers
            req.Headers.Add("app_id", "e6ecf63a");
            req.Headers.Add("app_key", "9ac2d4671bbbee67be05202d3d0d3aae");

            req.Method = WebRequestMethods.Http.Get;
            req.Accept = "application/json";

            using (HttpWebResponse HWR_Response = (HttpWebResponse)req.GetResponse())
            using (Stream respStream = HWR_Response.GetResponseStream())
            using (StreamReader sr = new StreamReader(respStream, Encoding.UTF8))
            {
                string theJson = sr.ReadToEnd();
                var jsonObject = JsonConvert.DeserializeObject(theJson);
            }

            return View();
        }
    }
}
    
