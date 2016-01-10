namespace ABAValidator
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Interfaces;

    public static class Helpers
    {
        public enum LineType
        {
            Nil,
            Header,
            Body,
            Footer
        }

        public static List<IField> AllFields = new List<IField>();

        public static bool IsAscii(string value)
        {
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        public static bool IsLeftJustified(char[] input)
        {
            return input[0] != ' ';
        }

        public static bool IsRightJustified(char[] input)
        {
            return input[input.Count() - 1] != ' ';
        }

        public static bool IsBlankFilled(char[] input, int expectedLength)
        {
            var c = input.Length;

            return expectedLength == (input.Length + 1);
        }

        public static bool IsZeroFilled(char[] input)
        {
            var valid = 0;
            var invalid = 0;
            foreach (var c in input)
            {
                if (c == '0')
                {
                    valid++;
                }
                else
                {
                    invalid++;
                }
            }
            return invalid <= 0;
        }
    }
}