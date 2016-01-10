using ABAValidator.Rules;

namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;

    public class BodyField3 : IField
    {
        public BodyField3(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            CharacterPositionStart = 9;
            CharacterPositionEnd = 17;
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            FieldDescription = "Account number to be credited / debited";
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

            Rules.Add(new NotAllBlanks(input));
            Rules.Add(new NotAllZeroes(input));
            Rules.Add(new RightJustified(input));
            Rules.Add(new BlankFilled(input));
        }
    }
}