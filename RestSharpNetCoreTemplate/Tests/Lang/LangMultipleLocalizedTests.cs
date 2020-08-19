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
   //[Parallelizable(ParallelScope.All)]
    public class LangMultipleLocalizedTests : TestBase
    {
        [Test]
        public void RetornaStringsBackToBugLink()
        {
            string string1 = "back_to_bug_link";
            PageMultipleLocalizedRequest pageMultipleLocalizedRequest = new PageMultipleLocalizedRequest(string1);

            IRestResponse<dynamic> response = pageMultipleLocalizedRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"name\":(.*?)\"back_to_bug_link",
                "\"localized\":(.*?)\"Back To Issue",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count > 0, "Esperado: " + regex + " Encontrado:" + response.Content);
            }

        }
        [Test]
        public void RetornaStringUpdateSimpleLink()
        {
            string string1 = "update_simple_link";
            PageMultipleLocalizedRequest pageMultipleLocalizedRequest = new PageMultipleLocalizedRequest(string1);

            IRestResponse<dynamic> response = pageMultipleLocalizedRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"name\":(.*?)\"update_simple_link",
                "\"localized\":(.*?)\"Update Simple",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count > 0, "Esperado: " + regex + " Encontrado:" + response.Content);
            }

        }
        [Test]
        public void RetornaStringCategory()
        {
            string string1 = "category";
            PageMultipleLocalizedRequest pageMultipleLocalizedRequest = new PageMultipleLocalizedRequest(string1);

            IRestResponse<dynamic> response = pageMultipleLocalizedRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"name\":(.*?)\"category",
                "\"localized\":(.*?)\"Category",
            };
            MatchCollection matches;
            foreach (string regex in arrayRegex)
            {
                matches = new Regex(regex).Matches(response.Content);
                Assert.That(matches.Count > 0, "Esperado: " + regex + " Encontrado:" + response.Content);
            }

        }
        [Test]
        public void RetornaStringReproducibility()
        {
            string string1 = "reproducibility";
            PageMultipleLocalizedRequest pageMultipleLocalizedRequest = new PageMultipleLocalizedRequest(string1);

            IRestResponse<dynamic> response = pageMultipleLocalizedRequest.ExecuteRequest();

            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

            string[] arrayRegex = new string[]
            {
                "\"name\":(.*?)\"reproducibility",
                "\"localized\":(.*?)\"Reproducibility",
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
