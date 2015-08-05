namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class HeaderField1 : IField
    {
        public HeaderField1(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 1;
            CharacterPositionEnd = 1;
            FieldDescription = "Record Type 0";

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
            Rules.Add(new HeaderField1Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}