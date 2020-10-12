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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private UserControl ActiveControl;
        DispatcherTimer timer;
        UserDTO user;
        public UserWindow(UserDTO user)
        {
            InitializeComponent();
            this.user = user;
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 1);
            timer.Tick += Timer_Tick;
            timer.Start();
            Timer_Tick(this, EventArgs.Empty);
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            DateTime cur_date = DateTime.Now;
            lb_time.Content = cur_date.ToLongTimeString();
            lb_date.Content = cur_date.ToLongDateString();
        }
        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void BtnCloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnMaximizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void BtnMinimizeWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ButtonLogout_Click(object sender, RoutedEventArgs e)
        {
            LogSignWindow logSignWindow = new LogSignWindow();
            logSignWindow.Show();
            this.Close();
        }
        private void CloseActiveControl()
        {
            ActiveControl = null;
            Desktop.Children.Clear();
            RentalDesktop.Visibility = Visibility.Visible;
        }
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            CloseActiveControl();
        }
        private void OpenUserControl(UserControl userControl)
        {
            if (userControl is IChildWindow)
            {
                (userControl as IChildWindow).Closing += CloseActiveControl;
                (userControl as IChildWindow).OpenMsg += ShowMsg;
            }
            Desktop.Children.Clear();
            RentalDesktop.Visibility = Visibility.Hidden;
            Desktop.Children.Add(userControl);
            ActiveControl = userControl;
        }
        private void ShowMsg(string title, string msg)
        {
            MsgBox msgBox = new MsgBox(title, msg);
            msgBox.Owner = this;
            msgBox.ShowDialog();
        }
        private void ButtonBooks_Click(object sender, RoutedEventArgs e)
        {
            if (!(ActiveControl is SearchBooks))
                OpenUserControl(new SearchBooks(user));
        }

        private void ButtonShopping_Click(object sender, RoutedEventArgs e)
        {
            if (!(ActiveControl is Shoping))
                OpenUserControl(new Shoping(user));
        }

        private void ButtonReservs_Click(object sender, RoutedEventArgs e)
        {
            if (!(ActiveControl is Reservs))
                OpenUserControl(new Reservs(user));
        }

        private void ButtonRating_Click(object sender, RoutedEventArgs e)
        {
            if (!(ActiveControl is Rating))
                OpenUserControl(new Rating());
        }
    }
}
