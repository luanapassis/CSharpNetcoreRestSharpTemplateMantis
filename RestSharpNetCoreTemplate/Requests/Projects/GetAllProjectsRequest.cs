using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Projects
{
	public class GetAllProjectsRequest : RequestBase
	{
		public GetAllProjectsRequest()
		{
			requestService = "/api/rest/projects/";
			method = RestSharp.Method.GET;
		}

	}
}
