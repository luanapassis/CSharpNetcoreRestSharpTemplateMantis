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
    public class GetIssueUnassignedTests : TestBase
	{
        [Test]
        public void RetornaTarefasSemUsuarioAssiciado()
        {
            GetIssueUnassignedRequest getIssueUnassignedRequest = new GetIssueUnassignedRequest();

            IRestResponse<dynamic> response = getIssueUnassignedRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

        }
    }
}
