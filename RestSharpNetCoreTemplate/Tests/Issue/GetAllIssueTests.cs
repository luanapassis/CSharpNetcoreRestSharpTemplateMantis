using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.DataDriven;
using RestSharpNetCoreTemplate.Requests.Issues;

//[assembly: LevelOfParallelism(25)]
namespace RestSharpNetCoreTemplate.Tests.Issue
{
    //[Parallelizable(ParallelScope.All)]
    public class GetAllIssueTests : TestBase
	{
        [Test]
        public void VerificaQuantidadeRegistroPorPaginaDataDriven()
        {

            String fileName = @"C:\Users\Base2\Desktop\Ole\restSharpNetcoreTemplate\RestSharpNetCoreTemplate\DataDriven\IssueData.xlsx";

            int quantidadeLinhasPlanilha = 7; 
            for (int rowNumber = 1; rowNumber <= quantidadeLinhasPlanilha; rowNumber++)
            {
                ExcelUtil util = new ExcelUtil();
                util.PopulateInCollection(fileName);
                String pageSize = util.ReadData(rowNumber, "Column0");
                String page = util.ReadData(rowNumber, "Column1");


                GetAllIssuesRequest getAllIssuesRequest = new GetAllIssuesRequest(pageSize, page);

                IRestResponse<dynamic> response = getAllIssuesRequest.ExecuteRequest();

                Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);

                string[] arrayRegex = new string[]
                {
                    "\"description\":(.*?)",
                };
                MatchCollection matches;
                foreach (string regex in arrayRegex)
                {
                    matches = new Regex(regex).Matches(response.Content);
                    Assert.That(matches.Count == Convert.ToInt32(pageSize));
                }
            }

        }



    }
}
