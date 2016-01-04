namespace ABAValidator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class Line : NotifyBase
    {

        private int _startHighlight;
        private int _endHighlight;
        public Line()
        {
            Characters = new ObservableCollection<char>();
        }

        public Helpers.LineType LineType { get; set; }
        public int LineNumber { get; set; }
        public ObservableCollection<char> Characters { get; set; }

        public string CharactersString
        {
            get { return string.Join("", Characters); }
        }

        public override string ToString()
        {
            return string.Join("", Characters);
        }

        public char GetChar(int index)
        {
            return Characters[index - 1];
        }

        public string GetCharAsString(int index)
        {
            return Characters[index - 1].ToString();
        }

        public int GetCharAsAscii(int index)
        {
            try
            {
                var ascii = (int) Characters[index - 1];
                return ascii;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                throw;
            }
        }

        public List<char> GetCharRange(int startIndex, int endIndex)
        {
            return Characters.ToList().GetRange(startIndex - 1, (endIndex + 1) - startIndex);
        }

        public string GetCharRangeAsString(int startIndex, int endIndex)
        {
            var all = Characters.ToList().GetRange(startIndex - 1, (endIndex + 1) - startIndex);
            return string.Join("", all);
        }

        public List<int> GetCharRangeAsAscii(int startIndex, int endIndex)
        {
            var asciiList = new List<int>();
            var chars = Characters.ToList().GetRange(startIndex - 1, (endIndex + 1) - startIndex);
            foreach (var c in chars)
            {
                asciiList.Add(c);
            }
            return asciiList;
        }

        public int StartHighlight
        {
            get { return _startHighlight; }
            set
            {
                _startHighlight = value;
                NotifyPropertyChanged("StartHighlight");
            }
        }

        public int EndHighlight
        {
            get { return _endHighlight; }
            set
            {
                _endHighlight = value;
                NotifyPropertyChanged("EndHighlight");
            }
        }
    }
}