namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class HeaderField4 : IField
    {
        public HeaderField4(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 21;
            CharacterPositionEnd = 23;
            FieldDescription = "Name of Financial Institution";

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
            Rules.Add(new HeaderField4Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}