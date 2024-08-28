using PT.BLL.Dto;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System;

namespace PT.WebAPI.Helpers
{
    internal static class ExternalService
    {
        internal static List<BalanceResponsiblePartyDto> GetData(string baseURL)
        {
            using (var client = new HttpClient(new HttpClientHandler()))
            {
                client.Timeout = new TimeSpan(6, 0, 0);

                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, new Uri(baseURL)))
                {
                    request.Headers.Accept.Clear();
                    request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    var response = client.SendAsync(request).GetAwaiter().GetResult();

                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var responseContent = response.Content.ReadAsStringAsync().Result;

                        return Newtonsoft.Json.JsonConvert.DeserializeObject<List<BalanceResponsiblePartyDto>>(responseContent);
                    }
                    else
                    {
                        throw new BadHttpRequestException($"Error connecting to external service {baseURL}");
                    }
                }
            }
        }
    }
}
