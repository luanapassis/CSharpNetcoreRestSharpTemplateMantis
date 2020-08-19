using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Projects
{
	public class GetAProjectRequest : RequestBase
	{
		public GetAProjectRequest(string projectId)
		{
			requestService = "/api/rest/projects/{projectId}";
			method = RestSharp.Method.GET;

			parameters.Add("projectId", projectId);
		}
	}
}
