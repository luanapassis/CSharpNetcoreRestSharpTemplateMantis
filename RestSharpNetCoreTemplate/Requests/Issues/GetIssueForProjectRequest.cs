using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
	public class GetIssueForProjectRequest : RequestBase
	{
		public GetIssueForProjectRequest(string idProject)
		{
			requestService = "/api/rest/issues?project_id="+idProject;
			method = Method.GET;
		}
	}
}
