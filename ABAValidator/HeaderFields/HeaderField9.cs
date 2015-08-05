namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class HeaderField9 : IField
    {
        public HeaderField9(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 75;
            CharacterPositionEnd = 80;
            FieldDescription = "Date to be processed";

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
            Rules.Add(new HeaderField9Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField9Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField9Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}