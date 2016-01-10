using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class BlankFilled : IRule
    {
        public BlankFilled(string input)
        {
            Specification = "Blank Filled";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
       
            //TODO need to complete
         
            return new Result().ResultPass(this);
        }
    }
}