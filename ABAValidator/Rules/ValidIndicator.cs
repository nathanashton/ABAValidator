using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class ValidIndicator : IRule
    {
        public ValidIndicator(string input)
        {
            Specification = "Must be N, W, X or Y or blank";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Input == null)
            {
                return new Result().ResultFail(this);
            }
            if (Input == "N" || Input == "W" || Input == "X" || Input == "Y" || Input == " ")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}