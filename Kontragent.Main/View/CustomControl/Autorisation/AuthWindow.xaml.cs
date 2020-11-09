using Kontragent.ViewModel.Autorisation;
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

namespace Kontragent.View.CustomControl.Autorisation
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            DataContext = new AuthorizationViewModel();
            AuthorizationViewModel.SuccessAuth += AuthorizationViewModelSuccessAuth;
        }

        private void AuthorizationViewModelSuccessAuth(object sender, EventArgs e)
        {
            ///если DataContext имеет тип AuthorizationViewModel то положи этот объект в sxsax(приведение)
            if (DataContext is AuthorizationViewModel sxsax)
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
                AuthorizationViewModel.SuccessAuth -= AuthorizationViewModelSuccessAuth;// отписываемся от события, чтобы не торчала ссылка
                this.Close();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            AuthorizationViewModel.SuccessAuth -= AuthorizationViewModelSuccessAuth;

        }
    }
}
