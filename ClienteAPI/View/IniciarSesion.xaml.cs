using ClienteAPI.ViewModel;
using System.Windows;

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para IniciarSesion.xaml
    /// </summary>
    public partial class IniciarSesion : Window
    {
        public IniciarSesion()
        {
            InitializeComponent();
            IniciarSesionViewModel iniciarSesionViewModel = new();
            DataContext = iniciarSesionViewModel;
            Closing += iniciarSesionViewModel.OnWindowClosing;
        }
    }
}
