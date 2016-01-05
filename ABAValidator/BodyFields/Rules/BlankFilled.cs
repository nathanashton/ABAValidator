﻿namespace ABAValidator.BodyFields.Rules
{
    using Interfaces;
    using System;

    public class BlankFilled : IRule
    {
        public BlankFilled(Line line, IField field)
        {
            Line = line;
            Specification = "Blank Filled";
        }

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