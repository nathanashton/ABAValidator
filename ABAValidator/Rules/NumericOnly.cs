namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class NumericOnly : IRule
    {
        public NumericOnly(Line line, IField field)
        {
            Line = line;
            Specification = "Numeric only";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
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