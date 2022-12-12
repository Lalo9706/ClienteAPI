using ClienteAPI.Model.API;
using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClienteAPI.ViewModel
{
    public class DetallesProcesadorViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public DetallesProcesadorViewModel(Procesador procesador, Laptop laptop)
        {
            this.procesadorActual = procesador;
            this.laptopActual = laptop;
            ColocarDatos();
        }

        public DetallesProcesadorViewModel(Procesador procesador, Laptop laptop, Usuario usuario)
        {
            this.procesadorActual = procesador;
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR 

        #region ATTRIBUTES

        public Procesador procesadorActual;
        public Usuario? usuarioActual;
        public Laptop laptopActual;
        private bool isBtnModificarEnabled = false;

        //General
        public string? idRegistro = "";
        public string? modelo = "";
        public string? marca = "";
        public int? numeroNucleos = 0;
        public int? numeroHilos = 0;
        public double? velocidadMinima = 0;
        public double? velocidadMaxima = 0;
        public int? litografia = 0;

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

        public string? Marca
        {
            get { return this.marca; }
            set { SetValue(ref this.marca, value); }
        }

        public int? NumeroNucleos
        {
            get { return this.numeroNucleos; }
            set { SetValue(ref this.numeroNucleos, value); }
        }

        public int? NumeroHilos
        {
            get { return this.numeroHilos; }
            set { SetValue(ref this.numeroHilos, value); }
        }

        public double? VelocidadMinima
        {
            get { return this.velocidadMinima; }
            set { SetValue(ref this.velocidadMinima, value); }
        }

        public double? VelocidadMaxima
        {
            get { return this.velocidadMaxima; }
            set { SetValue(ref this.velocidadMaxima, value); }
        }

        public int? Litografia
        {
            get { return this.litografia; }
            set { SetValue(ref this.litografia, value); }
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
            this.ID = procesadorActual.idRegistro;
            this.Modelo = procesadorActual.modelo;
            this.Marca = procesadorActual.marca;
            this.NumeroNucleos = procesadorActual.numeroNucleos;
            this.NumeroHilos = procesadorActual.numeroHilos;
            this.VelocidadMinima = procesadorActual.velocidadMinima;
            this.VelocidadMaxima = procesadorActual.velocidadMaxima;
            this.Litografia = procesadorActual.litografia;

            if (usuarioActual != null) { isBtnModificarEnabled = true; }
        }

        private void Modificar()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new FormularioProcesador(laptopActual, usuarioActual, procesadorActual);
            Application.Current.MainWindow.Show();

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
