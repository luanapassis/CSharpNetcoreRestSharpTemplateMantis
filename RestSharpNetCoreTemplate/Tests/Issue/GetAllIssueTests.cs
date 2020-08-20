using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.DataDriven;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests.Issues;

//[assembly: LevelOfParallelism(25)]
//define a quantidade de teste sexecutados em paralalo

namespace RestSharpNetCoreTemplate.Tests.Issue
{
    //[Parallelizable(ParallelScope.All)]
    public class GetAllIssueTests : TestBase
	{
        [TestCaseSource(typeof(GetAllIssueDataDriven), "GetAllIssueTestCases")]
        public void VerificaQuantidadeRegistroPorPaginaDataDriven(string pageSize, string page)
        {

            GetAllIssuesRequest getAllIssuesRequest = new GetAllIssuesRequest(pageSize, page);

            IRestResponse<dynamic> response = getAllIssuesRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"description\":(.*?)",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count == Convert.ToInt32(pageSize));
            }            

        }
        
    }
    
}
