using Moq;
using RestSharp;

namespace ZipToInfo.Services.Tests.Shared
{
    public static class TestUtils
    {
        public static IRestResponse<T> GetMockRestResponse<T>(T fakeData) where T: class
        {
            var mockResponse = new Mock<IRestResponse<T>>();
            mockResponse.Setup(mr => mr.IsSuccessful).Returns(true);
            mockResponse.Setup(mr => mr.ErrorException).Returns(null as System.Exception);
            mockResponse.Setup(mr => mr.ErrorMessage).Returns(null as string);
            mockResponse.Setup(mr => mr.Data).Returns(fakeData);

            return mockResponse.Object;
        }
    }
}