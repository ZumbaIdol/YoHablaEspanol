using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using YoHablaEspanol.Models;

namespace YoHablaEspanol.Services
{
    public class TranslationService
    {

        public string TranslateFromSpanishToEnglish(string word)
        {
            HttpWebRequest req = null;

            string PrimeUrl = "https://od-api.oxforddictionaries.com/api/v1";
            string endPoint = string.Format("/entries/es/{0}/translations=en", word);
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
                var jsonObject = JsonConvert.DeserializeObject<Rootobject>(theJson);
                var translation = jsonObject.results[0].lexicalEntries[0].entries[0].senses[0].translations[0].text;
                return translation;

            }
        }
    }
}
