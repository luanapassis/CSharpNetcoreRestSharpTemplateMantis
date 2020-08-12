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
    public class GetAnIssueTests : TestBase
    {

        [Test]
        [Parallelizable(ParallelScope.None)]
        public void retornaTarefaInvalida()
        {

            string issueIdInvalida = "9999";

            GetAnIssueRequest getAnIssueRequest = new GetAnIssueRequest(issueIdInvalida);

            IRestResponse<dynamic> response = getAnIssueRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"message\":(.*?)\"Issue #"+issueIdInvalida+" not found",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count > 0, "Esperado: " + regex + " Encontrado:" + response.Content);
            }
        }
        [Test]
        [Parallelizable(ParallelScope.None)]
        public void retornaTarefaValida()
        {

            List<string> tarefa = dataBaseSteps.retornaTarefaAleatoria();

            string issueId = tarefa[0];

            GetAnIssueRequest getAnIssueRequest = new GetAnIssueRequest(issueId);

            IRestResponse<dynamic> response = getAnIssueRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"description\":\""+tarefa[30]+"\"",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count > 0, "Esperado: " + regex + " Encontrado:" + response.Content);
            }
        }
    }
}
