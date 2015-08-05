namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class BodyField8 : IField
    {
        public BodyField8(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 63;
            CharacterPositionEnd = 80;
            FieldDescription = "Lodgement Reference";

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
            Rules.Add(new BodyField8Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new BodyField8Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new BodyField8Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}