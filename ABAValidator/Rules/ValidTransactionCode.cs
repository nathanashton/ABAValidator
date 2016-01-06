namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class ValidTransactionCode : IRule
    {
        public ValidTransactionCode(Line line, IField field)
        {
            Line = line;
            Specification = "Must be a valid transaction code '13', '50', '51', '52', '53', '54', '55', '56', or '57'";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (result == "13" || result == "50" || result == "51" || result == "52" || result == "53" || result == "54" ||
                result == "55" || result == "56" || result == "57")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}