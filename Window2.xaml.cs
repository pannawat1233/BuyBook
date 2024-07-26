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
using static SQLite2.Window4;

namespace SQLite2
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private int i = 0;
        private int j = 0;
        private int k = 0;
        string[][] user = new string[10][];
         
       
        public Window2()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            
            if (i < user.Length)
            { 
                user [i] = new string[10];
                user[i][0] = i.ToString(); 
                i++;
                Window2_txt1.Content = i.ToString();
            }
            else
            {
                MessageBox.Show("ใส่ได้สุงสุดแค่ 10 ชิ้น");
            }
        }
        private void Window2_delete_Click(object sender, RoutedEventArgs e)
        {
            if (i > 0)
            {
                i--;
                Window2_txt1.Content = i.ToString();
            }
            else
            {
                MessageBox.Show("ไม่สามารภลบคำขอได้อีก");
            }

        }

        private void Window2_Buy_Click(object sender, RoutedEventArgs e)
        {

            string message = "";
            List<int> moneyValues = new List<int>();
            for (int index = 0; index < i; index++)
            { 
                j++;
                int money = j * 45;
                message += user[index][0]+ "\n";  
                moneyValues.Add(money);
            }
               
            DataStorage.MoneyList.Add(moneyValues);
            DataStorage.UserList.Add("คุณซ์้อหนังสือ" + "  อ่านชะตากรรมวันสิ้นโลก  " + "ทั้งหมด" + " " + j + " " + "เล่ม!!!");

            MessageBox.Show("คุณซ์้อหนังสือทั้งหมด"+" "+j+" "+"เล่ม!!!");
            Window4 window4 = new Window4();
            this.Close();
            window4.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            
            Window1 window1 = new Window1();
            this.Close();
            window1.Show();
        }
    }
}
