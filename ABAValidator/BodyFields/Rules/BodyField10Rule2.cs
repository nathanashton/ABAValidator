﻿namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;

    public class BodyField10Rule2 : IRule
    {
        public BodyField10Rule2(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Right justified";
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
                //TODO Need to check that no account number is allowed
                return new Result().ResultPass(this);
            }

            var result2 = Helpers.IsRightJustified(result);
            if (result2)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}