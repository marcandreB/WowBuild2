using System.Net.Http.Headers;

namespace Test_API.API
{
    public static class ApiCalls
    {
        public static async Task<HttpResponseMessage> GetApiResponse(string token, string url)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.GetAsync(url);

                return response;
            }
        }
    }
}
