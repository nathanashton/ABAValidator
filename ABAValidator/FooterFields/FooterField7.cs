namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using FooterFields.Rules;
    using Interfaces;

    public class FooterField7 : IField
    {
        public FooterField7(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 51;
            CharacterPositionEnd = 74;
            FieldDescription = "Blank";

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
            Rules.Add(new FooterField7Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}