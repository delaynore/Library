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

namespace Летняя_Практика_ООП_2_Курс
{
    public partial class Регистрация : Window
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Password == PasswordTextBoxSecond.Password)
            {
                using (LibraryDB db = new LibraryDB())
                {
                    Reader reader = new Reader { Name = NameTextBox.Text, Password = PasswordTextBox.Password };
                    try
                    {
                        db.Readers.Add(reader);
                        MessageBox.Show("Пользователь успешно зарегестрирован.");
                        db.SaveChanges();
                        this.Close();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Такой пользователь уже существует");
                    }
                }
            }
            else { PasswordTextBox.Password = PasswordTextBoxSecond.Password = ""; MessageBox.Show("Пароли не совпадают!"); }
        }
    }
}
