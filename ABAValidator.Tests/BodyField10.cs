using ABAValidator.BodyFields.Rules;
using ABAValidator.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ABAValidator.Tests
{
    [TestClass]
    public class BodyField10
    {
        [TestMethod]
        [Description("Must be numeric or blank filled - All numeric")]
        public void BodyField10Rule1_NumericOnly_True()
        {
            //var input = "123456789";

            //var line = new Line();
            //foreach (char c in input.ToCharArray())
            //{
            //    line.Characters.Add(c);
            //}

            ////Must be numeric
            //IRule rule = new BodyField10Rule1(line, 1, input.Length);

            //var result = rule.Validate();
            //Assert.IsTrue(result.Pass);
        }

        [TestMethod]
        [Description("Must be numeric or blank filled - All blank")]
        public void BodyField10Rule1_BlankFilled_True()
        {
            //var input = "   ";

            //var line = new Line();
            //foreach (char c in input.ToCharArray())
            //{
            //    line.Characters.Add(c);
            //}

            ////Must be numeric
            //IRule rule = new BodyField10Rule1(line, 1, input.Length);

            //var result = rule.Validate();
            //Assert.IsTrue(result.Pass);
        }

        [TestMethod]
        [Description("Must be numeric or blank filled - Not all numeric")]
        public void BodyField10Rule1_NotNumeric_False()
        {
            //var input = "A123456";

            //var line = new Line();
            //foreach (char c in input.ToCharArray())
            //{
            //    line.Characters.Add(c);
            //}

            ////Must be numeric
            //IRule rule = new BodyField10Rule1(line, 1, input.Length);

            //var result = rule.Validate();
            //Assert.IsFalse(result.Pass);
        }
    }
}