using CalculatorProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorProgram
{
    public class Calculator
    {
        public Calculator(IDateTimeProvider dateTimeProvider)
        {
            if (dateTimeProvider.GetNow().CompareTo(new DateTime(2100, 1, 1, 0, 0, 0)) >= 0)
            {
                throw new InvalidOperationException("Hey, it's time to make some maintenance!");
            }
        }

        public Calculator()
        {
        }

        public decimal Current { get; private set; }

        public void Reset()
        {
            Current = 0;
        }

        public decimal Sum(params decimal[] numbers)
        {
            if (numbers.Length == 1)
            {
                Current += numbers[0];
                return Current;
            }

            var result = 0.0M;
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }

        public object Multiply(int v1, int v2)
        {
            return v1 * v2;
        }

        public decimal Multiply(params decimal[] numbers)
        {
            ValidateNumbers(numbers);
            if (numbers.Length == 1)
            {
                Current *= numbers[0];
                return Current;
            }

            var result = numbers[0];
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                result *= numbers[i];
            }
            return result;
        }

        public decimal Divide(params decimal[] numbers)
        {
            if (numbers.Length == 1)
            {
                Current /= numbers[0];
                return Current;
            }

            var result = numbers[0];
            for (int i = 1; i <= numbers.Length - 1; i++)
            {
                result /= numbers[i];
            }
            return result;
        }

        private void ValidateNumbers(decimal[] numbers)
        {
            if (numbers.Any(number => number == decimal.MaxValue))
            {
                throw new InvalidOperationException("Not a valid number to use");
            }
        }
    }
}