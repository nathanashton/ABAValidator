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
    }
}