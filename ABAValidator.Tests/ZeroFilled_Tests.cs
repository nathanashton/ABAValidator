using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class ZeroFilled_Tests
    {

        [TestMethod]
        public void Rule_ZeroFilled_Valid_True()
        {
            Assert.IsTrue(Test("01AA"));
        }

        [TestMethod]
        public void Rule_StartWithZeroOne_NotValidSpace_False()
        {
            Assert.IsFalse(Test("01ABC "));
        }

        private bool Test(string input)
        {
            IRule rule = new ZeroFilled(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}