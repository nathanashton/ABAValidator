namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField11Rule2 : IRule
    {
        public BodyField11Rule2(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Not all blank";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).ToCharArray();
            if (Helpers.IsBlankFilled(result))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}