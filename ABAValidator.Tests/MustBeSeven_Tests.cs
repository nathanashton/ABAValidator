using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class MustBeSeven_Tests
    {

        [TestMethod]
        public void Rule_MustBeSeven_Valid_True()
        {
            Assert.IsTrue(Test("7"));
        }

        [TestMethod]
        public void Rule_MustBeSeven_NotValid_False()
        {
            Assert.IsFalse(Test("2"));
        }

        [TestMethod]
        public void Rule_MustBeSeven_ValidEmpty_False()
        {
            Assert.IsFalse(Test(" "));
        }

        [TestMethod]
        public void Rule_MustBeSeven_NotValidLetter_False()
        {
            Assert.IsFalse(Test("A"));
        }

        private bool Test(string input)
        {
            IRule rule = new MustBeSeven(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}