using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.Users;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    public class UsersInfoTests : TestBase
    {
        [Test]
        [Parallelizable(ParallelScope.None)]
        public void returnUserLogged()
        {
            string status = "OK";


            UsersInfoRequest usersInfoRequest = new UsersInfoRequest();

            IRestResponse<dynamic> response = usersInfoRequest.ExecuteRequest();

            Assert.AreEqual(status, response.StatusCode.ToString());

            string[] arrayRegex = new string[]
            {
                "\"id\":(.*?)1",
                "\"name\":(.*?)\"administrator\"",
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
