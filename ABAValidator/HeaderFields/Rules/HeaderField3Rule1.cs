namespace ABAValidator.HeaderFields.Rules
{
    using System;
    using Interfaces;

    public class HeaderField3Rule1 : IRule
    {
        public HeaderField3Rule1(Line line, int start, int end)
        {
            Line = line;
            CharacterPositionStart = start;
            CharacterPositionEnd = end;
            Specification = "Must be numeric starting at '01'";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }

        public Result Validate()
        {
            var first = Line.GetCharAsString(CharacterPositionStart);
            var second = Line.GetCharAsString(CharacterPositionEnd);
            try
            {
                Convert.ToInt32(first);
                Convert.ToInt32(second);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }

            if (second == "0")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}