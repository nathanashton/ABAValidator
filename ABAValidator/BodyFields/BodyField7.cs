﻿using ABAValidator.Rules;

namespace ABAValidator.BodyFields
{
    using System.Collections.Generic;
    using Interfaces;

    public class BodyField7 : IField
    {
        public BodyField7(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            CharacterPositionStart = 31;
            CharacterPositionEnd = 62;
            FieldDescription = "Title of account to be credited / debited";
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