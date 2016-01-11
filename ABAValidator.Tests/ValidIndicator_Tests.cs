using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class ValidIndicator_Tests
    {

        [TestMethod]
        public void Rule_ValidIndicator_ValidBlank_True()
        {
            Assert.IsTrue(Test(" "));
        }

        [TestMethod]
        public void Rule_ValidIndicator_ValidN_True()
        {
            Assert.IsTrue(Test("N"));
        }

        [TestMethod]
        public void Rule_ValidIndicator_ValidW_True()
        {
            Assert.IsTrue(Test("W"));
        }

        [TestMethod]
        public void Rule_ValidIndicator_ValidX_True()
        {
            Assert.IsTrue(Test("X"));
        }

        [TestMethod]
        public void Rule_ValidIndicator_ValidY_True()
        {
            Assert.IsTrue(Test("Y"));
        }

        [TestMethod]
        public void Rule_ValidIndicator_NotValidE_False()
        {
            Assert.IsFalse(Test("E"));
        }

        private bool Test(string input)
        {
            IRule rule = new ValidIndicator(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}