using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BSBFormatFiller_Tests
    {

        [TestMethod]
        public void Rule_BSBFormatFiller_ValidWithLetters_True()
        {
            Assert.IsTrue(Test("999-999"));
        }

        [TestMethod]
        public void Rule_BSBFormatFiller_NotValidEmpty_False()
        {
            Assert.IsFalse(Test(""));
        }

        [TestMethod]
        public void Rule_BSBFormatFiller_NotValidRandomText_False()
        {
            Assert.IsFalse(Test("AA123"));
        }

        private bool Test(string input)
        {
            IRule rule = new BSBFormatFiller(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}