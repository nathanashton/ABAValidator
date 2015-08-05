namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class HeaderField3 : IField
    {
        public HeaderField3(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 19;
            CharacterPositionEnd = 20;
            FieldDescription = "Reel sequence number";

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
            Rules.Add(new HeaderField3Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField3Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField3Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}