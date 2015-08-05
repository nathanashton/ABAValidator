namespace ABAValidator.HeaderFields.Rules
{
    using Interfaces;

    public class HeaderField3Rule2 : IRule
    {
        public HeaderField3Rule2(Line line, int start, int end)
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