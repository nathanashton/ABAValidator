using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class NotAllZeroes : IRule
    {
        public NotAllZeroes(string input)
        {
            Specification = "Not all zeroes";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            int zeroCount = 0;
            foreach (char c in Input)
            {
                if (c == '0')
                {
                    zeroCount++;
                }
            }
            if (zeroCount == Input.Length)
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}