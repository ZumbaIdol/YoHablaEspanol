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
            dict.Add(new KeyValuePair<string, string>("cambiar", "change"));
            dict.Add(new KeyValuePair<string, string>("corre", "run"));
            dict.Add(new KeyValuePair<string, string>("inmediatamente", "immediately"));
            dict.Add(new KeyValuePair<string, string>("rojo", "red"));

            //Put that on the page somewhere
            IEnumerable<TValue> RandomValues<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
            {
                Random rand = new Random();
                List<TValue> values = Enumerable.ToList(dictionary.Values);
                int size = dictionary.Count;
                while (true)
                {
                    yield return values[rand.Next(size)];
                }
            }

            Dictionary<string, object> getDict = GetDictionary();
            foreach (object value in RandomValues(dict).Take(5))
            {
                return View();
            }

            //New view model here
            return View();
        }

        private Dictionary<string, object> GetDictionary() => throw new NotImplementedException();

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
    
