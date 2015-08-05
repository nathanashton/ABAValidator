namespace ABAValidator.HeaderFields.Rules
{
    using System.Linq;
    using Interfaces;

    public class HeaderField4Rule1 : IRule
    {
        public HeaderField4Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be approved abbreviation";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result =
                Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).All(x => char.IsLetter(x));
            if (result)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}