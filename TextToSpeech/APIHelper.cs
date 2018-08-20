using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace TextToSpeech
{
    public static class APIHelper
    {
        public static T Get<T>(string baseUrl, Method method, string resource) where T : new()
        {
            RestClient client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(resource, method);
            var response = client.Get<T>(request);
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
