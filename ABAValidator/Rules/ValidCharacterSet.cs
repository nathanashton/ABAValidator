namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class ValidCharacterSet : IRule
    {
        public ValidCharacterSet(Line line, IField field)
        {
            Line = line;
            Specification = "Valid coded character set (ASCII)";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart,Field.CharacterPositionEnd);
            var result2 = Helpers.IsAscii(result);
            if (result2)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}