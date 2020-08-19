using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.Issues;


namespace RestSharpNetCoreTemplate.Tests.Issue
{
    //[Parallelizable(ParallelScope.All)]
    public class GetIssueFileSingleTests : TestBase
	{
        [Test]
        public void RetornaTarefaSemDocumentoPorIdDocumento()
        {
            List<string> tarefa = dataBaseSteps.retornaTarefaAleatoria();

            string issueId = tarefa[0];
            string fileId = "99";

            GetIssueFileSingleRequest getIssueFileSingleRequest = new GetIssueFileSingleRequest(issueId, fileId);

            IRestResponse<dynamic> response = getIssueFileSingleRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.IsFalse(response.Content.Contains("id"));

        }
    }
}
