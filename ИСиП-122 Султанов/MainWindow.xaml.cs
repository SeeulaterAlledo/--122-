using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace MathFunctionApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            // Проверка ввода
            if (!double.TryParse(InputX.Text, out double x) || !double.TryParse(InputB.Text, out double b))
            {
                MessageBox.Show("Введите корректные числовые значения!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            double result;
            double fx = 0;

            // Определение f(x)
            if (ShX.IsChecked == true)
                fx = Math.Sinh(x);
            else if (SquareX.IsChecked == true)
                fx = x * x;
            else if (ExpX.IsChecked == true)
                fx = Math.Exp(x);
            else
            {
                MessageBox.Show("Выберите функцию f(x)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Вычисление s по условиям
            double xb = x * b;
            if (1 < xb && xb < 10)
            {
                result = Math.Exp(fx);
            }
            else if (12 < xb && xb < 40)
            {
                result = Math.Sqrt(fx + 4 * b);
            }
            else
            {
                result = b * fx * fx;
            }

            // Вывод результата
            OutputResult.Text = result.ToString("F4");
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            InputX.Clear();
            InputB.Clear();
            OutputResult.Clear();
            ShX.IsChecked = false;
            SquareX.IsChecked = false;
            ExpX.IsChecked = false;
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
