using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class LeftJustified : IRule
    {
        public LeftJustified(string input)
        {
            Specification = "Left Justified";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Helpers.IsLeftJustified(Input.ToCharArray()))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);

        }
    }
}