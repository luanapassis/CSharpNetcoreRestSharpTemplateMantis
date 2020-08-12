using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class GetAnIssueRequest : RequestBase
    {
        public GetAnIssueRequest(string issue_id)
        {
            requestService = "/api/rest/issues/{issue}";
            method = Method.GET;

            parameters.Add("issue", issue_id);
        }
    }
}
