using ABAValidator.Rules;

namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;

    public class BodyField12 : IField
    {
        public BodyField12(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            CharacterPositionStart = 113;
            CharacterPositionEnd = 120;
            FieldDescription = "Amount of Withholding Tax";

            AddRules();
        }

        public int Length { get; set; }
        public List<IRule> Rules { get; set; }
        public int CharacterPositionStart { get; set; }
        public int CharacterPositionEnd { get; set; }
        public string FieldDescription { get; set; }
        public Line Line { get; set; }
        public List<Result> RuleResults { get; set; }

        public void RunRules()
        {
            foreach (var rule in Rules)
            {
                RuleResults.Add(rule.Validate());
            }
        }

        private void AddRules()
        {
            var input = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);

            Rules.Add(new NumericOnly(input));
            Rules.Add(new RightJustified(input));
            Rules.Add(new ZeroFilled(input));
            Rules.Add(new Unsigned(input));
        }
    }
}