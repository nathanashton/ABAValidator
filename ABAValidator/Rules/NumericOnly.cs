using System;
using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class NumericOnly : IRule
    {
        public NumericOnly(string input)
        {
            Specification = "Numeric only";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            try
            {
                Convert.ToInt32(Input);
                return new Result().ResultPass(this);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
        }
    }
}