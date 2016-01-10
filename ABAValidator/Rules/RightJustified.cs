using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class RightJustified : IRule
    {
        public RightJustified(string input)
        {
            Specification = "Right Justified";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Helpers.IsRightJustified(Input.ToCharArray()))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);

        }
    }
}