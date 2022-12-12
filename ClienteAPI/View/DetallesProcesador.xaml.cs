using ClienteAPI.Model.POCO;
using ClienteAPI.ViewModel;
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

namespace ClienteAPI.View
{
    /// <summary>
    /// Lógica de interacción para DetallesProcesador.xaml
    /// </summary>
    public partial class DetallesProcesador : Window
    {
        public DetallesProcesador(Procesador procesador, Laptop laptop)
        {
            InitializeComponent();
            DataContext = new DetallesProcesadorViewModel(procesador, laptop);
        }

        public DetallesProcesador(Procesador procesador, Laptop laptop, Usuario usuario)
        {
            InitializeComponent();
            DataContext = new DetallesProcesadorViewModel(procesador, laptop, usuario);
        }
    }
}
