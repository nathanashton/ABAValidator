using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class HyphenInPositionFour_Tests
    {

        [TestMethod]
        public void Rule_HyphenInPositionFour_Valid_True()
        {
            Assert.IsTrue(Test("123-456"));
        }

        [TestMethod]
        public void Rule_HyphenInPositionFour_NotValid_False()
        {
            Assert.IsFalse(Test("12-3456"));
        }

        [TestMethod]
        public void Rule_HyphenInPositionFour_NotValidEmpty_False()
        {
            Assert.IsFalse(Test(" "));
        }

        private bool Test(string input)
        {
            IRule rule = new HyphenInPositionFour(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}