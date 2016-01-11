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
            var space = 0;
            var charArray = Input.ToCharArray();
            foreach (var c in charArray)
            {
                if (c == ' ')
                {
                    space++;
                }
            }


            if (space == Input.Length)
            {
                return new Result().ResultFail(this);
            }

            return new Result().ResultPass(this);

        }
    }
}