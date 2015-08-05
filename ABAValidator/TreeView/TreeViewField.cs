namespace ABAValidator.TreeView
{
    using System.Collections.Generic;
    using System.Linq;

    public class TreeViewField
    {
        public string FieldDescription { get; set; }
        public List<TreeViewRule> Rules { get; set; }
        public string CharacterPositions { get; set; }

        public bool Pass
        {
            get { return Rules.All(x => x.Pass); }
        }

        public int LineNumber { get; set; }
    }
}