using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
	public class GetIssueReportedByMeRequest: RequestBase
	{
		public GetIssueReportedByMeRequest()
		{
			requestService = "/api/rest/issues?filter_id=reported";
			method = Method.GET;
		}
	}
}
