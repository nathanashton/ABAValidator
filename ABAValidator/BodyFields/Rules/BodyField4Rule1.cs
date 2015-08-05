namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField4Rule1 : IRule
    {
        public BodyField4Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be blank or 'N', 'W', 'X', or 'Y'";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharAsString(CharacterPositionStart);
            if (result == " " || result == "N" || result == "W" || result == "X" || result == "Y")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}