namespace ABAValidator
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    using BodyFields;
    using HeaderFields;
    using FooterFields;
    using Interfaces;
    using Microsoft.Win32;
    using TreeView;

    public class ViewModel : NotifyBase
    {

        private readonly ObservableCollection<IField> _fieldResults;
        private Brush _borderBrush;
        private Lines _lines;
        private ICollectionView _results;
        private string _searchText;
        private object _selectedItem;
        private Line _selectedLine;
        private Result _selectedResult;
        private ObservableCollection<TreeViewLine> _treeViewResults;
        private string _valid;
        private Brush _validColor;

        public ViewModel()
        {
            BorderBrush = Brushes.White;
            _fieldResults = new ObservableCollection<IField>();
            Lines = new Lines();
            Results = CollectionViewSource.GetDefaultView(_fieldResults);
            Results.GroupDescriptions.Add(new PropertyGroupDescription("RuleLine"));
        }

 



        public object SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                var line = value as TreeViewLine;
                if (line != null)
                {
                    SelectedLine = Lines.AllLines.First(x => x.LineNumber == line.LineNumber);
                }
                var field = value as TreeViewField;
                if (field != null)
                {
                    SelectedLine = Lines.AllLines.First(x => x.LineNumber == field.LineNumber);
                }
                var rule = value as TreeViewRule;
                if (rule != null)
                {
                    SelectedLine = Lines.AllLines.First(x => x.LineNumber == rule.LineNumber);
                }

                NotifyPropertyChanged("SelectedItem");
            }
        }

        public string Valid
        {
            get { return _valid; }
            set
            {
                _valid = value;
                NotifyPropertyChanged("Valid");
            }
        }

        public Brush ValidColor
        {
            get { return _validColor; }
            set
            {
                _validColor = value;
                NotifyPropertyChanged("ValidColor");
            }
        }

        public Brush BorderBrush
        {
            get { return _borderBrush; }
            set
            {
                _borderBrush = value;
                NotifyPropertyChanged("BorderBrush");
            }
        }

        public ICollectionView Results
        {
            get { return _results; }
            set
            {
                _results = value;
                NotifyPropertyChanged("Results");
            }
        }

        public ListBox ListBox { get; set; }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;

                NotifyPropertyChanged("SearchText");
            }
        }

        public Line SelectedLine
        {
            get { return _selectedLine; }
            set
            {
                _selectedLine = value;
                NotifyPropertyChanged("SelectedLine");
            }
        }

        public Result SelectedResult
        {
            get { return _selectedResult; }
            set
            {
                _selectedResult = value;

                NotifyPropertyChanged("SelectedResult");
            }
        }

        public Lines Lines
        {
            get { return _lines; }
            set
            {
                _lines = value;
                NotifyPropertyChanged("Lines");
            }
        }

        public ObservableCollection<TreeViewLine> TreeViewResults
        {
            get { return _treeViewResults; }
            set
            {
                _treeViewResults = value;
                NotifyPropertyChanged("TreeViewResults");
            }
        }

        public void SelectFile()
        {
            Lines.AllLines.Clear();
            _fieldResults.Clear();
            Helpers.AllFields.Clear();
            BorderBrush = Brushes.White;
            Valid = "";
            TreeViewResults = new ObservableCollection<TreeViewLine>();

            _fieldResults.Clear();
            Results = CollectionViewSource.GetDefaultView(_fieldResults);
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Read(openFileDialog.FileName);
            }
        }

        public void Read(string file)
        {
            string line;
            var reader = new StreamReader(file);
            var i = 1;
            while ((line = reader.ReadLine()) != null)
            {
                var l = new Line {LineNumber = i++};
                foreach (var c in line.ToCharArray())
                {
                    l.Characters.Add(c);
                }
                Lines.AllLines.Add(l);
            }
            Lines.AllLines[0].LineType = Helpers.LineType.Header;
            Lines.AllLines[Lines.AllLines.Count() - 1].LineType = Helpers.LineType.Footer;
            foreach (var f in Lines.AllLines)
            {
                if (f.LineType == Helpers.LineType.Nil)
                {
                    f.LineType = Helpers.LineType.Body;
                }
            }
            Validate();
        }

        public void Validate()
        {
            Helpers.AllFields.Add(new HeaderField1(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField2(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField3(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField4(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField5(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField6(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField7(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField8(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField9(Lines.GetFirstLine()));
            Helpers.AllFields.Add(new HeaderField10(Lines.GetFirstLine()));


            foreach (var line in Lines.GetBodyLines())
            {
                Helpers.AllFields.Add(new BodyField1(line));
                Helpers.AllFields.Add(new BodyField2(line));
                Helpers.AllFields.Add(new BodyField3(line));
                Helpers.AllFields.Add(new BodyField4(line));
                Helpers.AllFields.Add(new BodyField5(line));
                Helpers.AllFields.Add(new BodyField6(line));
                Helpers.AllFields.Add(new BodyField7(line));
                Helpers.AllFields.Add(new BodyField8(line));
                Helpers.AllFields.Add(new BodyField9(line));
                Helpers.AllFields.Add(new BodyField10(line));
                Helpers.AllFields.Add(new BodyField11(line));
                Helpers.AllFields.Add(new BodyField12(line));
            }


            Helpers.AllFields.Add(new FooterField1(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField2(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField3(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField4(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField5(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField6(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField7(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField8(Lines.GetLastLine()));
            Helpers.AllFields.Add(new FooterField9(Lines.GetLastLine()));


            foreach (var field in Helpers.AllFields.Where(x => x.Line.LineType == Helpers.LineType.Header))
            {
                field.RunRules();
                _fieldResults.Add(field);
            }

            foreach (var field in Helpers.AllFields.Where(x => x.Line.LineType == Helpers.LineType.Body))
            {
                field.RunRules();
                _fieldResults.Add(field);
            }

            foreach (var field in Helpers.AllFields.Where(x => x.Line.LineType == Helpers.LineType.Footer))
            {
                field.RunRules();
                _fieldResults.Add(field);
            }

            Results.Refresh();
            RenderTreeView();
            if (_fieldResults.All(x => x.RuleResults.All(r => r.Pass)))
            {
                BorderBrush = Brushes.Green;
                Valid = "Valid";
                ValidColor = Brushes.Green;
            }
            else
            {
                BorderBrush = Brushes.Red;
                Valid = "Invalid";
                ValidColor = Brushes.Red;
            }
        }

        private void RenderTreeView()
        {
            TreeViewResults = new ObservableCollection<TreeViewLine>();


            foreach (var lineNumber in Lines.AllLines)
            {
                var treeLine = new TreeViewLine {Fields = new List<TreeViewField>()};
                var resultsForLine = _fieldResults.Where(y => y.Line.LineNumber == lineNumber.LineNumber).ToList();
                // Get Results for line
                foreach (var field in resultsForLine)
                {
                    var f = new TreeViewField
                    {
                        FieldDescription = field.FieldDescription,
                        Rules = new List<TreeViewRule>(),
                        CharacterPositions = "[" + field.CharacterPositionStart + "-" + field.CharacterPositionEnd + "]",
                        LineNumber = lineNumber.LineNumber
                    };
                    foreach (var rule in field.RuleResults)
                    {
                        var t = new TreeViewRule
                        {
                            Pass = rule.Pass,
                            Specification = rule.Rule.Specification,
                            //ExtractedText =
                            //    "(" +
                            //    rule.Rule.Line.GetCharRangeAsString(rule.Rule.Field.CharacterPositionStart,
                            //        rule.Rule.Field.CharacterPositionEnd) + ")",
                            //LineNumber = lineNumber.LineNumber
                        };
                        f.Rules.Add(t);
                    }
                    treeLine.Fields.Add(f);
                }

                treeLine.LineNumber = lineNumber.LineNumber;
                treeLine.LineType = lineNumber.LineType;
                TreeViewResults.Add(treeLine);
            }
        }
    }
}