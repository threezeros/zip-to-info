using Xunit;
using Moq;
using RestSharp;
using ZipToInfo.Data.Access;

namespace ZipToInfo.Services.Tests.Data.Access 
{
    public class WebServiceClient_Tests
    {
        [Fact]
        public void WebServiceClient_AssertErrors_Passes()
        {
            var mockResponse = new Mock<IRestResponse>();
            mockResponse.Setup(resp => resp.IsSuccessful).Returns(true);

            var testClient = new WebServiceClient_Extended();
            testClient.AssertPublic(mockResponse.Object);

            //Assert.DoesNotThrow();
                
        }


        private class WebServiceClient_Extended : WebServiceClient
        {
            // test class to verify the abstract base class implementation
            public void AssertPublic(IRestResponse response)
            {
                AssertHttpResponse(response);
            }
        }
        
    }
}