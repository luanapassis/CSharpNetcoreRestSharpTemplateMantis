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
    public class CreatUsersRequest : RequestBase
    {
        public CreatUsersRequest()
        {
            requestService = "/api/rest/users/";
            method = Method.POST;
        }
        public void SetJsonBody(string userName,
                                string password,
                                string realName,
                                string email,
                                string accesLevel,
                                string enabled,
                                string protectedd)
        {
            jsonBody = File.ReadAllText(GeneralHelpers.ReturnProjectPath() + "Jsons\\Users\\CreateUserJson.json", Encoding.UTF8);
            jsonBody = jsonBody.Replace("$username", userName);
            jsonBody = jsonBody.Replace("$password", password);
            jsonBody = jsonBody.Replace("$realName", realName);
            jsonBody = jsonBody.Replace("$email", email);
            jsonBody = jsonBody.Replace("$acessLevel", accesLevel);
            jsonBody = jsonBody.Replace("$enabled", enabled);
            jsonBody = jsonBody.Replace("$protected", protectedd);
        }


    }
}
