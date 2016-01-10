using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class MustBeOne : IRule
    {
        public MustBeOne(string input)
        {
            Specification = "Must be number 1";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            var result = Input.ToCharArray()[0];
            if (result == '1')
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}