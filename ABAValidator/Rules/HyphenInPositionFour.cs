using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class HyphenInPositionFour : IRule
    {
        public HyphenInPositionFour(string input)
        {
            Specification = "Hyphen in position 4";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            var result = Input.ToCharArray()[3];
            if (result == '-')
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}