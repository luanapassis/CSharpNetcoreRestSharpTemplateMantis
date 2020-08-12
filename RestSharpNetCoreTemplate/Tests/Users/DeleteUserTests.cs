using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.DBSteps;
using RestSharpNetCoreTemplate.Requests.Users;

namespace RestSharpNetCoreTemplate.Tests.Users
{
    public class DeleteUserTests : TestBase
    {
        public DataBaseSteps dataBaseSteps = new DataBaseSteps();

        
        [Test]
        [Parallelizable(ParallelScope.None)]
        public void deletaUsuario()
        {
            string usuarioDeletar = "testeAPIDeletar";
            string idUsuarioDeletar = dataBaseSteps.retornaidUsuario(usuarioDeletar);
                
            DeleteUserRequest deleteUserRequest = new DeleteUserRequest(idUsuarioDeletar);
            IRestResponse<dynamic> response = deleteUserRequest.ExecuteRequest();

            Assert.That(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }

        [Test]
        [Parallelizable(ParallelScope.None)]
        public void deletaUsuarioInexistente()
        {
            string idUsuarioDeletar = "99999";

            DeleteUserRequest deleteUserRequest = new DeleteUserRequest(idUsuarioDeletar);
            IRestResponse<dynamic> response = deleteUserRequest.ExecuteRequest();

            Assert.That(response.StatusCode == System.Net.HttpStatusCode.NoContent);
        }
    }
}
