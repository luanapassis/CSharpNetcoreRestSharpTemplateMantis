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

namespace RestSharpNetCoreTemplate.Tests.Lang
{
    public class LangTests : TestBase
    {
        [Test]
        [Parallelizable(ParallelScope.None)]
        public void returnLanguage()
        {
            LangRequest langRequest = new LangRequest();

            IRestResponse<dynamic> response = langRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"language\":(.*?)\"english",
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
