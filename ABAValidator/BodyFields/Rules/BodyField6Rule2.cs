namespace ABAValidator.BodyFields.Rules
{
    using System;
    using Interfaces;

    public class BodyField6Rule2 : IRule
    {
        public BodyField6Rule2(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Greater than zero, unsigned";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            try
            {
                var r = Convert.ToInt32(result);
                if (r > 0)
                {
                    return new Result().ResultPass(this);
                }
                return new Result().ResultFail(this);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
        }
    }
}