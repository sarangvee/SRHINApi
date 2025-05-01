using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Reqnroll.Events;
using Reqnroll.Infrastructure;
using Reqnroll.Tracing;
using SRHINApi.Support;

namespace SRHINApi.StepDefinitions
{
    [Binding]
    public class API01Step
    {
        HttpClient httpClient;
        HttpResponseMessage response;
        String responseBody;
        private readonly ReqnrollOutputHelper _output;
        private readonly ScenarioContext _scenarioContext;

        public API01Step(ITestThreadExecutionEventPublisher testThreadExecutionEventPublisher,
                         ITraceListener traceListener,
                         IReqnrollAttachmentHandler attachmentHandler, ScenarioContext scenariocontext)
        {
            httpClient = new HttpClient();
            this._output = new ReqnrollOutputHelper(testThreadExecutionEventPublisher, traceListener, attachmentHandler);
            this._scenarioContext = scenariocontext;
        }

        [Given("load the URL {string}")]
        public async Task GivenLoadTheURL(string uri)
        {
            response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            responseBody = await response.Content.ReadAsStringAsync();
            _output.WriteLine($"SRHIN API response: {responseBody}");

            //Test comment 01

            if (_scenarioContext.ScenarioInfo.Tags.Contains("tag1"))
            {
                var Jsonrsponse = JsonConvert.DeserializeObject<Datamodel.Class1[]>(responseBody);
                foreach (var item in Jsonrsponse)
                {
                    _output.WriteLine($"Deserialized ID: {item.id}");
                    _output.WriteLine($"Deserialized Code: {item.code}");
                    _output.WriteLine($"Deserialized Name: {item.name}");
                    _output.WriteLine($"Deserialized Features: {item.features}");
                    _output.WriteLine($"Deserialized Activated: {item.activated}");
                    _output.WriteLine($"Deserialized Created Date: {item.createdDate}");
                    _output.WriteLine($"Deserialized Updated Date: {item.updatedDate}");
                }
            }
            if (_scenarioContext.ScenarioInfo.Tags.Contains("tag2"))
            {
                var Jsonrsponse2 = JsonConvert.DeserializeObject<Datamodel2.Class1[]>(responseBody);
                foreach (var item in Jsonrsponse2)
                {
                    _output.WriteLine($"Deserialized ID: {item.id}");
                    _output.WriteLine($"Deserialized School ID: {item.schoolId}");
                    _output.WriteLine($"Deserialized Class IDs: {item.classIds}");
                    _output.WriteLine($"Deserialized Exam Name: {item.examName}");
                    _output.WriteLine($"Deserialized Academic Year: {item.acadamicYear}");
                    _output.WriteLine($"Deserialized Activated: {item.activated}");
                    _output.WriteLine($"Deserialized Created Date: {item.createdDate}");
                }
            }
        }

        [Then("verify the response status code is {int}")]
        public void ThenVerifyTheResponseStatusCodeIs(int statuscode)
        {
            Assert.AreEqual(statuscode, (int)response.StatusCode);
        }
    }
}
