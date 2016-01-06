namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class MustBeOne : IRule
    {
        public MustBeOne(Line line, IField field)
        {
            Line = line;
            Specification = "Must be number 1";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharAsString(1);
            if (result == "1")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}