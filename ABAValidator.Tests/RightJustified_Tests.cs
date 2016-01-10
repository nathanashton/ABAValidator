using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class RightJustified_Tests
    {

        [TestMethod]
        public void Rule_RightJustified_Valid_True()
        {
            Assert.IsTrue(Test("   1234567"));
        }

        [TestMethod]
        [Description("This is what a descript looks like")]
        public void Rule_RightJustified_BlanksAtRight_False()
        {
            Assert.IsFalse(Test("9087    "));
        }

        private bool Test(string input)
        {
            IRule rule = new RightJustified(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}