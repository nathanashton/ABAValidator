namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class BodyField6 : IField
    {
        public BodyField6(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 21;
            CharacterPositionEnd = 30;
            FieldDescription = "Amount";

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
            Rules.Add(new BodyField6Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new BodyField6Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new BodyField6Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}