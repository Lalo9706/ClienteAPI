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
    /// Lógica de interacción para DetallesTarjetaVideo.xaml
    /// </summary>
    public partial class DetallesTarjetaVideo : Window
    {
        public DetallesTarjetaVideo(TarjetaVideo gpu, Laptop laptop)
        {
            InitializeComponent();
            DataContext = new DetallesTarjetaVideoViewModel(gpu, laptop);
        }

        public DetallesTarjetaVideo(TarjetaVideo gpu, Laptop laptop, Usuario usuario)
        {
            InitializeComponent();
            DataContext = new DetallesTarjetaVideoViewModel(gpu, laptop, usuario);
        }
    }
}
