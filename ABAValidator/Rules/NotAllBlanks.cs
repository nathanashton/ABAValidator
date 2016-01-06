namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class NotAllBlanks : IRule
    {
        public NotAllBlanks(Line line, IField field)
        {
            Line = line;
            Specification = "Not all blanks";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd).ToCharArray();
            if (Helpers.IsBlankFilled(result))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}