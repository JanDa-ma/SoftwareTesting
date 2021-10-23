using CalculatorProgram;
using CalculatorProject;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectV1
{
    public class UnitTestMock
    {
        [Fact]
        public void Test_MaintenanceDateHit()
        {
            // 1) Arrange
            var mockDateTime = new Moq.Mock<IDateTimeProvider>();
            mockDateTime.Setup(mock => mock.GetNow()).Returns(() => new DateTime(2100, 1, 1, 0, 0, 0));

            var exception = Assert.Throws<InvalidOperationException>(() =>
            {
                var calculator = new Calculator(mockDateTime.Object);
            });

            // Then, Assert
            Assert.Contains("time to make some maintenance!", exception.Message);

            mockDateTime.Verify(mock => mock.GetNow(), Times.Once);
        }
    }
}