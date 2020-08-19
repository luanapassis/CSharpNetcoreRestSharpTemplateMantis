using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;
using RestSharpNetCoreTemplate.Requests;
using RestSharpNetCoreTemplate.Requests.Issues;

namespace RestSharpNetCoreTemplate.Tests.Issue
{
   //[Parallelizable(ParallelScope.All)]
    public class PostCreatIssueTests : TestBase
	{
        [Test]
        public void CriaTarefaCompletaSucesso()
        {
            string summary = "SummaryAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string additionalInformation = "Aditional Information APi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string projectId = "1";
            string projectName = "Teste";
            string categoryId = "1";
            string categoryName = "General";
            string handlerName = "teste";
            string viewStateId = "10";
            string viewStateName = "public";
            string priorityName = "normal";
            string severityName = "trivial";
            string reproducibilityName = "always";
            string sticky = "false";
            string tagName = "mantishub";
           
            PostCreateIssueRequest postCreateIssueRequest = new PostCreateIssueRequest();
            postCreateIssueRequest.SetJsonBody(summary, description, additionalInformation, projectId,
                                               projectName, categoryId, categoryName, handlerName,
                                               viewStateId, viewStateName, priorityName, severityName,
                                               reproducibilityName, sticky, tagName);

            IRestResponse<dynamic> response = postCreateIssueRequest.ExecuteRequest();

            string id = response.Data["issue"]["id"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.Created, response.StatusCode);
                Assert.That(response.StatusDescription.Contains("Issue Created"));
                Assert.That(response.StatusDescription.Contains(id));
            });
        }

        [Test]
        public void CriaTarefaCompletaSemNome()
        {
            string summary = "";
            string description = "DescriptionAPi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string additionalInformation = "Aditional Information APi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string projectId = "1";
            string projectName = "Teste";
            string categoryId = "1";
            string categoryName = "General";
            string handlerName = "teste";
            string viewStateId = "10";
            string viewStateName = "public";
            string priorityName = "normal";
            string severityName = "trivial";
            string reproducibilityName = "always";
            string sticky = "false";
            string tagName = "mantishub";

            string mensagemEsperada = "Summary not specified";

            PostCreateIssueRequest postCreateIssueRequest = new PostCreateIssueRequest();
            postCreateIssueRequest.SetJsonBody(summary, description, additionalInformation, projectId,
                                               projectName, categoryId, categoryName, handlerName,
                                               viewStateId, viewStateName, priorityName, severityName,
                                               reproducibilityName, sticky, tagName);

            IRestResponse<dynamic> response = postCreateIssueRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }
        
        [Test]
        public void CriaTarefaCompletaSemDescricao()
        {
            string summary = "SummaryAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "";
            string additionalInformation = "Aditional Information APi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string projectId = "1";
            string projectName = "Teste";
            string categoryId = "1";
            string categoryName = "General";
            string handlerName = "teste";
            string viewStateId = "10";
            string viewStateName = "public";
            string priorityName = "normal";
            string severityName = "trivial";
            string reproducibilityName = "always";
            string sticky = "false";
            string tagName = "mantishub";

            string mensagemEsperada = "Description not specified";

            PostCreateIssueRequest postCreateIssueRequest = new PostCreateIssueRequest();
            postCreateIssueRequest.SetJsonBody(summary, description, additionalInformation, projectId,
                                               projectName, categoryId, categoryName, handlerName,
                                               viewStateId, viewStateName, priorityName, severityName,
                                               reproducibilityName, sticky, tagName);

            IRestResponse<dynamic> response = postCreateIssueRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

        [Test]
        public void CriaTarefaCompletaSemProjeto()
        {
            string summary = "SummaryAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string additionalInformation = "Aditional Information APi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string projectId = "0";
            string projectName = "";
            string categoryId = "1";
            string categoryName = "General";
            string handlerName = "teste";
            string viewStateId = "10";
            string viewStateName = "public";
            string priorityName = "normal";
            string severityName = "trivial";
            string reproducibilityName = "always";
            string sticky = "false";
            string tagName = "mantishub";

            string mensagemEsperada = "Project not specified";

            PostCreateIssueRequest postCreateIssueRequest = new PostCreateIssueRequest();
            postCreateIssueRequest.SetJsonBody(summary, description, additionalInformation, projectId,
                                               projectName, categoryId, categoryName, handlerName,
                                               viewStateId, viewStateName, priorityName, severityName,
                                               reproducibilityName, sticky, tagName);

            IRestResponse<dynamic> response = postCreateIssueRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.BadRequest, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }
        [Test]
        public void CriaTarefaCompletaProjetoIncorreto()
        {
            string summary = "SummaryAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string description = "DescriptionAPI_" + GeneralHelpers.ReturnStringWithRandomCharacters(3);
            string additionalInformation = "Aditional Information APi_" + GeneralHelpers.ReturnStringWithRandomCharacters(3); ;
            string projectId = "99";
            string projectName = "Nao Existe";
            string categoryId = "1";
            string categoryName = "General";
            string handlerName = "teste";
            string viewStateId = "10";
            string viewStateName = "public";
            string priorityName = "normal";
            string severityName = "trivial";
            string reproducibilityName = "always";
            string sticky = "false";
            string tagName = "mantishub";

            string mensagemEsperada = "Project '"+ projectId + "' not found";

            PostCreateIssueRequest postCreateIssueRequest = new PostCreateIssueRequest();
            postCreateIssueRequest.SetJsonBody(summary, description, additionalInformation, projectId,
                                               projectName, categoryId, categoryName, handlerName,
                                               viewStateId, viewStateName, priorityName, severityName,
                                               reproducibilityName, sticky, tagName);

            IRestResponse<dynamic> response = postCreateIssueRequest.ExecuteRequest();

            string mensagemRecebida = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRecebida);
            });
        }

    }
}
