using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BSBNumber_Tests
    {

        [TestMethod]
        public void Rule_BSBNumber_Valid_True()
        {
            Assert.IsTrue(Test("013-234"));
        }

        [TestMethod]
        public void Rule_BSBNumber_NoHyphen_False()
        {
            Assert.IsFalse(Test("0134234"));
        }

        [TestMethod]
        public void Rule_BSBNumber_Empty_False()
        {
            Assert.IsFalse(Test(""));
        }

        [TestMethod]
        public void Rule_BSBNumber_WithLetters_False()
        {
            Assert.IsFalse(Test("A34-90E"));
        }

        private bool Test(string input)
        {
            IRule rule = new BSBNumber(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}