﻿namespace ABAValidator.HeaderFields
{
    using System.Collections.Generic;
    using Interfaces;


    public class HeaderField10 : IField
    {
        public HeaderField10(Line line)
        {
            Line = line;
            Rules = new List<IRule>();
            RuleResults = new List<Result>();
            Length = (CharacterPositionEnd - CharacterPositionStart) + 1;
            CharacterPositionStart = 81;
            CharacterPositionEnd = 120;
            FieldDescription = "Blank";
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

            //TODO
        }
    }
}