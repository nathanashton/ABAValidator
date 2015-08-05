namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField11Rule1 : IRule
    {
        public BodyField11Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Coded character set valid";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            if (Helpers.IsAscii(result))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}