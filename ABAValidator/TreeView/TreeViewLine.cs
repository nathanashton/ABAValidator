namespace ABAValidator.TreeView
{
    using System.Collections.Generic;
    using System.Linq;

    public class TreeViewLine
    {
        public int LineNumber { get; set; }
        public Helpers.LineType LineType { get; set; }
        public List<TreeViewField> Fields { get; set; }

        public bool Pass
        {
            get { return Fields.All(x => x.Pass); }
        }
    }
}