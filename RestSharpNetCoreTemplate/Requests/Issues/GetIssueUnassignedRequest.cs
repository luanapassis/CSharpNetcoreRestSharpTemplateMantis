using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
	public class GetIssueUnassignedRequest : RequestBase
	{
		public GetIssueUnassignedRequest()
		{
			requestService = "/api/rest/issues?filter_id=unassigned";
			method = Method.GET;
		}
	}
}
