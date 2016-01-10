using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class NotAllBlanks : IRule
    {
        public NotAllBlanks(string input)
        {
            Specification = "Not all blanks";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {

            //TODO
            return new Result().ResultFail(this);

        }
    }
}