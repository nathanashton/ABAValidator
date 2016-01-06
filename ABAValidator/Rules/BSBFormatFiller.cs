namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class BSBFormatFiller : IRule
    {
        public BSBFormatFiller(Line line, IField field)
        {
            Line = line;
            Specification = "Must be 999-999";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (result != "999-999")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}