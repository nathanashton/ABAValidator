namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField3Rule3 : IRule
    {
        public BodyField3Rule3(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Right justified";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).ToCharArray();
            if (Helpers.IsRightJustified(result))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}