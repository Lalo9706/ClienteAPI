using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ClienteAPI.ViewModel
{
    public class DetallesPantallaViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public DetallesPantallaViewModel(Pantalla pantalla, Laptop laptop)
        {
            this.pantallaActual = pantalla;
            this.laptopActual = laptop;
            ColocarDatos();
        }

        public DetallesPantallaViewModel(Pantalla pantalla, Laptop laptop, Usuario usuario)
        {
            this.pantallaActual = pantalla;
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR 

        #region ATTRIBUTES

        public Pantalla pantallaActual;
        public Usuario? usuarioActual;
        public Laptop laptopActual;
        private bool isBtnModificarEnabled = false;

        //General
        public string? idRegistro = "";
        public string? modelo = "";
        public string? resolucion = "";
        public string? calidad = "";
        public string? tipoPantalla = "";
        public string? tamaño = "";
        public int? frecuenciaRefresco = 0;

        #endregion ATRIBUTES

        #region PROPERTIES

        public bool IsBtnModificarEnabled
        {
            get { return this.isBtnModificarEnabled; }
            set { SetValue(ref this.isBtnModificarEnabled, value); }
        }
        public string? ID
        {
            get { return this.idRegistro; }
            set { SetValue(ref this.idRegistro, value); }
        }

        public string? Modelo
        {
            get { return this.modelo; }
            set { SetValue(ref this.modelo, value); }
        }

        public string? Resolucion
        {
            get { return this.resolucion; }
            set { SetValue(ref this.resolucion, value); }
        }

        public string? Calidad
        {
            get { return this.calidad; }
            set { SetValue(ref this.calidad, value); }
        }

        public string? TipoPantalla
        {
            get { return this.tipoPantalla; }
            set { SetValue(ref this.tipoPantalla, value); }
        }

        public string? Tamaño
        {
            get { return this.tamaño; }
            set { SetValue(ref this.tamaño, value); }
        }

        public int? FrecuenciaRefresco
        {
            get { return this.frecuenciaRefresco; }
            set { SetValue(ref this.frecuenciaRefresco, value); }
        }

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ClickModificar
        {
            get { return new RelayCommand(Modificar); }
            set { }
        }

        public ICommand ClickCerrar
        {
            get { return new RelayCommand(Cerrar); }
            set { }
        }

        #endregion COMMANDS

        #region METHODS

        private void ColocarDatos()
        {
            this.ID = pantallaActual.idRegistro;
            this.Modelo = pantallaActual.modelo;
            this.Resolucion = pantallaActual.resolucion;
            this.Calidad = pantallaActual.calidad;
            this.TipoPantalla = pantallaActual.tipoPantalla;
            this.Tamaño = pantallaActual.tamanio;
            this.FrecuenciaRefresco = pantallaActual.frecuenciaRefresco;

            if (usuarioActual != null) { isBtnModificarEnabled = true; }
        }

        private void Modificar()
        {
            MessageBox.Show("Modificar Pantalla");
            /*
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new FormularioHDD(laptopActual, usuarioActual, hddActual);
            Application.Current.MainWindow.Show();*/

        }

        private void Cerrar()
        {
            Application.Current.MainWindow.Hide();
            if (usuarioActual != null)
            {
                Application.Current.MainWindow = new DetallesLaptop(laptopActual, usuarioActual);
            }
            else
            {
                Application.Current.MainWindow = new DetallesLaptop(laptopActual);
            }
            Application.Current.MainWindow.Show();
        }

        #endregion METHODS

    }
}
