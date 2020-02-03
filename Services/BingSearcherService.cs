using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.CognitiveServices.Search.CustomSearch;

namespace TechAss.API.Services
{
    public class BingSearcherService : IBingSearcherService
    {
        private CustomSearchClient _client;
        private string _endpoint;
        public BingSearcherService()
        {
            _client = new CustomSearchClient(
                new ApiKeyServiceClientCredentials(
                    "4382be3ef124422b85d9d1e95784621b"
            ));

            _endpoint = 
                "https://bingapi-techass.cognitiveservices.azure.com/bingcustomsearch/v7.0";
        }

        public async Task<string> Lookup (string searchItem){
            // This will look up a single query (Xbox).
            var webData = _client.CustomInstance.SearchAsync(
                query: searchItem, customConfig: "6fba2a10-c61d-484c-8f86-d23aa4becbd4").Result;
            
            if (webData?.WebPages?.Value?.Count > 0)
            {
                var firstWebPagesResult = webData.WebPages.Value.FirstOrDefault();

                if (firstWebPagesResult != null)
                {
                    return firstWebPagesResult.Url;
                }
                else
                {
                    Console.WriteLine("Couldn't find web results!");
                }
            }
            else
            {
                Console.WriteLine("Didn't see any Web data..");
            }

            return null;
        }

    }
}