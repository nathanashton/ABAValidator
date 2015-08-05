namespace ABAValidator.HeaderFields.Rules
{
    using System;
    using Interfaces;

    public class HeaderField9Rule2 : IRule
    {
        public HeaderField9Rule2(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Valid date";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            try
            {
                var date = new DateTime(Convert.ToInt64(result));
                return new Result().ResultPass(this);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
        }
    }
}