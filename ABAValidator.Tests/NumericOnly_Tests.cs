using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class NumericOnly_Tests
    {

        [TestMethod]
        public void Rule_NumericOnly_ValidOnlyNumbers_True()
        {
            Assert.IsTrue(Test("123456"));
        }

        [TestMethod]
        public void Rule_NumericOnly_NotValidNumbersAndSpaces_False()
        {
            Assert.IsFalse(Test("123  4 56"));
        }

        [TestMethod]
        public void Rule_NumericOnly_NotValidLetters_False()
        {
            Assert.IsFalse(Test("ABCD"));
        }

        [TestMethod]
        public void Rule_NumericOnly_NotValidLettersAndNumbers_False()
        {
            Assert.IsFalse(Test("ABCD1234"));
        }

        [TestMethod]
        public void Rule_NumericOnly_NotValidSpacesOnly_False()
        {
            Assert.IsFalse(Test("    "));
        }


        private bool Test(string input)
        {
            IRule rule = new NumericOnly(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}