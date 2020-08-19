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
    public class GetIssueMonitoredByMeTests : TestBase
	{
        [Test]
        public void RetornaTarefasReportadasPorMim()
        {
            GetIssueMonitoredByMeRequest getIssueMonitoredByMeRequest = new GetIssueMonitoredByMeRequest();

            IRestResponse<dynamic> response = getIssueMonitoredByMeRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

        }
    }
}
