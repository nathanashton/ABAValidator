namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class FooterField1 : IField
    {
        public FooterField1(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 1;
            CharacterPositionEnd = 1;
            FieldDescription = "Record Type 7";

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
            Rules.Add(new FooterField1Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}