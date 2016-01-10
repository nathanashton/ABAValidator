using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class BSBFormatFiller : IRule
    {
        public BSBFormatFiller(string input)
        {
            Specification = "Must be 999-999";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Input != "999-999")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}