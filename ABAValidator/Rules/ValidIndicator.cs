namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;
    using System.Linq;

    public class ValidIndicator : IRule
    {
        public ValidIndicator(Line line, IField field)
        {
            Line = line;
            Specification = "Must be N, W, X or Y";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (result != "N" || result != "W" || result != "X" || result != "Y")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}