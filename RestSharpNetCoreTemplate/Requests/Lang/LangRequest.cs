using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Lang
{
    class LangRequest : RequestBase
    {
        public LangRequest()
        {
            requestService = "/api/rest/lang?string=all_projects";
            method = Method.GET;
            
        }
    }
}
