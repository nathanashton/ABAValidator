namespace ABAValidator.HeaderFields.Rules
{
    using Interfaces;

    public class HeaderField8Rule3 : IRule
    {
        public HeaderField8Rule3(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Left justified";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).ToCharArray();
            var result2 = Helpers.IsLeftJustified(result);
            if (result2)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}