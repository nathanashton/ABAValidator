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
            var f = Input[0].ToString();
            var s = Input[1].ToString();
            string result = f + s;
            if (result != "01")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);

        }
    }
}