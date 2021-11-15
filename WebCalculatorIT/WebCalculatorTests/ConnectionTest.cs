using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using WebCalculatorIT;
using Xunit;

namespace WebCalculatorTests
{
    public class ConnectionTest
    {
        [Fact]
        public async Task Test1()
        {
            bool expected = true;
            bool actual;
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
            .Options;

            PaymentService service = null;

            // Run the test against one instance of the context
            using (var context = new ApplicationDbContext(options))
            {
                service = new PaymentService(new PaymentRepository(context));
                actual = service.CreatePayment("Table_1");
            }
            Assert.True(expected == actual);
        }

        [Fact]
        public async void Test_WebCalculatorSum()
        {
            var context = new TestContext();

            using (var client = context.Client)
            {
                var response = await client.GetAsync("/api/calculator/sum?x=2&y=3");

                Assert.True(response.IsSuccessStatusCode);

                var content = await response.Content.ReadAsStringAsync();

                Assert.Equal("3", content);
            }
        }
    }
}