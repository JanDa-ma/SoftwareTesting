using CalculatorProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestProjectV1
{
    public class MultipleDivideTests
    {
        [Fact]
        public void Test_DivideByZero()
        {
            // 1) Arrange
            var calculator = new Calculator();

            Assert.Throws<DivideByZeroException>(() =>
            {
                // Act (the actual operation)
                var result = calculator.Divide(8, 0);

                // Then, Assert
                Assert.IsType<bool>(result);
            });
        }

        [Fact]
        public void Test_Validations()
        {
            // 1) Arrange
            var calculator = new Calculator();

            Exception exception = Assert.Throws<InvalidOperationException>(() =>
            {
                // Act (the actual operation)
                var result = calculator.Multiply(decimal.MaxValue, decimal.MaxValue);

                // Then, Assert
                Assert.IsType<decimal>(result);
            });

            Assert.Equal("Not a valid number to use", exception.Message);

            exception = Assert.Throws<DivideByZeroException>(() =>
            {
                // Act (the actual operation)
                var result = calculator.Divide(decimal.MaxValue, 0);

                // Then, Assert
                Assert.IsType<decimal>(result);
                Debug.WriteLine(Assert.IsType<decimal>(result));
            });

            Assert.IsType<DivideByZeroException>(exception);
        }

        [Fact]
        public void Test_DivideTwoElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Divide(10, 5);

            // Then, Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Test_DivideManyElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Divide(100, 2, 4);

            // Then, Assert
            Assert.Equal((decimal)12.5, result);
            Assert.IsType<decimal>(result);
        }

        [Fact]
        public void Test_MultiplyTwoElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Multiply(10, 5);

            // Then, Assert
            Assert.Equal(50, result);
        }

        [Fact]
        public void Test_MultiplyManyElements()
        {
            // 1) Arrange
            var calculator = new Calculator();

            // Act (the actual operation)
            var result = calculator.Multiply(0.5M, 1, 2, 3, 4, -5.5M);

            // Then, Assert
            Assert.Equal(-66, result);
            Assert.IsType<decimal>(result);
        }
    }
}