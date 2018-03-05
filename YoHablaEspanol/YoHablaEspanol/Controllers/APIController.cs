using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using YoHablaEspanol.Models;
using YoHablaEspanol.Services;

namespace YoHablaEspanol.Controllers
{
    public class APIController : Controller
    {
        
        public IActionResult Index()
        {
            //Pick a word from the database
            IDictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add(new KeyValuePair<string, string>("feliz", "happy"));
            dict.Add(new KeyValuePair<string, string>("corre", "run"));
            dict.Add(new KeyValuePair<string, string>("absolutamente", "absolutely"));
            dict.Add(new KeyValuePair<string, string>("azul", "blue"));
            dict.Add(new KeyValuePair<string, string>("hombre", "man"));

            IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
            {
                Random rand = new Random();
                List<TValue> values = Enumerable.ToList(dictionary.Values);
                int size = dictionary.Count;
                while (true)
                {
                    yield return dictionary.ElementAt(rand.Next(0, dictionary.Count)).Value;
                }
            }

            { 
                //New view model here
                return View();
            }
        }
        [HttpPost]
        public IActionResult Index(string translation, string pretranslation)
        {
            var translationService = new TranslationService();
            var translatedWord = translationService.TranslateFromSpanishToEnglish(translation);

            //Check if their translation is equals translated word from the API

            //New model

            //Pass that to the view with the results
            return View();
        }
    }
}
    
