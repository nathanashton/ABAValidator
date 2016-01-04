using System;
using System.Drawing;
using System.Windows.Controls;
using ABAValidator.TreeView;
using System.Linq;

namespace ABAValidator
{
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel.ListBox = lb;
        }

        public ViewModel ViewModel => (ViewModel) Resources["ViewModel"];

        private void button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.SelectFile();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
        }

        private void lb_MouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void lb_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void TreeViewAdv_MouseEnter(object sender, MouseEventArgs e)
        {
        }

        private void StackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (sender == null) return;

            //Clear all lines
            foreach (Line line in lb.Items)
            {
                line.StartHighlight = 0;
                line.EndHighlight = 0;
            }



            try
            {
                var field = ((sender as StackPanel).DataContext) as TreeViewField;
                var positions = field.CharacterPositions;
                var middle = positions.IndexOf('-');
                var firstPosition = positions.Substring(1, middle - 1);
                var end = positions.IndexOf(']');
                var count = end - middle;
                var lastPosition = positions.Substring(middle + 1, count - 1);
                Go(field.LineNumber, Convert.ToInt32(firstPosition), Convert.ToInt32(lastPosition));
            }
            catch (Exception)
            {
                return;
            }
     
        }


        private void Go(int line, int start, int end)
        {
            var l = ViewModel.Lines.AllLines.FirstOrDefault(x => x.LineNumber == line);
            var index = lb.Items.IndexOf(l);
            var t = lb.Items[index] as Line;

            t.StartHighlight = start - 1;
            t.EndHighlight = end - start +1;

        }
    }
}