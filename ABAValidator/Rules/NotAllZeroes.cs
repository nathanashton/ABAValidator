namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class NotAllZeroes : IRule
    {
        public NotAllZeroes(Line line, IField field)
        {
            Line = line;
            Specification = "Not all zeroes";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            int zeroCount = 0;
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            foreach (char c in result)
            {
                if (c == '0')
                {
                    zeroCount++;
                }
            }
            if (zeroCount == result.Length)
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}