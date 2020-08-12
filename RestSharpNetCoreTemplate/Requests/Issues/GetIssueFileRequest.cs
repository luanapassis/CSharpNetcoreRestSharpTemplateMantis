using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class GetIssueFileRequest : RequestBase
    {
        public GetIssueFileRequest(string issue_id, string file_id)
        {
            requestService = "/api/rest/issues/{issue_id}/files/{file_id}";
            method = Method.GET;

            parameters.Add("issue_id", issue_id);
            parameters.Add("file_id", file_id);
        }
    }
}
