using Calc.Properties.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Calc.Properties
{
    public class MainViewModel : INotifyPropertyChanged
    {


        private string _screenValue;
        private List<string> _availibleOperations = new List<string> { "+", "-", "/", "*" };
        private DataTable _dataTable = new DataTable();
        private bool _isLastOperation;
        
        public MainViewModel()
        {
            ScreenValue = "0";
            AddNumberCommand = new RelayCommand(AddNumber);
            AddOperationCommand = new RelayCommand(AddOperation, CanAddOperation);
            ResultCommand = new RelayCommand(ResultOperation, CanGetResult);
            ClearCommand = new RelayCommand(ClearOperation);
            BackspaceCommand = new RelayCommand(BackspaceOperation);
        }

        private void BackspaceOperation(object obj)
        {
           

            if (ScreenValue.Length == 1)
            {
                ScreenValue.ToString();
                ScreenValue = "";
                

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

            _isLastOperation = false;
        }

        private void ResultOperation(object obj)
        {
            var result = Math.Round(Convert.ToDouble((_dataTable.Compute(ScreenValue.Replace(",", "."), ""))), 2);

            ScreenValue = result.ToString();
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

            if(ScreenValue=="0" && number != ",")
            {
                ScreenValue = string.Empty;
            }    
            else if (number == "," && _availibleOperations.Contains(ScreenValue.Substring(ScreenValue.Length-1)))
            {
                number = "0,";
            }
            ScreenValue += number;

            _isLastOperation = false;
        }

        public ICommand AddNumberCommand { get; set; }
        public ICommand AddOperationCommand { get; set; }
        public ICommand ResultCommand { get; set; }
        public ICommand ClearCommand { get; set; }
         
        public ICommand BackspaceCommand { get; set; }


        public string ScreenValue
        {
            get { return _screenValue; }
            set { 
                _screenValue = value;
                OnPropertyChanged();
                }
        }



        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new
                PropertyChangedEventArgs(propertyName));
        }
    }
}
