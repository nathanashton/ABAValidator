namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class HyphenInPositionFive : IRule
    {
        public HyphenInPositionFive(Line line, IField field)
        {
            Line = line;
            Specification = "Hyphen in position 5";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharAsString(5);
            if (result == "-")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}