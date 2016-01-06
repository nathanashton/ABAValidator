namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class Unsigned : IRule
    {
        public Unsigned(Line line, IField field)
        {
            Line = line;
            Specification = "Unsigned";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRange(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (result.Contains('-'))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}