namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField2Rule2 : IRule
    {
        public BodyField2Rule2(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must have hyphen at position 4";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharAsString(5);
            if (result == "-")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}