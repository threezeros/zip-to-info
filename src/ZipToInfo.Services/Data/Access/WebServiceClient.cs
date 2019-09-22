using System;
using RestSharp;

namespace ZipToInfo.Data.Access
{
    public class WebServiceClient
    {
        protected void AssertHttpResponse(IRestResponse response)
        {
            if (response.IsSuccessful) return; // no HTTP errors reported, so skip the remainder of the checks

            // TODO: throw the appropriate exception type... right now, I'm keeping to the basic system.exception class for simplicity

            // check status codes
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception($"HTTP Error getting information: {response.StatusCode}", response.ErrorException);
            }

            if (response.ErrorException != null)
            {
                throw new Exception($"RestSharp error getting information", response.ErrorException);
            }

            if (response.ErrorMessage != null)
            {
                throw new Exception($"RestSharp error getting information {response.ErrorMessage}", response.ErrorException);
            }

            throw new Exception($"Something happened. Check deserialized properties for more information: {response.ToString()}");
        }
    }
}