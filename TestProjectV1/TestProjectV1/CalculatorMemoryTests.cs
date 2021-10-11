using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectV1
{
    using System;
    using CalculatorProgram;
    using Xunit;

    namespace UnitTests
    {
        public class CalculatorMemoryTests : IDisposable
        {
            private Calculator Calculator { get; }

            public CalculatorMemoryTests()
            {
                Calculator = new Calculator();
            }

            [Fact]
            public void AddNumberTest()
            {
                Calculator.Reset();

                // Act
                Calculator.Sum(3);
                Calculator.Sum(7);

                Assert.Equal(10, Calculator.Current);
            }

            public void Dispose()
            {
            }
        }
    }
}