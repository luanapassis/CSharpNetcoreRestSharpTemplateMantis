using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests;
using RestSharpNetCoreTemplate.Requests.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issue
{
   //[Parallelizable(ParallelScope.All)]
    public class PostCreateIssueWithAttachmentsTests : TestBase
	{
        [Test]
        public void CriaTarefaComAnexoSucesso()
        {
            string summary = "SummaryAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string projectId = "1";
            string projectName = "Teste";
            string categoryId = "1";
            string categoryName = "General";
            string fileName = "teste.txt";
            string fileContent = "aaaa";

            PostCreatIssueWithAttachmentsRequest postCreatIssueWithAttachmentsRequest = new PostCreatIssueWithAttachmentsRequest();
            postCreatIssueWithAttachmentsRequest.SetJsonBody(summary, description, projectId,
                                               projectName, categoryId, categoryName, fileName,
                                               fileContent);

            IRestResponse<dynamic> response = postCreatIssueWithAttachmentsRequest.ExecuteRequest();

            string id = response.Data["issue"]["id"];
            

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("Issue Created"));
                Assert.That(response.StatusDescription.Contains(id));
            });
        }

        [Test]
        public void teste()
        {
            var client = new RestClient("http://localhost/mantis/api/rest/issues/10");

            var request = new RestRequest(Method.GET);
            request.AddHeader("Authorization", "t4VJIkRw6SsgcGY1ZaDjFKe6kp9jcOty");

            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
        }
    }
}
