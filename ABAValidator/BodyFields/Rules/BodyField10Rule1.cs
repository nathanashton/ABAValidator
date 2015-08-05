namespace ABAValidator.BodyFields.Rules
{
    using System;
    using Interfaces;

    public class BodyField10Rule1 : IRule
    {
        public BodyField10Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be numeric";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            if (Helpers.IsBlankFilled(result.ToCharArray()))
            {
                //TODO Need to check that no account number is allowed
                return new Result().ResultPass(this);
            }

            try
            {
                Convert.ToInt32(result);
                return new Result().ResultPass(this);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
        }
    }
}