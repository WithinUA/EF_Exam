using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace EF_Exam
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        Collections coll;
        //public Customer Customer { get; set; }
        public Login()
        {
            InitializeComponent();
        }

        public Login(Collections c)
        {
            coll = c;
            InitializeComponent();
        }

        private void click_login_ev(object sender, MouseButtonEventArgs e)
        {
            try
            {
                (sender as TextBox).Text = string.Empty;
                (sender as TextBox).Foreground = System.Windows.Media.Brushes.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void pass_click_ev(object sender, MouseButtonEventArgs e)
        //{
        //    try
        //    {
        //        (sender as PasswordBox).Password = string.Empty;
        //        (sender as PasswordBox).Foreground = System.Windows.Media.Brushes.Black;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void login_button_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                //Customer cust = coll.Customers.FirstOrDefault(x => x.Login == login_box.Text && x.Password == pass_box.Password);
                //if (cust != null)
                //{
                //    Customer = cust;
                //    DialogResult = true;
                //    Close();
                //}
                if (login_box.Text == "admin" && pass_box.Password == "admin")
                {
                    DialogResult = true;
                    Close();
                }
                else
                {
                    MessageBox.Show("Login or password is incorrect!");
                    login_box.Text = string.Empty;
                    pass_box.Password = string.Empty;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pass_click_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                (sender as PasswordBox).Password = string.Empty;
                (sender as PasswordBox).Foreground = System.Windows.Media.Brushes.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void click_ev(object sender, MouseButtonEventArgs e)
        {
            try
            {
                Registration reg = new(coll);
                reg.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //private void guest_click_ev(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        Customer = new();
        //        DialogResult = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}
    }
}
