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
    public class GetIssueFile: TestBase
    {

        [Test]
        [Parallelizable(ParallelScope.None)]
        public void retornaDocumentoTarefa_fazendo()
        {
            string tarefa = "15";
            string idDocumento = "1";

            GetIssueFileRequest getIssueFileRequest = new GetIssueFileRequest(tarefa, idDocumento);

            IRestResponse<dynamic> response = getIssueFileRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            /*string[] arrayRegex = new string[]
            {
                //fazer
                "\"message\":(.*?)\"Issue # not found",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count > 0, "Esperado: " + regex + " Encontrado:" + response.Content);
            }
            */
        }
    }
}
