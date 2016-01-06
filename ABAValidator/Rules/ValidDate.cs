namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class ValidDate : IRule
    {
        public ValidDate(Line line, IField field)
        {
            Line = line;
            Specification = "Valid Date";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            DateTime dateTime;
            if (DateTime.TryParse(result, out dateTime))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}