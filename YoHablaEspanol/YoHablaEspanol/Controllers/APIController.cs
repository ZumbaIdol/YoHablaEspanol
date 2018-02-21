using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
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

            //Put that on the page somewhere

            //New view model here
            return View();
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
    
