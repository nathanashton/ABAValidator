using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class ValidCharacterSet : IRule
    {
        public ValidCharacterSet(string input)
        {
            Specification = "Valid coded character set (ASCII)";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            var result2 = Helpers.IsAscii(Input);
            if (result2)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}