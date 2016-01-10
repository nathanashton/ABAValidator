using System;
using ABAValidator.Interfaces;

namespace ABAValidator.Rules
{
    public class BSBNumber : IRule
    {
        public BSBNumber(string input)
        {
            Specification = "Must be numeric with a hyphen in position 5";
            Input = input;
        }

        public string Input { get; set; }
        public string Specification { get; set; }

        public Result Validate()
        {
            if (String.IsNullOrEmpty(Input))
            {
                return new Result().ResultFail(this);

            }
            if (Input[3] != '-')
            {
                return new Result().ResultFail(this);
            }

            bool firstAreNumeric = false;
            bool secondAreNumeric = false;


            try
            {
                Convert.ToInt32(Input.Substring(0,3));
                firstAreNumeric = true;
            }
            catch (FormatException)
            {
                firstAreNumeric = false;
            }

            try
            {
                Convert.ToInt32(Input.Substring(4,3));
                secondAreNumeric = true;
            }
            catch (FormatException)
            {
                secondAreNumeric = false;
            }


            if (firstAreNumeric && secondAreNumeric)
            {
                return new Result().ResultPass(this);
            }
            return new Result().ResultFail(this);

        }
    }
}