namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;
    using System.Text.RegularExpressions;

    public class LettersOnly : IRule
    {
        public LettersOnly(Line line, IField field)
        {
            Line = line;
            Specification = "Letters only";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (Regex.IsMatch(result, @"^[a-zA-Z]+$"))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);

        }
    }
}