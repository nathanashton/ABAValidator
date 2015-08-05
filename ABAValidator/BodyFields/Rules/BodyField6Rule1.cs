namespace ABAValidator.BodyFields.Rules
{
    using System;
    using Interfaces;

    public class BodyField6Rule1 : IRule
    {
        public BodyField6Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Only numeric values";
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
                Convert.ToInt32(result);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}