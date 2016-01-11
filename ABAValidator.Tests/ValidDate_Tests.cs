using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class ValidDate_Tests
    {

        [TestMethod]
        public void Rule_ValidDate_Valid_True()
        {
            Assert.IsTrue(Test("011215"));
        }

        [TestMethod]
        public void Rule_ValidDate_NotValidEmpty_False()
        {
            Assert.IsFalse(Test("  "));
        }

        [TestMethod]
        public void Rule_ValidDate_NotValidDay_False()
        {
            Assert.IsFalse(Test("321215"));
        }

        [TestMethod]
        public void Rule_ValidDate_NotValidLetters_False()
        {
            Assert.IsFalse(Test("01AA1215"));
        }

        private bool Test(string input)
        {
            IRule rule = new ValidDate(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}