namespace ABAValidator.FooterFields.Rules
{
    using Interfaces;

    public class FooterField2Rule1 : IRule
    {
        public FooterField2Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be '999-999'";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            if (result == "999-999")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}