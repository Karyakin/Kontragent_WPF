using Kontragent.View.Registration;
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
using Kontragent.View.CustomControl.Autorisation;

namespace Kontragent.View.CustomControl
{
    /// <summary>
    /// Логика взаимодействия для AutorisationView.xaml
    /// </summary>
    public partial class AutorisationView : UserControl
    {
        public AutorisationView()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = Window.GetWindow(this) as AuthWindow;
            var registrationWindow = new RegWindow();
            registrationWindow.Show();
            authWindow?.Close();
        }
    }
}
