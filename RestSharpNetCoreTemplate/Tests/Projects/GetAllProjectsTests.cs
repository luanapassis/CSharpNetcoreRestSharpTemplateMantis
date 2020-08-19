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
    class GetAllProjectsTests : TestBase
	{
        [Test]
        public void RetornaTodosProjetos()
        {
            string nomeProjetoEsperado = "Teste";
            string idProjetoEsperado = "1";

            GetAllProjectsRequest getAllProjectsRequest = new GetAllProjectsRequest();
            
            IRestResponse<dynamic> response = getAllProjectsRequest.ExecuteRequest();

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
        public void RetornaTodosProjetosVerificaSubProjeto()
        {
            string nomeProjetoEsperado = "Teste SubProjeto";
            string idProjetoEsperado = "2";

            GetAllProjectsRequest getAllProjectsRequest = new GetAllProjectsRequest();

            IRestResponse<dynamic> response = getAllProjectsRequest.ExecuteRequest();

            string idProjetoRetornado = response.Data["projects"][1]["id"];
            string nomeProjetoRetornado = response.Data["projects"][1]["name"];

            Assert.Multiple(() =>
            {
                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);
                Assert.AreEqual(nomeProjetoEsperado, nomeProjetoRetornado);
                Assert.AreEqual(idProjetoEsperado, idProjetoRetornado);
            });
        }
    }
}
