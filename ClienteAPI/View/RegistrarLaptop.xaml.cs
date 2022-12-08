using ClienteAPI.ViewModel;
using System.Windows;

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para RegistrarLaptop.xaml
    /// </summary>
    public partial class RegistrarLaptop : Window
    {
        public RegistrarLaptop()
        {
            InitializeComponent();
            DataContext = new RegistrarLaptopViewModel();
        }
    }
}
