namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class MustBeSeven : IRule
    {
        public MustBeSeven(Line line, IField field)
        {
            Line = line;
            Specification = "Must be number 7";
        }

        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharAsString(1);
            if (result == "7")
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}