using RestSharpNetCoreTemplate.Helpers;
using RestSharp;
using RestSharpNetCoreTemplate.Bases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharpNetCoreTemplate.Requests.Users
{
    public class UsersInfoRequest : RequestBase
    {
        public UsersInfoRequest()
        {
            requestService = "/api/rest/users/me";
            method = Method.GET;
        }
    }
}
