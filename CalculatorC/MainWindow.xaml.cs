using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using System.Threading;
using System.Globalization;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CalculatorC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public static class Globals
    {
        public static string lmao;
    }

    public partial class MainWindow : Window
    {
        Dictionary<string, string> OperationDict; 
        string num2Str = ""; // Временная переменнаял
        public MainWindow()
        {
            InitializeComponent();

            Delete.Click += BtnC_Click;
            DeleteAll.Click += BtnC_Click;
            Enter.Click += BtnE_Click;
            PlusAndMinus.Click += PnM_Click;
            DeleteSymbol.Click += TrimLastEntry;
            sqrt.Click += OnSquareRootClick;
            _1divNumber.Click += divNumber;
            Dot.Click += addDot;
            powerof.Click += powerofs;
            percent.Click += percents;

            NumberMC.Click += Memory;
            NumberMCminus.Click += Memory;
            NumberMHistory.Click += Memory;
            NumberMplus.Click += Memory;
            NumberMR.Click += Memory;
            NumberMS.Click += Memory;

            Division.Click += new RoutedEventHandler(BtnOperator_Click);
            Multiplication.Click += new RoutedEventHandler(BtnOperator_Click);
            Minus.Click += new RoutedEventHandler(BtnOperator_Click);
            Plus.Click += new RoutedEventHandler(BtnOperator_Click);

            Number9.Click += new RoutedEventHandler(BtnNum_Click);
            Number8.Click += new RoutedEventHandler(BtnNum_Click);
            Number7.Click += new RoutedEventHandler(BtnNum_Click);
            Number6.Click += new RoutedEventHandler(BtnNum_Click);
            Number5.Click += new RoutedEventHandler(BtnNum_Click);
            Number4.Click += new RoutedEventHandler(BtnNum_Click);
            Number3.Click += new RoutedEventHandler(BtnNum_Click);
            Number2.Click += new RoutedEventHandler(BtnNum_Click);
            Number1.Click += new RoutedEventHandler(BtnNum_Click);
            Number0.Click += new RoutedEventHandler(BtnNum_Click);

            OperationDict = new Dictionary<string, string>();

        }
        private void Memory(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функции не добавлены.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void percents(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция ещё не доработана.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void powerofs(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция ещё не доработана.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void addDot(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция ещё не доработана.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }


        private void divNumber(object sender, RoutedEventArgs e)
        {
            try
            {
             
                //string str1 = "";
                if (true)
                {// Если два операнда и оператора в словаре не пусты, то выполнить операцию
                    double num1 = double.Parse(MainText.Text);
                    MainText.Text = Math.Round( 1 / num1).ToString();
                    //OperationDict.Clear();
                    //OperationDict.Add("Num1", MainText.Text);
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }

        private void BtnOperator_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                var opr = sender as Button;
                if (MainText.Text == "")
                    return;

                switch (opr.Content.ToString())
                {
                    case "+":
                        OperationDict.Add("Operator", "+");
                        break;
                    case "÷":
                        OperationDict.Add("Operator", "÷");
                        break;
                    case "×":
                        OperationDict.Add("Operator", "×");
                        break;
                    case "-":
                        OperationDict.Add("Operator", "-");
                        break;
                    
                }
                MainText.Text += opr.Content.ToString();
            }
            catch (Exception e2)
            {
                MessageBox.Show(e2.ToString());
            }
        }
        private void OnSquareRootClick(object sender, RoutedEventArgs e)
        {
            double number;
            var isDouble = double.TryParse(MainText.Text, out number);
            if (isDouble)
            {
                MainText.Text = string.Format("{0}", Math.Round(Math.Sqrt(number), 2));
            }

        }

        private void BtnE_Click(object sender, RoutedEventArgs e) 
        {
            try
            {
                MainText.Text += "=";
                string str1 = "", str2 = "", opr = "";
                if (OperationDict.TryGetValue("Num1", out str1) && OperationDict.TryGetValue("Operator", out opr) && OperationDict.TryGetValue("Num2", out str2))
                {// Если два операнда и оператора в словаре не пусты, то выполнить операцию
                    decimal num1 = decimal.Parse(str1);
                    decimal num2 = decimal.Parse(str2);
                    switch (opr)
                    {
                        case "+":
                            MainText.Text = (num1 + num2).ToString();
                            break;
                        case "-":
                            MainText.Text = (num1 - num2).ToString();
                            break;
                        case "×":
                            MainText.Text = (num1 * num2).ToString();
                            break;
                        case "÷":
                            MainText.Text = (num1 / num2).ToString();
                            break;
                    }
                    //MessageBox.Show(OperationDict["Num1"] + ":" + OperationDict["Operator"] + ":" + OperationDict["Num2"]);
                    OperationDict.Clear();
                    num2Str = "";
                    OperationDict.Add("Num1", MainText.Text);
                }
                else
                {
                    return;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.ToString());
            }
        }
        private void TrimLastEntry(object sender, RoutedEventArgs e)
        {
            if (MainText.Text.Length == 0)
            {
                return;
            }
            else
            {
                MainText.Text = MainText.Text.Remove(MainText.Text.Length - 1);
            }
        }
        private void BtnC_Click(object sender, RoutedEventArgs e) 
        {
            OperationDict.Clear();
            MainText.Text = "";
            num2Str = "";
        }
        private void PnM_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Эта функция ещё не доработана.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BtnNum_Click(object sender, RoutedEventArgs e) 
        {
            var num = sender as Button;
            string value = "";
            if (!OperationDict.TryGetValue("Operator", out value))
            {// Оператор пуст, сохраненный номер является первым
                if (MainText.Text == "")
                {
                    MainText.Text = num.Content.ToString();
                    OperationDict.Add("Num1", num.Content.ToString());
                }
                else
                {
                    MainText.Text += num.Content.ToString();
                    OperationDict["Num1"] = MainText.Text;
                }
            }
            else
            {// Оператор не пуст, сохраненный номер является вторым
                if (num2Str == "")
                {
                    MainText.Text += num.Content.ToString();
                    num2Str += num.Content.ToString();
                    OperationDict.Add("Num2", num.Content.ToString());
                }
                else
                {
                    MainText.Text += num.Content.ToString();
                    num2Str += num.Content.ToString();
                    OperationDict["Num2"] = num2Str;
                }
            }

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            /*//var text = ((Button)e.OriginalSource).Content;
            var text = ((Button)sender).Content;
            //MainText.Text += text;
            var isOperator = _isCommonOperator.Any(p => p == text);
            if (isOperator)
            {
                if(double.TryParse(MainText.Text, out double temp))
                {
                    _reservedNumber1 = temp;
                    MainText.Clear();
                    Main2Text.Text = $"{_reservedNumber1}{text}";
                }
            }
            else
            {
                MainText.Text += text;
            }*/
        }
    }
}
