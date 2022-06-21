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
using Microsoft.EntityFrameworkCore;

namespace Летняя_Практика_ООП_2_Курс
{
    /// <summary>
    /// Логика взаимодействия для EntryWindow.xaml
    /// </summary>
    public partial class EntryWindow : Window
    {
        MainWindow mainWindow;
        public EntryWindow(MainWindow main)
        {
            InitializeComponent();
            mainWindow = main;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (LibraryDB db = new LibraryDB())
            {
                var reader = db.Readers.Include(x=>x.familiarizedBooks).Include(x=>x.onHandsBooks).FirstOrDefault(x => x.Name == NameTextBox.Text && x.Password == PasswordTextBox.Password);
                if (reader != null)
                {
                    Close();
                    mainWindow.Show();
                    mainWindow.EntryCloses(reader);
                }
                else { PasswordTextBox.Password = ""; MessageBox.Show("Проверьте правильность введенных данных!"); }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Регистрация reg = new Регистрация();
            reg.Show();
        }
    }
}
