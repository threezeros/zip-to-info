using Moq;
using RestSharp;

namespace ZipToInfo.Services.Tests.Data.Access 
{
    public static class AccessTestsHelper
    {
        public static IRestResponse GetFakeRestResponse()
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.Setup(mr => mr.IsSuccessful).Returns(true);
            mockResponse.Setup(mr => mr.ErrorException).Returns(null as System.Exception);
            mockResponse.Setup(mr => mr.ErrorMessage).Returns(null as string);

            return mockResponse.Object;
        }
    }
}