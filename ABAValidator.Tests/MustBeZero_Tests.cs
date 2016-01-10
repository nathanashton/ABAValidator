using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class MustBeZero_Tests
    {

        [TestMethod]
        public void Rule_MustBeZero_Valid_True()
        {
            Assert.IsTrue(Test("0"));
        }

        [TestMethod]
        public void Rule_MustBeZero_NotValid_False()
        {
            Assert.IsFalse(Test("2"));
        }

        [TestMethod]
        public void Rule_MustBeZero_ValidEmpty_False()
        {
            Assert.IsFalse(Test(" "));
        }

        [TestMethod]
        public void Rule_MustBeZero_NotValidLetter_False()
        {
            Assert.IsFalse(Test("A"));
        }

        private bool Test(string input)
        {
            IRule rule = new MustBeZero(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}