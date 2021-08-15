
using Calc.Properties;
using System.Windows;
using System.Windows.Media;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object elements;
        private object send;

        public object Number1 { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Title = "Calculator";

            ResultText.Foreground = Brushes.White;
            ScreenValue.Foreground = Brushes.White;

            DataContext = new MainViewModel();



        }





        private void closeApp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                Close();
            }
            catch
            {

            }
        }

        private void minimizeApp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            try
            {
                this.WindowState = WindowState.Minimized;
            }
            catch
            {

            }
        }



        private void ButtonPowerOff_Click(object sender, RoutedEventArgs e)
        {
            ScreenValue.Text = string.Empty;
            ResultText.Text = string.Empty;
        }
    }
}
