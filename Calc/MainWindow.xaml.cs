
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
        private object send;

        public object Number1 { get; private set; }

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

        private void ButtonPercent_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;

            if (ContainsOperation(operation))
            {
                CurrentOperationText.Text = CalculateResult(operation).ToString();
            }
            CurrentOperationText.Text += "%";
        }
        private void ButtonDot_Click(object sender, RoutedEventArgs e)
        {
            if (!CurrentOperationText.Text.Contains('.'))
            {
                CurrentOperationText.Text += ".";
            }

        }
        private void ButtonResult_Click(object sender, RoutedEventArgs e)
        {
            var operation = CurrentOperationText.Text;


            ResultText.Text = CalculateResult(operation).ToString();

            CurrentOperationText.Text = string.Empty;
        }

        private bool ContainsOperation(string operation) => operation.Contains('+') || operation.Contains('-') || operation.Contains('*') || operation.Contains('/') || operation.Contains('%');
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
            if (operation.Contains('%'))
            {
                var elements = operation.Split('%');
                return int.Parse(elements[0]) % int.Parse(elements[1]);
            }
            
            
            

            return default;
        }

        private void ButtonPowerOff_Click(object sender, RoutedEventArgs e)
        {
            CurrentOperationText.Text = string.Empty;
            ResultText.Text = string.Empty;
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {

            CurrentOperationText.Text = string.Empty;
            ResultText.Text = string.Empty;
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

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentOperationText.Text.Length == 1)
            {
                CurrentOperationText.Text = "";

            }
            
           
            else  
            {
                
                
                CurrentOperationText.Text = CurrentOperationText.Text.Substring(0, CurrentOperationText.Text.Length - 1);
            }

            
        }
        
        
        private void CurrentOperationText_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Return)
            {
                CurrentOperationText.Text = CurrentOperationText.Text;
            }
        }

        
    }
}
