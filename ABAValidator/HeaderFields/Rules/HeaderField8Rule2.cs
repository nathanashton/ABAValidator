﻿namespace ABAValidator.HeaderFields.Rules
{
    using Interfaces;

    public class HeaderField8Rule2 : IRule
    {
        public HeaderField8Rule2(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Not all blanks";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd).ToCharArray();
            var result2 = Helpers.IsBlankFilled(result);
            if (result2)
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}