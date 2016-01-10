using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class MustBeSeven : IRule
    {
        public MustBeSeven(string input)
        {
            Specification = "Must be number 7";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            var result = Input.ToCharArray()[0];
            if (result == '7')
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}