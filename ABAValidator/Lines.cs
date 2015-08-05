namespace ABAValidator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Lines
    {
        public Lines()
        {
            AllLines = new ObservableCollection<Line>();
        }

        public ObservableCollection<Line> AllLines { get; set; }

        public override string ToString()
        {
            return "T";
        }

        public Line GetLine(int number)
        {
            return AllLines[number - 1];
        }

        public Line GetFirstLine()
        {
            return AllLines[0];
        }

        public Line GetLastLine()
        {
            return AllLines[AllLines.Count - 1];
        }

        public List<Line> GetBodyLines()
        {
            if (AllLines.Count < 2)
            {
                throw new Exception("There is no body");
            }
            return AllLines.ToList().GetRange(1, AllLines.Count - 2);
        }
    }
}