using RestSharpNetCoreTemplate.Helpers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharpNetCoreTemplate.Bases;

namespace RestSharpNetCoreTemplate.Requests.Users
{
    public class DeleteUserRequest : RequestBase
    {
        public DeleteUserRequest(string userId)
        {
            requestService = "/api/rest/users/{userId}";
            method = Method.DELETE;

            parameters.Add("userId", userId);
        }
    }
}
