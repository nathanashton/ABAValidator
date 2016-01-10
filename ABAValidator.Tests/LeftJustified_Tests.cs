using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class LeftJustified_Tests
    {

        [TestMethod]
        public void Rule_LeftJustified_Valid_True()
        {
            Assert.IsTrue(Test("1234567"));
        }

        [TestMethod]
        public void Rule_LeftJustified_BlanksAtLeft_False()
        {
            Assert.IsFalse(Test("  9087"));
        }

        private bool Test(string input)
        {
            IRule rule = new LeftJustified(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}