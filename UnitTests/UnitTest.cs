using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    public class UnitTest
    {
        //General unit tests
        [TestMethod]
        public void TestTrue()
        {
            Assert.IsTrue(true);
        }
        //Integration tests
        public void IntegrationTest_Test()
        {
            Assert.IsTrue(true);
        }
    }

    [TestClass]
    public class IntegrationTest
    {
        private HttpClient _httpClient;
        public IntegrationTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task TestRoute_ReturnsOk()
        {
            var response = await _httpClient.GetAsync("/test");
            var stringResult = await response.Content.ReadAsStringAsync();

            Assert.AreEqual("OK", stringResult);
        }
    }
}