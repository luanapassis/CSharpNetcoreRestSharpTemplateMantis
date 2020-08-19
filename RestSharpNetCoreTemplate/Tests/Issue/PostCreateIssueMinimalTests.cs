using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issue
{
   //[Parallelizable(ParallelScope.All)]
    public class PostCreateIssueMinimalTests : TestBase
	{
        [Test]
        public void CriaTarefaSucesso()
        {
            #region parametros
            string summary = "SummaryAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string categoryName = "General";
            string projectName = "Teste";

            #endregion

            PostCreatIssueMinimalRequest postCreatIssueMinimalRequest = new PostCreatIssueMinimalRequest();
            postCreatIssueMinimalRequest.SetJsonBody(summary, description, categoryName, projectName);

            IRestResponse<dynamic> response = postCreatIssueMinimalRequest.ExecuteRequest();

            string id = response.Data["issue"]["id"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("Issue Created"));
                Assert.That(response.StatusDescription.Contains(id));
            });
        }
        [Test]
        public void CriaTarefaSemNome()
        {
            #region parametros
            string summary = "";
            string description = "DescriptionAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string categoryName = "General";
            string projectName = "Teste";

            string mensagemEsperada = "Summary not specified";

            #endregion

            PostCreatIssueMinimalRequest postCreatIssueMinimalRequest = new PostCreatIssueMinimalRequest();
            postCreatIssueMinimalRequest.SetJsonBody(summary, description, categoryName, projectName);

            IRestResponse<dynamic> response = postCreatIssueMinimalRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }
        [Test]
        public void CriaTarefaSemDescricao()
        {
            #region parametros
            string summary = "SummaryAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "";
            string categoryName = "General";
            string projectName = "Teste";

            string mensagemEsperada = "Description not specified";

            #endregion

            PostCreatIssueMinimalRequest postCreatIssueMinimalRequest = new PostCreatIssueMinimalRequest();
            postCreatIssueMinimalRequest.SetJsonBody(summary, description, categoryName, projectName);

            IRestResponse<dynamic> response = postCreatIssueMinimalRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

        [Test]
        public void CriaTarefaSemProjeto()
        {
            #region parametros
            string summary = "SummaryAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string categoryName = "General";
            string projectName = "";

            string mensagemEsperada = "Project not specified";

            #endregion

            PostCreatIssueMinimalRequest postCreatIssueMinimalRequest = new PostCreatIssueMinimalRequest();
            postCreatIssueMinimalRequest.SetJsonBody(summary, description, categoryName, projectName);

            IRestResponse<dynamic> response = postCreatIssueMinimalRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

        [Test]
        public void CriaTarefaProjetoInvalido()
        {
            #region parametros
            string summary = "SummaryAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string categoryName = "General";
            string projectName = "sfsadfafadasfsdafa";

            string mensagemEsperada = "Project not specified";

            #endregion

            PostCreatIssueMinimalRequest postCreatIssueMinimalRequest = new PostCreatIssueMinimalRequest();
            postCreatIssueMinimalRequest.SetJsonBody(summary, description, categoryName, projectName);

            IRestResponse<dynamic> response = postCreatIssueMinimalRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }
    }
}
