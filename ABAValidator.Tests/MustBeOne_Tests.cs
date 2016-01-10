using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class MustBeOne_Tests
    {

        [TestMethod]
        public void Rule_MustBeOne_Valid_True()
        {
            Assert.IsTrue(Test("1"));
        }

        [TestMethod]
        public void Rule_MustBeOne_NotValid_False()
        {
            Assert.IsFalse(Test("2"));
        }

        [TestMethod]
        public void Rule_MustBeOne_ValidEmpty_False()
        {
            Assert.IsFalse(Test(""));
        }

        [TestMethod]
        public void Rule_MustBeOne_NotValidLetter_False()
        {
            Assert.IsFalse(Test("A"));
        }

        private bool Test(string input)
        {
            IRule rule = new MustBeOne(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}