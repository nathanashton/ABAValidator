namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;
    using Rules;

    public class HeaderField7 : IField
    {
        public HeaderField7(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();

            CharacterPositionStart = 57;
            CharacterPositionEnd = 62;
            FieldDescription = "User identification number allocated by APCA";

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
            Rules.Add(new HeaderField7Rule1(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField7Rule2(Line, CharacterPositionStart, CharacterPositionEnd));
            Rules.Add(new HeaderField7Rule3(Line, CharacterPositionStart, CharacterPositionEnd));
        }
    }
}