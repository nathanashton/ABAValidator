namespace ABAValidator.BodyFields.Rules
{
    using System;
    using Interfaces;

    public class BodyField9Rule1 : IRule
    {
        public BodyField9Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be numeric";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            var result2 = result.Remove(3);
            try
            {
                Convert.ToInt32(result2);
                return new Result().ResultPass(this);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
        }
    }
}