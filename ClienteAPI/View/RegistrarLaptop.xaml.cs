using ClienteAPI.Model.POCO;
using ClienteAPI.ViewModel;
using System.Windows;

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para RegistrarLaptop.xaml
    /// </summary>
    public partial class RegistrarLaptop : Window
    {
        public RegistrarLaptop(Usuario usuario)
        {
            InitializeComponent();
            DataContext = new RegistrarLaptopViewModel(usuario);
        }
    }
}
