using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class Unsigned : IRule
    {
        public Unsigned(string input)
        {
            Specification = "Unsigned";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Input.Contains("-"))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}