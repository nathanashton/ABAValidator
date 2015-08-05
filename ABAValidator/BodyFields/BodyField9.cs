namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class BodyField9 : IField
    {
        public BodyField9(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 81;
            CharacterPositionEnd = 87;
            FieldDescription = "Bank / State / Branch BSB Number";

            AddRules();
        }

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
            Rules.Add(new BodyField9Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new BodyField9Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}