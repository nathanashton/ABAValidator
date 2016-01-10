using System.Text.RegularExpressions;
using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class LettersOnly : IRule
    {
        public LettersOnly(string input)
        {
            Specification = "Letters only";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Regex.IsMatch(Input, @"^[a-zA-Z]+$"))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);

        }
    }
}