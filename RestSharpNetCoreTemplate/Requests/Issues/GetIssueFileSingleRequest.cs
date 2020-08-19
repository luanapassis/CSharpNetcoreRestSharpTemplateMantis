using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class GetIssueFileSingleRequest : RequestBase
    {
        public GetIssueFileSingleRequest(string issueId, string fileId)
        {
            requestService = "/api/rest/issues/{issue_id}/files/{file_id}";            
            method = Method.GET;

            parameters.Add("issue_id", issueId);
            parameters.Add("file_id", fileId);
        }
    }
}
