namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using FooterFields.Rules;
    using Interfaces;

    public class FooterField4 : IField
    {
        public FooterField4(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 21;
            CharacterPositionEnd = 30;
            FieldDescription = "File Net Total Amount";

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
            Rules.Add(new FooterField4Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new FooterField4Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new FooterField4Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}