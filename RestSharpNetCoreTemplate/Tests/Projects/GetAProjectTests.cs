using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Requests.Projects;

namespace RestSharpNetCoreTemplate.Tests.Projects
{

   //[Parallelizable(ParallelScope.All)]
    public class GetAProjectTests : TestBase
    {
        [Test]
        public void RetornaProjetoPrincipal()
        {
            string nomeProjetoEsperado = "Teste";
            string idProjetoEsperado = "1";

            GetAProjectRequest getAProjectRequest = new GetAProjectRequest(idProjetoEsperado);

            IRestResponse<dynamic> response = getAProjectRequest.ExecuteRequest();

            string idProjetoRetornado = response.Data["projects"][0]["id"];
            string nomeProjetoRetornado = response.Data["projects"][0]["name"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(nomeProjetoEsperado, nomeProjetoRetornado);
                Assert.AreEqual(idProjetoEsperado, idProjetoRetornado);
            });
        }
        [Test]
        public void RetornaSubProjeto()
        {
            string nomeProjetoEsperado = "Teste SubProjeto";
            string idProjetoEsperado = "2";

            GetAProjectRequest getAProjectRequest = new GetAProjectRequest(idProjetoEsperado);

            IRestResponse<dynamic> response = getAProjectRequest.ExecuteRequest();

            string idProjetoRetornado = response.Data["projects"][0]["id"];
            string nomeProjetoRetornado = response.Data["projects"][0]["name"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(nomeProjetoEsperado, nomeProjetoRetornado);
                Assert.AreEqual(idProjetoEsperado, idProjetoRetornado);
            });
        }
        [Test]
        public void RetornaProjetoInvalido()
        {
            string idProjetoEsperado = "99";
            string mensagemEsperada = "Project #99 not found";

            GetAProjectRequest getAProjectRequest = new GetAProjectRequest(idProjetoEsperado);

            IRestResponse<dynamic> response = getAProjectRequest.ExecuteRequest();

            string mensagemRetornada = response.Data["message"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.NotFound, response.StatusCode);
                Assert.AreEqual(mensagemEsperada, mensagemRetornada);
            });
        }
        [Test]
        public void VerificaStatusProjeto()
        {
            string statusEsperado = "True";
            string idProjetoEsperado = "2";

            GetAProjectRequest getAProjectRequest = new GetAProjectRequest(idProjetoEsperado);

            IRestResponse<dynamic> response = getAProjectRequest.ExecuteRequest();

            string statusRecebido = response.Data["projects"][0]["enabled"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(statusEsperado, statusRecebido);
            });
        }

    }
}
