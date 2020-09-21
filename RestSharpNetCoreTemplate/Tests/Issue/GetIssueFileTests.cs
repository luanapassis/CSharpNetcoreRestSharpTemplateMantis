using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.Lang;
using RestSharpNetCoreTemplate.Requests.Issues;
using RestSharpNetCoreTemplate.DBSteps;


namespace RestSharpNetCoreTemplate.Tests.Issue
{
    //[Parallelizable(ParallelScope.All)]
    public class GetIssueFileTests: TestBase
    {

        [Test]
        public void RetornaTarefaSemDocumento()
        {
            List<string> tarefa = dataBaseSteps.retornaTarefaSemDocumento();

            string issueId = tarefa[0];

            GetIssueFileRequest getIssueFileRequest = new GetIssueFileRequest(issueId);

            IRestResponse<dynamic> response = getIssueFileRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            Assert.IsFalse(response.Content.Contains("id"));
            
        }
    }
}
