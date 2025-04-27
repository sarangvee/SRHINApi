using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRHINApi.StepDefinitions
{
    [Binding]
    public class API01Step
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        String responseBody;

        public API01Step()
        {
            httpClient = new HttpClient();
        }

        [Given("load the URL {string}")]
        public async Task GivenLoadTheURL(string uri)
        {
            response= await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            responseBody= await response.Content.ReadAsStringAsync();
            Console.WriteLine("Test URL {0}", uri);
            Console.WriteLine("Test Body {0}", responseBody);
        }

        [Then("verify the response status code is {int}")]
        public void ThenVerifyTheResponseStatusCodeIs(int statuscode)
        {
            Console.WriteLine("Then verify the response status code is {0}", statuscode);
        }

    }
}
