using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class ValidCharacterSet_Tests
    {

        [TestMethod]
        public void Rule_LettersOnly_ValidASCII_True()
        {
            Assert.IsTrue(Test("ABCDE01234-$31"));
        }

        [TestMethod]
        public void Rule_LettersOnly_NotValidNotASCII_False()
        {
            Assert.IsFalse(Test("ఠఠfoobarఠఠ"));
        }
       

        private bool Test(string input)
        {
            IRule rule = new ValidCharacterSet(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}