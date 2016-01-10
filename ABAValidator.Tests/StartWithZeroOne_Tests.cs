using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class StartWithZeroOne_Tests
    {

        [TestMethod]
        public void Rule_StartWithZeroOne_Valid_True()
        {
            Assert.IsTrue(Test("01"));
        }

        [TestMethod]
        public void Rule_StartWithZeroOne_ValidWithMoreText_True()
        {
            Assert.IsTrue(Test("01ABC"));
        }

        [TestMethod]
        public void Rule_StartWithZeroOne_NotValid_True()
        {
            Assert.IsFalse(Test("09"));
        }

        [TestMethod]
        public void Rule_StartWithZeroOne_NotValidStartsWithSpace_True()
        {
            Assert.IsFalse(Test(" 09"));
        }

        private bool Test(string input)
        {
            IRule rule = new StartWithZeroOne(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}