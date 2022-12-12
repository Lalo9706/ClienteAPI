using ClienteAPI.Model.POCO;
using ClienteAPI.ViewModel;
using System.Windows;

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para RegistrarLaptop.xaml
    /// </summary>
    public partial class FormularioLaptop : Window
    {
        public FormularioLaptop(Usuario usuario)
        {
            InitializeComponent();
            DataContext = new FormularioLaptopViewModel(usuario);
        }
    }
}
