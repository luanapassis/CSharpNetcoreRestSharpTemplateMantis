using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
	public class GetIssueMonitoredByMeRequest : RequestBase
	{
		public GetIssueMonitoredByMeRequest()
		{
			requestService = "/api/rest/issues?filter_id=monitored";
			method = Method.GET;
		}
	}
}
