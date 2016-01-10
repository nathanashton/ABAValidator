using System.Linq;
using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class ZeroFilled : IRule
    {
        public ZeroFilled(string input)
        {
            Specification = "Zero Filled";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (Input.Any(t => t == ' '))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}