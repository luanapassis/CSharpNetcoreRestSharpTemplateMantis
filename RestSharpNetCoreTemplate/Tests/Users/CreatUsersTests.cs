using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests.Users;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    public class CreatUsersTests : TestBase
    {
        [Test]
        [Parallelizable(ParallelScope.None)]
        public void criaUsuario()
        {
            #region parametros
            string userName = "usuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            string id = response.Data["user"]["id"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.That(response.StatusDescription.Contains(id));
            });
        }
        
    }    
}
