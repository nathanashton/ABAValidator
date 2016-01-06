namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class BodyField2 : IField
    {
        public BodyField2(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            CharacterPositionStart = 2;
            CharacterPositionEnd = 8;
            FieldDescription = "Bank/State/Branch BSB Number";
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
            Rules.Add(new NumericOnly(Line, this));
            Rules.Add(new HyphenInPositionFive(Line, this));
        }
    }
}