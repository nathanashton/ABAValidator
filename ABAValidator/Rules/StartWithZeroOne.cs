using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class StartWithZeroOne : IRule
    {
        public StartWithZeroOne(string input)
        {
            Specification = "Must start with 01";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Input != "01")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);

        }
    }
}