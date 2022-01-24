using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Configuration;
using Test_API.API;

class TokenPriceController
{
    /// <summary>
    /// Get the price of the WoW token in Real-time
    /// </summary>
    /// <returns></returns>
    public static async Task<string> GetTokenPrice()
    {
        try
        {
            string bearerToken = System.Configuration.ConfigurationManager.AppSettings.Get("blizzard_BearerToken");
            if (bearerToken == null)
                throw new ConfigurationErrorsException();

            string url = "https://us.api.blizzard.com/data/wow/token/?namespace=dynamic-us";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
                HttpResponseMessage response = await client.GetAsync(url);
                string str = await response.Content.ReadAsStringAsync();
                var result = getTokenPriceSanitized(str);

                return result;
            }
        }
        catch (ConfigurationErrorsException)
        {
            return "Cannot find the Blizzard token ID";
        }
        catch (Exception e)
        {
            return $"Exception raised when trying to reach blizzard token API : {e}";
        }
    }

    private static string getTokenPriceSanitized(string jsonResponse)
    {
        var jsonObjectPrice = JObject.Parse(jsonResponse);
        string price = jsonObjectPrice["price"].ToString();

        //Get the token in a readable state
        string firstSix = price.Substring(0,3) + "." + price.Substring(3,3);
        string strPrice = $@"Token price = {firstSix}";

        return strPrice;
    }
}