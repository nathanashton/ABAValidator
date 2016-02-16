using ABAValidator.Interfaces;
using ABAValidator.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BlankFilledTests
    {

        [TestClass]
        public class ValidateMethod
        {

            [TestMethod]
            public void WithTrailingSpaces()
            {
                Assert.IsTrue(RunTest("AAA   "));
            }

            [TestMethod]
            public void WithLeadingSpaces()
            {
                Assert.IsTrue(RunTest("   AAA"));
            }

            private bool RunTest(string input)
            {
                IRule rule = new BlankFilled(input);
                var result = rule.Validate();
                return result.Pass;
            }

        }

    }
}
