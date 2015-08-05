namespace ABAValidator.FooterFields.Rules
{
    using Interfaces;

    public class FooterField3Rule1 : IRule
    {
        public FooterField3Rule1(Line line, int start, int end)
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
            if (Helpers.IsBlankFilled(result))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}