using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BsbNumberTests
    {

        [TestClass]
        public class ValidateMethod
        {

            [TestMethod]
            public void ValidEntry()
            {
                Assert.IsTrue(RunTest("123-456"));
            }

            [TestMethod]
            public void MissingHyphen()
            {
                Assert.IsFalse(RunTest("123456"));
            }

            [TestMethod]
            public void BlankInput()
            {
                Assert.IsFalse(RunTest(" "));
            }

            [TestMethod]
            public void ContainsLetters()
            {
                Assert.IsFalse(RunTest("123-ABC"));
            }

            private bool RunTest(string input)
            {
                IRule rule = new BSBNumber(input);
                var result = rule.Validate();
                return result.Pass;
            }

        }

    }
}
