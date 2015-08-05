namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class HeaderField6 : IField
    {
        public HeaderField6(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 31;
            CharacterPositionEnd = 56;
            FieldDescription = "Name of user supplying file";

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
            Rules.Add(new HeaderField6Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField6Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField6Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}