using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class NotAllZeroes_Tests
    {

        [TestMethod]
        public void Rule_NotAllZeroes_Valid_True()
        {
            Assert.IsTrue(Test("00123ABC"));
        }

        [TestMethod]
        public void Rule_NotAllZeroes_ValidAllZeroes_False()
        {
            Assert.IsFalse(Test("0000"));
        }

        [TestMethod]
        public void Rule_NotAllZeroes_AllBlanks_True()
        {
            Assert.IsTrue(Test("    "));
        }

        private bool Test(string input)
        {
            IRule rule = new NotAllZeroes(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}