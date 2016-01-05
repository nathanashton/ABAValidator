﻿namespace ABAValidator.BodyFields.Rules
{
    using System;
    using Interfaces;

    public class BodyField10Rule1 : IRule
    {
        public BodyField10Rule1(Line line, IField field)
        {
            Line = line;
            Specification = "Must be numeric - blank filled";
        }

        public int Length { get; set; }
        public Line Line { get; set; }
        public string Specification { get; set; }
        public IField Field { get; set; }

        public Result Validate()
        {
            var result = Line.GetCharRangeAsString(Field.CharacterPositionStart, Field.CharacterPositionEnd);
            if (Helpers.IsBlankFilled(result.ToCharArray()))
            {
                //TODO Need to check that no account number is allowed
                return new Result().ResultPass(this);
            }

            try
            {
                Convert.ToInt32(result);
                return new Result().ResultPass(this);
            }
            catch (FormatException)
            {
                return new Result().ResultFail(this);
            }
        }
    }
}