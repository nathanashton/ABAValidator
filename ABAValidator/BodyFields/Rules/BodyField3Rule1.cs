namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField3Rule1 : IRule
    {
        public BodyField3Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Valid characters - numerics, hyphens and blanks";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            foreach (var t in result)
            {
                if (char.IsNumber(t) || t == '-' || t == ' ')
                {
                    return new Result().ResultPass(this);
                }
                return new Result().ResultFail(this);
            }
            return new Result().ResultFail(this);
        }
    }
}