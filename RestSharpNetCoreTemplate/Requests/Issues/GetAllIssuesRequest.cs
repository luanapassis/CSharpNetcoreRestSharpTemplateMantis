using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Issues
{
    public class GetAllIssuesRequest : RequestBase
    {
        public GetAllIssuesRequest(string pageSize, string page)
        {
            requestService = "/api/rest/issues?page_size="+pageSize+"&page="+page;
            method = Method.GET;

        }
    }
}
