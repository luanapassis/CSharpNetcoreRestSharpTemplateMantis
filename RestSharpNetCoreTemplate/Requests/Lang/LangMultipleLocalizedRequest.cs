using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Lang
{
    class PageMultipleLocalizedRequest : RequestBase
    {
        public PageMultipleLocalizedRequest(string string1)
        {
            requestService = "/api/rest/lang?string[]="+string1;
            method = Method.GET;

        }
            
    }
}
