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
    public class GetIssueAssignedForMeTests : TestBase
	{
        [Test]
        public void RetornaTarefaAssociadaUsuario()
        {
            GetIssueAssignedForMeRequest getIssueAssignedForMeRequest = new GetIssueAssignedForMeRequest();

            IRestResponse<dynamic> response = getIssueAssignedForMeRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
            
        }
    }
}
