using ABAValidator.Rules;

namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;

    public class BodyField1 : IField
    {
        public BodyField1(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            CharacterPositionStart = 1;
            CharacterPositionEnd = 1;
            FieldDescription = "Record Type 1";
            AddRules();
        }

        public int Length { get; set; }
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
            var input = Line.GetCharRangeAsString(CharacterPositionStart, CharacterPositionEnd);
            Rules.Add(new MustBeOne(input));
        }
    }
}