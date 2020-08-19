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
using RestSharpNetCoreTemplate.DBSteps;


namespace RestSharpNetCoreTemplate.Tests.Users
{
    //[Parallelizable(ParallelScope.All)]
    public class CreatUsersTests : TestBase
    {
        public DataBaseSteps dataBaseSteps = new DataBaseSteps();

        [Test]
        public void CriaUsuarioSucesso()
        {
            #region parametros
            string userName = "usuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
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
        [Test]
        public void CriaUsuarioSemNome()
        {
            #region parametros
            string userName = "";
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";

            string mensagemEsperada = "Invalid username ''";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

        [Test]
        public void CriaUsuarioNivelDeAcessoInvalido()
        {
            #region parametros
            string userName = "usuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "sfsdaf";
            string enabled = "true";
            string protectedd = "false";

            string mensagemEsperada = "Invalid access level";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }
        [Test]
        public void CriaUsuarioJaExistente()
        {
            #region parametros
            string userName = "Teste";
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";

            string mensagemEsperada = "Username '"+userName+"' already used.";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

        [Test]
        public void CriaUsuarioEmailJaExistente()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "luana.assis1@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";

            string mensagemEsperada = "Email '"+email+"' already used.";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

        [Test]
        public void CriaUsuarioEnabledTrue()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "1";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[5]);
            });
        }
        [Test]
        public void CriaUsuarioEnabledFalse()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";// "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "false";
            string protectedd = "false";

            string retornoEsperado = "0";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[5]);
            });
        }

        [Test]
        public void CriaUsuarioProtectedTrue()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "true";

            string retornoEsperado = "1";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[6]);
            });
        }

        [Test]
        public void CriaUsuarioProtectedFalse()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "0";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[6]);
            });
        }

        [Test]
        public void CriaUsuarioVisualizador()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "viewer";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "10";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[7]);
            });
        }
        [Test]
        public void CriaUsuarioRelator()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "reporter";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "25";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[7]);
            });
        }
        [Test]
        public void CriaUsuarioAtualizador()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";// "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "updater";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "40";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[7]);
            });
        }

        [Test]
        public void CriaUsuarioDesenvolvedor()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";// "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "developer";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "55";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[7]);
            });
        }
        [Test]
        public void CriaUsuarioGerente()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";// "emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "manager";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "70";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[7]);
            });
        }
        [Test]
        public void CriaUsuarioAdministrador()
        {
            #region parametros
            string userName = "usuarioAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string password = "p@ssw0rd";
            string realName = "RealNameusuAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string email = "";//"emailUsuApi" + GeneralHelpers.ReturnStringWithRandomCharacters(3) + "@gmail.com";
            string accessLevel = "administrator";
            string enabled = "true";
            string protectedd = "false";

            string retornoEsperado = "90";
            #endregion

            CreatUsersRequest creatUsersRequest = new CreatUsersRequest();
            creatUsersRequest.SetJsonBody(userName, password, realName, email, accessLevel, enabled, protectedd);

            IRestResponse<dynamic> response = creatUsersRequest.ExecuteRequest();

            List<string> resultado = dataBaseSteps.retornaUsuario(userName);

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("User created"));
                Assert.AreEqual(retornoEsperado, resultado[7]);
            });
        }

    }    
}
