using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class Unsigned_Tests
    {

        [TestMethod]
        public void Rule_Unsigned_Valid_True()
        {
            Assert.IsTrue(Test("1234567"));
        }

        [TestMethod]
        public void Rule_Unsigned_NotValidHasSign_False()
        {
            Assert.IsFalse(Test("-"));
        }

        private bool Test(string input)
        {
            IRule rule = new Unsigned(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}