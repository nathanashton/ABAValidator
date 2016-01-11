using System;
using System.Globalization;
using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class ValidDate : IRule
    {
        public ValidDate(string input)
        {
            Specification = "Valid Date";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            DateTime dateTime;
            if (DateTime.TryParseExact(Input, "ddmmyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);
        }
    }
}