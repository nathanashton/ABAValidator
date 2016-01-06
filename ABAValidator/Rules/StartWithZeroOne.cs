namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class StartWithZeroOne : IRule
    {
        public StartWithZeroOne(Line line, IField field)
        {
            Line = line;
            Specification = "Must start with 01";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, 1);
            if (result != "01")
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);

        }
    }
}