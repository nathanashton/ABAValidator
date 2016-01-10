using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class MustBeZero : IRule
    {
        public MustBeZero(string input)
        {
            Specification = "Must be number 0";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            var result = Input.ToCharArray()[0];
            if (result == '0')
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}