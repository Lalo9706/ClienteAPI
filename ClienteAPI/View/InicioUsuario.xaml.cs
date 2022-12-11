using ClienteAPI.Model.POCO;
using ClienteAPI.ViewModel;
using System.Windows;

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para InicioUsuario.xaml
    /// </summary>
    public partial class InicioUsuario : Window
    {
        public InicioUsuario(Usuario usuario)
        {
            DataContext = new InicioUsuarioViewModel(usuario);
        }
    }
}
