using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BsbFormatFillerTests
    {

        [TestClass]
        public class ValidateMethod
        {

            [TestMethod]
            public void ValidEntry()
            {
                Assert.IsTrue(RunTest("999-999"));
            }

            [TestMethod]
            public void EmptySpace()
            {
                Assert.IsFalse(RunTest(" "));
            }

            [TestMethod]
            public void MixOfLettersAndNumbers()
            {
                Assert.IsFalse(RunTest("123-ABC"));
            }

            private bool RunTest(string input)
            {
                IRule rule = new BSBFormatFiller(input);
                var result = rule.Validate();
                return result.Pass;
            }

        }

    }
}
