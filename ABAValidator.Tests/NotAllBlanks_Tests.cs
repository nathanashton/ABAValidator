using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class NotAllBlanks_Tests
    {

        [TestMethod]
        public void Rule_NotAllBlanks_ValidWWithSpaces_True()
        {
            Assert.IsTrue(Test("123 A T"));
        }

        [TestMethod]
        public void Rule_NotAllBlanks_ValidNoSpaces_True()
        {
            Assert.IsTrue(Test("123AT"));
        }

        [TestMethod]
        public void Rule_NotAllBlanks_AllBlanks_False()
        {
            Assert.IsFalse(Test("    "));
        }

        private bool Test(string input)
        {
            IRule rule = new NotAllBlanks(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}