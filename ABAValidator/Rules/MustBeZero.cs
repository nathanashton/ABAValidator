namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class MustBeZero : IRule
    {
        public MustBeZero(Line line, IField field)
        {
            Line = line;
            Specification = "Must be number 0";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharAsString(1);
            if (result == "0")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}