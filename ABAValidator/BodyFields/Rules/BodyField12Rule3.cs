namespace ABAValidator.BodyFields.Rules
{
    using System.Linq;
    using Interfaces;

    public class BodyField12Rule3 : IRule
    {
        public BodyField12Rule3(Line line, int start, int end)
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
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            if (result.Any(t => t == ' '))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}