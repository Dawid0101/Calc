using Calc.Properties.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Calc.Properties
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private string _resultText;
        private string _screenValue;
        private List<string> _availibleOperations = new List<string> { "+", "-", "/", "*" };
        private DataTable _dataTable = new DataTable();
        private bool _isLastOperation;
        private bool _isComma;

        public MainViewModel()
        {
            ResultText = "";
            ScreenValue = "0";
            AddNumberCommand = new RelayCommand(AddNumber);
            AddOperationCommand = new RelayCommand(AddOperation, CanAddOperation);
            ResultCommand = new RelayCommand(ResultOperation, CanGetResult);
            ClearCommand = new RelayCommand(ClearOperation);
            BackspaceCommand = new RelayCommand(BackspaceOperation);
            AddComma = new RelayCommand(AddCommaOperation, CanAddComma);
        }

        private bool CanAddComma(object obj) => !_isComma;

        private void AddCommaOperation(object obj)
        {
            var comma = obj as string;


            if (ScreenValue == "0" && comma != ",")
            {
                ScreenValue = string.Empty;
            }
            else if (comma == "," && _availibleOperations.Contains(ScreenValue.Substring(ScreenValue.Length - 1)))
            {
                comma = "0,";
            }
            ScreenValue += comma;
            _isComma = true;
            _isLastOperation = false;
        }

        private void BackspaceOperation(object obj)
        {


            if (ScreenValue.Length == 1)
            {
                ScreenValue.ToString();
                ScreenValue = "";


            }

            else if (_isLastOperation = true)
            {
                ScreenValue.ToString();
                ScreenValue = "0";
                ScreenValue = ScreenValue.Substring(0, ScreenValue.Length - 1);
                
                _isLastOperation = false;
            }

            else
            {

                ScreenValue.ToString();
                ScreenValue = ScreenValue.Substring(0, ScreenValue.Length - 1);
                _isLastOperation = true;

            }
        }

        private bool CanGetResult(object obj) => !_isLastOperation;

        private bool CanAddOperation(object obj) => !_isLastOperation;

        private void ClearOperation(object obj)
        {
            ScreenValue = "0";
            ResultText = "";

            _isLastOperation = false;
            _isComma = false;
        }

        private void ResultOperation(object obj)
        {
            var result = Math.Round(Convert.ToDouble((_dataTable.Compute(ScreenValue.Replace(",", "."), ""))), 2);
            ResultText = result.ToString();
            ScreenValue = "";
        }

        private void AddOperation(object obj)
        {
            var operation = obj as string;

            ScreenValue += operation;

            _isLastOperation = true;
        }

        private void AddNumber(object obj)
        {
            var number = obj as string;

            if (ScreenValue == "0" && number != ",")
            {
                ScreenValue = string.Empty;
            }
            else if (number == "," && _availibleOperations.Contains(ScreenValue.Substring(ScreenValue.Length - 1)))
            {
                number = "0,";
            }
            ScreenValue += number;

            _isLastOperation = false;
            _isComma = false;
        }

        public ICommand AddNumberCommand { get; set; }
        public ICommand AddOperationCommand { get; set; }
        public ICommand ResultCommand { get; set; }
        public ICommand ClearCommand { get; set; }
        public ICommand BackspaceCommand { get; set; }
        public ICommand AddComma { get; set; }


        public string ResultText
        {
            get { return _resultText; }
            set
            {
                _resultText = value;
                OnPropertyChanged();
            }
        }

        public string ScreenValue
        {
            get { return _screenValue; }
            set
            {
                _screenValue = value;
                OnPropertyChanged();
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
    }
}
