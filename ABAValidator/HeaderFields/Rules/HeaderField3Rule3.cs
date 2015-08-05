namespace ABAValidator.HeaderFields.Rules
{
    using System;
    using Interfaces;

    public class HeaderField3Rule3 : IRule
    {
        public HeaderField3Rule3(Line line, int start, int end)
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
            var i = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            var asNumber = Convert.ToInt32(i);
            if (asNumber <= 9)
            {
                if (Line.GetCharAsString(CharacterPositionStart) == "0")
                {
                    return new Result().ResultPass(this);
                }
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}