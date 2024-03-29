using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        Collections coll;
        Customer customer = new();
        public Registration()
        {
            InitializeComponent();
        }

        public Registration(Collections c)
        {
            coll = c;
            InitializeComponent();
        }

        private void textbox_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                TextBox tb = sender as TextBox;
                tb.Text = string.Empty;
                tb.Foreground = Brushes.Black;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void pass_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                pass_box.Password = string.Empty;
                pass_box.Foreground = Brushes.Black;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void register_ev(object sender, RoutedEventArgs e)
        {
            try
            {
                bool errors = false;

                if (!string.IsNullOrEmpty(fname_box.Text))
                    customer.FirstName = fname_box.Text;
                else
                {
                    errors = true;
                    MessageBox.Show("First Name can`t be empty");
                }
                if (!string.IsNullOrEmpty(lname_box.Text))
                    customer.LastName = lname_box.Text;
                else
                {
                    errors = true;
                    MessageBox.Show("Last Name can`t be empty");
                }
                string pattern = @"^[a-z0-9A-Z_]{3,}$";
                Customer el = coll.Customers.AsEnumerable().FirstOrDefault(x => x.Login == login_box.Text);
                if (el == null && Regex.IsMatch(login_box.Text, pattern) && login_box.Text != "admin")
                {
                    customer.Login = login_box.Text;
                }
                else
                {
                    errors = true;
                    MessageBox.Show("You can`t use this login");
                }
                if (Regex.IsMatch(pass_box.Password, pattern))
                {
                    customer.Password = pass_box.Password;
                }
                else
                {
                    errors = true;
                    MessageBox.Show("Password doesn`t match to the template, you can use letters, numbers and symbol _ only");
                }


                if (!errors)
                {
                    coll.AddCustomerToDb(customer);
                    MessageBox.Show("You was succesfully registered!");
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
