using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
	public class PostCreatIssueMinimalRequest : RequestBase
	{
        public PostCreatIssueMinimalRequest()
        {
            requestService = "/api/rest/issues/";
            method = Method.POST;
        }
        public void SetJsonBody(string summary,
                                string description,
                                string categoryName,
                                string projectName)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons\\Issue\\CreateIssueMinimalJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$summary", summary);
            jsonBody = jsonBody.Replace("$description", description);
            jsonBody = jsonBody.Replace("$categoryName", categoryName);
            jsonBody = jsonBody.Replace("$projectName", projectName);
        }
    }
}
