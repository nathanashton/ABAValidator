namespace ABAValidator.HeaderFields.Rules
{
    using Interfaces;

    public class HeaderField9Rule3 : IRule
    {
        public HeaderField9Rule3(Line line, int start, int end)
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
            var first = Line.GetCharAsString(CharacterPositionStart);
            var second = Line.GetCharAsString(CharacterPositionEnd);

            if (first != " " && second != " ")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}