using ABAValidator.Rules;

namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;

    public class BodyField8 : IField
    {
        public BodyField8(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            CharacterPositionStart = 63;
            CharacterPositionEnd = 80;
            FieldDescription = "Lodgement Reference";
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

            Rules.Add(new ValidCharacterSet(input));
            Rules.Add(new NotAllBlanks(input));
            Rules.Add(new LeftJustified(input));
            Rules.Add(new BlankFilled(input));
        }
    }
}