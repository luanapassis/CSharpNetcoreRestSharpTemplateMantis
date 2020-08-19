using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class GetIssueAssignedForMeRequest : RequestBase
    {
        public GetIssueAssignedForMeRequest()
        {
            requestService = "/api/rest/issues?filter_id=assigned";
            method = Method.GET;
        }
    }
}
