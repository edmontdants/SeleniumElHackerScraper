using RestSharp;
using System;

namespace WordpressAPI
{
    public static class WordpressAPI
    {
        public static string Auth(string username, string pass)
        {
            //            fetch('http://wordpress.dev/wp-json/jwt-auth/v1/token',{
            //            method: "POST",
            //    headers:
            //                {
            //                    'Content-Type': 'application/json',
            //        'accept': 'application/json',
            //    },
            //    body: JSON.stringify({
            //                username: 'admin',
            //        password: '123456'
            //     })
            //}).then(function(response){
            //                return response.json();
            //            }).then(function(user){
            //                console.log(user.token);
            //            });

            var client = new RestClient("http://mocar.com.ar");
            var request = new RestRequest("/wp-json/jwt-auth/v1/token", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("accept", "application/json");
            request.AddJsonBody(new { username = username, password = pass });
            var response = client.Execute(request);
            return null;

            //return result.Content;
        }
        public static void SendPost()
        {
            string username = "";
            string pass = "";

            Auth(username, pass);
            try
            {
                /*
                 * The token that was returned by authentication request
                 * user.token
                 */
                //Note: Ideally the RestClient isn't created for each request. 


                //

                //                fetch('http://wordpress.dev/wp-json/jwt-auth/v1/token',{
                //                method: "POST",
                //    headers:
                //                    {
                //                        'Content-Type': 'application/json',
                //        'accept': 'application/json',
                //    },
                //    body: JSON.stringify({
                //                    username: 'admin',
                //        password: '123456'
                //     })
                //}).then(function(response){
                //                    return response.json();
                //                }).then(function(user){
                //                    console.log(user.token);
                //                });
                //restClient.AddDefaultHeader("Authorization", string.Format("Bearer {0}", bearerToken));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
