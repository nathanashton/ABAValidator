using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class HyphenPositionFourTests
    {

        [TestClass]
        public class ValidateMethod
        {

            [TestMethod]
            public void HyphenInPositionFour()
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
            public void HyphenInWrongPosition()
            {
                Assert.IsFalse(RunTest("1234-56"));
            }

            private bool RunTest(string input)
            {
                IRule rule = new HyphenInPositionFour(input);
                var result = rule.Validate();
                return result.Pass;
            }

        }

    }
}
