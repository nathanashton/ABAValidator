namespace ABAValidator.HeaderFields.Rules
{
    using Interfaces;

    public class HeaderField5Rule1 : IRule
    {
        public HeaderField5Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be blank filled";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).ToCharArray();
            var result2 = Helpers.IsBlankFilled(result);
            if (result2)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}