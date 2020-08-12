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
    public class LangMultipleLocalizedTests : TestBase
    {
        [Test]
        [Parallelizable(ParallelScope.None)]
        public void langAllproject()
        {
            string string1 = "all_projects";
            string string2 = "does_not_exist";
            string string3 = "status";
            string string4 = "move_bugs";
            string string5 = "status_enum_string";
            PageMultipleLocalizedRequest pageMultipleLocalizedRequest = new PageMultipleLocalizedRequest(string1, string2, string3, string4, string5);

            IRestResponse<dynamic> response = pageMultipleLocalizedRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"name\":(.*?)\"all_projects",
                "\"localized\":(.*?)\"All Projects",
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
