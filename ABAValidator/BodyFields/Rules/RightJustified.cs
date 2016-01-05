namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class RightJustified : IRule
    {
        public RightJustified(Line line, IField field)
        {
            Line = line;
            Specification = "Right Justified";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (Helpers.IsRightJustified(result.ToCharArray()))
            {
                //TODO Need to check that no account number is allowed
                return new Result().ResultPass(this);
            }

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