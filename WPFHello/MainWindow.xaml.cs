using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HelloButton_Click(object sender, RoutedEventArgs e)
        {
            string nameInput = nameTextBox.Text;
            string message;
            if (nameInput.Length >= 2)
            {
                message = "Здрасти " + nameTextBox.Text + "!!! \nТова е твоята първа програма на VisualStudio 2017!";
            }
            else
            {
                message = "Това име е невалидно. Твърде е късо.";
            }
            MessageBox.Show(message); 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult dialogResult = MessageBox.Show("Искате ли да затворите приложението?", "", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                return;
            }
            else if (dialogResult == MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }

        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            string outputMessage;
            int numberInt = -1;
            bool tryParse = int.TryParse(nTextBox.Text, out numberInt);
            if (!tryParse)
            {
                outputMessage = "Невалидно число";
            }
            else
            {
                int result = numberInt;

                for (int i = 1; i < numberInt; i++)
                {
                    result = result * i;
                }
                outputMessage = result.ToString();
            }
            

            xTextBox.Text = outputMessage;
        }

        private void GridButton_Click(object sender, RoutedEventArgs e)
        {
            string s = "";
            foreach (var item in mainGrid.Children)
            {
                
                if (item is TextBox)
                {
                    s = s + ((TextBox)item).Text;
                    s = s + '\n';
                }
            }
            MessageBox.Show("Привет " + s);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello, Windows Presentation Foundation!");
            textBlock1.Text = DateTime.Now.ToString();
        }
    }
}
