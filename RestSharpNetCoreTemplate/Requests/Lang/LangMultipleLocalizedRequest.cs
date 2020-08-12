using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Lang
{
    class PageMultipleLocalizedRequest : RequestBase
    {
        public PageMultipleLocalizedRequest(string string1, string string2, string string3, string string4, string string5)
        {
            requestService = "/api/rest/lang?string[]=string1&string[]=string2&string[]=string3&string[]=string4&string[]=string5";
            method = Method.GET;
            requestService = requestService.Replace("string1", string1);
            requestService = requestService.Replace("string2", string2);
            requestService = requestService.Replace("string3", string3);
            requestService = requestService.Replace("string4", string4);
            requestService = requestService.Replace("string5", string5);
        }
            
    }
}
