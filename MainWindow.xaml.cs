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

namespace TestSave
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        private string characters = "abcdefghijklmnopqrstuvwqyz";
        private string capCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public string numerals = "1234567890";
        public string special = "!@#$%^&*()_-+=?";
        public string selectionList = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("copied");
        }

        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            string password = "";
            string selectionList = characters;
            if (isNumeric.IsChecked == true)
                selectionList += numerals;
            if (isSpecial.IsChecked == true)
                selectionList += special;
            if (isCapital.IsChecked == true)
                selectionList += capCharacters;
            try
            {
                int.Parse(numOfChars.Text);
            }
            catch
            {
                numOfChars.Text = "0";
            }
            if (int.Parse(numOfChars.Text) <= 0)
                MessageBox.Show("You must enter a number greater than 0!");
            else
            {
                for (int i = 0; i < int.Parse(numOfChars.Text); i++)
                    password += selectionList[rnd.Next(selectionList.Length)];
                list.Items.Add($"Service: {serviceName.Text}, User: {userName.Text}, password: {password}");
            }
            serviceName.Text = "";
            userName.Text = "";
            numOfChars.Text = "";
            password = "";
            
        }
    }
}
