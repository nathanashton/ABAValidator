namespace ABAValidator.FooterFields.Rules
{
    using Interfaces;

    public class FooterField6Rule3 : IRule
    {
        public FooterField6Rule3(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Zero filled";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).ToCharArray();
            foreach (var r in result)
            {
                if (r.ToString() == " ")
                {
                    return new Result().ResultFail(this);
                }
            }
            return new Result().ResultPass(this);
        }
    }
}