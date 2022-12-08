using ClienteAPI.ViewModel;
using System.Windows;

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para InicioUsuario.xaml
    /// </summary>
    public partial class InicioUsuario : Window
    {
        public InicioUsuario()
        {
            InitializeComponent();
            DataContext = new InicioUsuarioViewModel();
        }
    }
}
