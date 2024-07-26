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
using System.Windows.Shapes;

namespace SQLite2
{
    /// <summary>
    /// Interaction logic for Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
            DataAccess.InitializeDatabase();
            DataAccess.AddData("");
        }
        public class DataStorage
        {

            public static List<string> UserList { get; set; } = new List<string>();
            public static List<List<int>> MoneyList { get; set; } = new List<List<int>>();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            string cData = string.Join("\n", DataStorage.UserList);
            string money = string.Join("\n", DataStorage.MoneyList.Select(b => b.Last().ToString()));
            txt1.Text = money;
            Window4_Label.Content = (cData+" "+"ราคา"+" "+ money);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int money = int.Parse(string.Join("", DataStorage.MoneyList.Select(b => b.Last().ToString())));
            int window4_money = int.Parse(Window4_money.Text);

            int truemoney = window4_money - money ;
            Window4_tontan.Text = truemoney.ToString();
        }
    }
}
