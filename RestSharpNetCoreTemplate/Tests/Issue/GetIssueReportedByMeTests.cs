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
    public class GetIssueReportedByMeTests : TestBase
	{
        [Test]
        public void RetornaTarefasReportadasPorMim()
        {
            GetIssueReportedByMeRequest getIssueReportedByMeRequest = new GetIssueReportedByMeRequest();

            IRestResponse<dynamic> response = getIssueReportedByMeRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
                       
        }
    }
}
