using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class LettersOnly_Tests
    {

        [TestMethod]
        public void Rule_LettersOnly_Valid_True()
        {
            Assert.IsTrue(Test("ABCDE"));
        }

        [TestMethod]
        public void Rule_LettersOnly_InvalidNumbersOnly_False()
        {
            Assert.IsFalse(Test("01234"));
        }

        [TestMethod]
        public void Rule_LettersOnly_InvalidMixedNumbersLetters_False()
        {
            Assert.IsFalse(Test("01234ABCD"));
        }

        private bool Test(string input)
        {
            IRule rule = new LettersOnly(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}