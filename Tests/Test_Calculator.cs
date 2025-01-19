using Final_TESTS.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Final_TESTS.Tests
{

    [TestClass]
    public sealed class TestCalculator
    {
        private Calculator _calculator = null!; // Calculator instance to be used in tests, using null-forgiving operator (!) to avoid compiler warnings
       
        [TestInitialize]
        public void Setup()
        {
            _calculator = new Calculator(); // Initialize Calculator instance before each test, so that each test starts with a clean slate
                                            // This also means we don't have to create a new Calculator instance in each test method - DRY principle
        }

        [TestMethod]
        public void  Add_CorrectSum() // Test method for Adding nums. 
        {
            // Act
            float result = _calculator.Add(2, 3);

            // Assert
            Assert.AreEqual(5, result, "Add method did not return the expected sum."); // can changed the expected value to 6 to make it fail
        }

        [TestMethod]
        public void Add_DecimalsCorrectly() // Test method for Adding decimals. 
        {
            float result = _calculator.Add(0.4f, 0.2f);

            Assert.AreEqual(0.6f, result, 0.001f, "Add method did not return the expected rounded sum.");
        }

        [TestMethod]
        public void Add_NegativeNumbers() // Test method for Adding negative numbers
        {
            float result = _calculator.Add(-10, 3);

            Assert.AreEqual(-7, result, "Add method did not handle negative numbers correctly.");
        }

        [TestMethod]
        public void Subtract_CorrectDifference() // Test method for Subtracting nums.
        {
            float result = _calculator.Subtract(10, 3);

            Assert.AreEqual(7, result, "Subtract method did not return the expected difference.");
        }

        [TestMethod]
        public void Subtract_NegativeNumbers() // Test method for Subtracting negative numbers
        {
            float result = _calculator.Subtract(-5, 5);

            Assert.AreEqual(-10, result, "Subtract method did not handle negative numbers correctly.");
        }

        [TestMethod]
        public void Multiply_CorrectProduct() // Test method for Multiplying nums.
        {
            float result = _calculator.Multiply(5, 5);

            Assert.AreEqual(25, result, "Multiply method did not return the expected product.");
        }

        [TestMethod]
        public void Multiply_NegativeNumbers() // Test method for Multiplying negative numbers
        {
            float result = _calculator.Multiply(-5, 5);

            Assert.AreEqual(-25, result, "Multiply method did not handle negative numbers correctly.");
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))] // This is so you can't divide by zero
        public void Divide_ByZero()
        {
            _calculator.Divide(2, 0);
        }

        [TestMethod]
        public void Divide_CorrectQuotient() // Test method for Dividing nums.
        {
            float result = _calculator.Divide(10, 2);

            Assert.AreEqual(5, result, "Divide method did not return the expected quotient.");
        }

        [TestMethod]
        public void Divide_NegativeNumbers() // Test method for Dividing negative numbers
        {
            float result = _calculator.Divide(-10, 2);

            Assert.AreEqual(-5, result, "Divide method did not handle negative numbers correctly.");
        }


        //Edge cases. I added a few more to test the calculator more thoroughly. i made only one test for each operation to keep it simple
        [DataTestMethod]
        [DataRow(5, 2, 7)]
        [DataRow(-5, 6, 1)]
        [DataRow(0.1f, 0.2f, 0.3f)]
        [DataRow(float.MaxValue, -float.MaxValue, 0)] // Extreme case: Max and Min
        [DataRow(-5.1f, -2.2f, -7.3f)] // Negative decimals
        public void Add_ShouldReturnCorrectSum(float a, float b, float expected)
        {
            float result = _calculator.Add(a, b);
            Assert.AreEqual(expected, result, 0.0001f, $"Add returned incorrect result for inputs {a} and {b}.");
        }



        // Bonus tests: test the CheckValidity method instead of having multiple tests for each operation.
        // Test method for OverflowException. The last part is from Niklas's code. this was the only one i could get to work.

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Divide_ShouldThrowExceptionWhenResultIsNaN()
        {
            // Act
            _calculator.Divide(0, 0);

            // Assert is handled by ExpectedException
        }
    }
}

