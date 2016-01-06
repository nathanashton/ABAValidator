namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;
    using System.Linq;

    public class ZeroFilled : IRule
    {
        public ZeroFilled(Line line, IField field)
        {
            Line = line;
            Specification = "Zero Filled";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (result.Any(t => t == ' '))
            {
                return new Result().ResultFail(this);
            }
            return new Result().ResultPass(this);
        }
    }
}