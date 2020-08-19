using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class GetIssueFileRequest : RequestBase
    {
        public GetIssueFileRequest(string issueId)
        {
            requestService = "/api/rest/issues/{issue_id}/files";
            method = Method.GET;

            parameters.Add("issue_id", issueId);
        }
    }
}
