using Microsoft.EntityFrameworkCore;
using System;
using WebCalculatorIT;
using Xunit;

namespace WebCalculatorTests
{
    public class ConnectionTest
    {
        [Fact]
        public void TestConnection()
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
                actual = service.CreatePayment("Table1");
            }
            Assert.True(expected == actual);
        }
    }
}