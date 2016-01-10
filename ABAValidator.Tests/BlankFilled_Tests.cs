using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BlankFilled_Tests
    {

        [TestMethod]
        public void Rule_BlankFilled_ValidWithLetters_True()
        {
            Assert.IsTrue(Test("AAA   "));
        }

        [TestMethod]
        public void Rule_BlankFilled_ValidWithNumbers_True()
        {
            Assert.IsTrue(Test("123   "));
        }

        [TestMethod]
        public void Rule_BlankFilled_ValidNoSpaces_True()
        {
            Assert.IsTrue(Test("123"));
        }

        private bool Test(string input)
        {
            IRule rule = new BlankFilled(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}