using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.Issues;


namespace RestSharpNetCoreTemplate.Tests.Issue
{
    //[Parallelizable(ParallelScope.All)]
    public class GetIssueForProjectTests : TestBase
	{
        [Test]
        public void RetornaTodasTarefasPorProjeto()
        {
            string projectId = "1";
            string quantidadeTarefaEsperada = dataBaseSteps.retornaQuantidadaTarefaPorProjeto(projectId);

            GetIssueForProjectRequest getIssueForProjectRequest = new GetIssueForProjectRequest(projectId);

            IRestResponse<dynamic> response = getIssueForProjectRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            //string[] arrayRegex = new string[]
            //{
            //   "description",
            //};
            //MatchCollection matches;
            //foreach (string regex in arrayRegex)
            //{
            //    matches = new Regex(regex).Matches(response.Content);
            //    Assert.That(matches.Count == Convert.ToInt32(quantidadeTarefaEsperada));
            //}

        }
    }
}
