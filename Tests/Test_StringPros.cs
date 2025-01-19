using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace _Final_TESTS.Tasks
{
    [TestClass]
    public sealed class Test_StringPros
    {
        private StringPros _stringPros = null!; 

        [TestInitialize]
        public void Setup()
        {
            _stringPros = new StringPros();   
        }

        [TestMethod]
        public void AreEqual_ReturnFalseForNonMatching() // Test method for comparing two strings
        {
            bool result = _stringPros.AreEqual("hello", "world");
            Assert.IsFalse(result, "AreEqual method did not return false for non-matching strings."); 
        }

        [TestMethod]
        public void AreEqual_ReturnTrueForMatching() // Test method for comparing two strings
        {
            bool result = _stringPros.AreEqual("hello", "Hello");
            Assert.IsTrue(result, "AreEqual method did not return true for matching strings.");
        }

        [TestMethod]
        public void ToLowerCase_ConvertToLower() // Test method for converting to lower case
        {
            string result = _stringPros.ToLowerCase("HELLO");  
            Assert.AreEqual("hello", result, "ToLowerCase method did not convert to lower case.");
        }
       
        [TestMethod]
        public void ToLowerCase_ReturnEmptyForEmptyInput() // Test method for converting to lower case
        {
            string result = _stringPros.ToLowerCase("");  
            Assert.AreEqual("", result, "ToLowerCase method did not return empty string for empty input.");
        }

        [TestMethod]
        public void Sanitize_RemoveSpecialChars() // Test method for removing special characters
        {
            string result = _stringPros.Sanitize("He!llo@");
            Assert.AreEqual("Hello", result, "Sanitize method did not remove special characters.");
        }

        [TestMethod]
        public void Sanitize_ReturnEmptyForEmptyInput() // Test method for removing special characters
        {
            string result = _stringPros.Sanitize(""); 
            Assert.AreEqual("", result, "Sanitize method did not return empty string for empty input.");
        }
    }
}
