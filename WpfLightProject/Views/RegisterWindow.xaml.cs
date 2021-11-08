using System;
using System.Linq;
using System.Windows;

namespace WpfLightProject.Views
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
            BusinessComboBox.ItemsSource = Enum.GetValues(typeof(Models.BusinessBranch)).Cast<Models.BusinessBranch>();
            CompanySizeComboBox.ItemsSource = Enum.GetValues(typeof(Models.Enums.CompanySize)).Cast<Models.Enums.CompanySize>();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
