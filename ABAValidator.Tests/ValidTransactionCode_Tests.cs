using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class ValidTransactionCode_Tests
    {

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid13_True()
        {
            Assert.IsTrue(Test("13"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid50_True()
        {
            Assert.IsTrue(Test("50"));
        }


        [TestMethod]
        public void Rule_ValidTransactionCode_Valid51_True()
        {
            Assert.IsTrue(Test("51"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid52_True()
        {
            Assert.IsTrue(Test("52"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid53_True()
        {
            Assert.IsTrue(Test("53"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid54_True()
        {
            Assert.IsTrue(Test("54"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid55_True()
        {
            Assert.IsTrue(Test("55"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid56_True()
        {
            Assert.IsTrue(Test("56"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_Valid57_True()
        {
            Assert.IsTrue(Test("57"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_NotValidEmpty_False()
        {
            Assert.IsFalse(Test(""));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_NotValidSpace_False()
        {
            Assert.IsFalse(Test(" "));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_NotValidOtherNumber_False()
        {
            Assert.IsFalse(Test("19"));
        }

        [TestMethod]
        public void Rule_ValidTransactionCode_NotValidLetter_False()
        {
            Assert.IsFalse(Test("E"));
        }

        private bool Test(string input)
        {
            IRule rule = new ValidTransactionCode(input);
            var result = rule.Validate();
            return result.Pass;
        }
    }
}