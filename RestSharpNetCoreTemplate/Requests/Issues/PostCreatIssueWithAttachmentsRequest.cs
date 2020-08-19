using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using RestSharpNetCoreTemplate.Bases;
using RestSharpNetCoreTemplate.Helpers;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
	public class PostCreatIssueWithAttachmentsRequest : RequestBase
	{
		public PostCreatIssueWithAttachmentsRequest()
		{
			requestService = "/api/rest/issues";
			method = RestSharp.Method.POST;
		}

		public void SetJsonBody(
								 string summary,
								 string description,
								 string projectId,
								 string projectName,
								 string categoryId,
								 string categoryName,
								 string fileName,
								 string fileContent
			)
		{
			jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons\\Issue\\CreateIssueWithattachmentsJson.json", Encoding.UTF8);
			jsonBody = jsonBody.Replace("$summary", summary);
			jsonBody = jsonBody.Replace("$description", description);
			jsonBody = jsonBody.Replace("$projectId", projectId);
			jsonBody = jsonBody.Replace("$projectName", projectName);
			jsonBody = jsonBody.Replace("$categoryId", categoryId);
			jsonBody = jsonBody.Replace("$categoryName", categoryName);
			jsonBody = jsonBody.Replace("$fileName", fileName);
			jsonBody = jsonBody.Replace("$fileContent", fileContent);
		}
	}
}
