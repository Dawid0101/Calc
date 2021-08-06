using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private object elements;

        public MainWindow()
        {
            InitializeComponent();
            Title = "Calculator";

            ResultText.Foreground = Brushes.White;
            CurrentOperationText.Foreground = Brushes.White;

            ResultText.Text = string.Empty;
            CurrentOperationText.Text = string.Empty;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ResultText.Text = string.Empty;

            var button = sender as Button;

            var currentNumber = button.Name[button.Name.Length - 1];

            CurrentOperationText.Text += currentNumber;
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperation(operation))
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }

            CurrentOperationText.Text += "+";
        }

        private void ButtonMinus_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperation(operation))
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "-";
        }

        private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperation(operation))
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "*";
        }

        private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperation(operation))
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "/";
        }

        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;


            ResultText.Text = CalculateResult(operation).ToString();

            CurrentOperationText.Text = string.Empty;
        }

        private bool ContainsOperation(string operation) => operation.Contains('+') || operation.Contains('-') || operation.Contains('*') || operation.Contains('/');
        private int CalculateResult(string operation)
        {
            if (operation.Contains('+'))
            {

                var elements = operation.Split('+');

                return int.Parse(elements[0]) + int.Parse(elements[1]);



            }

            if (operation.Contains('-'))
            {

                var elements = operation.Split('-');

                return int.Parse(elements[0]) - int.Parse(elements[1]);


            }
            if (operation.Contains('*'))
            {

                var elements = operation.Split('*');

                return int.Parse(elements[0]) * int.Parse(elements[1]);


            }
            if (operation.Contains('/'))
            {

                var elements = operation.Split('/');

                return int.Parse(elements[0]) / int.Parse(elements[1]);



            }
            return default;
        }

        private void ButtonPowerOff_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
