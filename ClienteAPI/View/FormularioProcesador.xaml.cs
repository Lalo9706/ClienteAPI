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
    /// Lógica de interacción para FormularioProcesador.xaml
    /// </summary>
    public partial class FormularioProcesador : Window
    {
        //Formulario cuando he iniciado sesión
        public FormularioProcesador(Laptop laptop, Usuario usuario)
        {
            InitializeComponent();
            DataContext = new FormularioProcesadorViewModel(laptop, usuario);
        }

        //Constructor para Modificar Laptop
        public FormularioProcesador(Laptop laptop, Usuario usuario, Procesador procesador)
        {
            InitializeComponent();
            DataContext = new FormularioProcesadorViewModel(laptop, usuario, procesador);
        }
    }
}
