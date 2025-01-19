using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Final_TESTS.Tasks
{

    public class Calculator
    {
        public float Add(float a, float b)
        {
            return a + b;
        }
        public float Subtract(float a, float b)
        {
            return a - b;
        }
        public float Multiply(float a, float b)
        {
            return a * b;
        }
        public float Divide(float a, float b)
        {
            if (b == 0)
            {
                if (a == 0)
                {
                    // Handle 0 / 0 as NaN
                    return CheckValidity(float.NaN);
                }

                // Throw DivideByZeroException if only denominator is zero
                throw new DivideByZeroException("can't not divide with zero.");
            }

            // For other cases, check validity of the result
            return CheckValidity(a / b);
        }

        private float CheckValidity(float value)
        {
            if (float.IsInfinity(value))
            {
                throw new OverflowException("The result of the operation is too large or too low for a float value.");
            }

            if (float.IsNaN(value))
            {
                throw new InvalidOperationException("Operation resulted in an invalid number (NaN = Not a Number).");
            }

            return value;
        }
    }
}



