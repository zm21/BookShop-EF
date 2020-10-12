using BLL;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LogSignWindow : Window
    {
        IUserService _userService;
        UserDTO regUser;
        UserDTO user;
        public LogSignWindow()
        {
            InitializeComponent();
            _userService = new UserService();
            regUser = new UserDTO();
            user = new UserDTO();

            SignUP.DataContext = regUser;
            login.DataContext = user;
        }

        private void Btn_signup_Click(object sender, RoutedEventArgs e)
        {
            login.Visibility = Visibility.Hidden;
            SignUP.Visibility = Visibility.Visible;
        }

        private void Btn_login_Click(object sender, RoutedEventArgs e)
        {
            SignUP.Visibility = Visibility.Hidden;
            login.Visibility = Visibility.Visible;
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            regUser.Passwd = regpasswd.Password;
            if (string.IsNullOrEmpty(regUser.Login) || string.IsNullOrEmpty(regUser.Email) || string.IsNullOrEmpty(regpasswd.Password))
            {
                MessageBox.Show("First fill all fields!!!", "Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                if (!_userService.IsExistUserWithThisLogin(regUser.Login))
                {
                    regUser.UserTypeId = _userService.GetAllUserTypes().FirstOrDefault(ut => ut.Name == "User").Id;
                    _userService.AddUser(regUser);
                    MessageBox.Show("Success!", "Registration", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    MessageBox.Show("Such user already exists!", "Registration", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            user.Passwd = passwd_box.Password;
            if (!_userService.IsExistUserWithThisLogin(user.Login))
                MessageBox.Show("User not found!", "LogIn", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                if (!_userService.IsExistsUserByLoginAndPassword(user.Login, user.Passwd))
                    MessageBox.Show("Wrong password", "LogIn", MessageBoxButton.OK, MessageBoxImage.Error);
                else
                {
                    user = _userService.GetUserByLoginAndPassword(user.Login, user.Passwd);
                    var usertype = new BLLClass().GetUserType(user);
                    if(usertype.Name=="Admin")
                    {
                        AdminWindow adminWindow = new AdminWindow();
                        adminWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        UserWindow userWindow = new UserWindow(user);
                        userWindow.Show();
                        this.Close();
                    }
                    //open menu 
                   
                }
            }
        }
    }
}
