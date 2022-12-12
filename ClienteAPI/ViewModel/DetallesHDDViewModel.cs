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
    public class DetallesHDDViewModel : BaseViewModel
    {

        #region CONSTRUCTOR

        public DetallesHDDViewModel(HDD hdd, Laptop laptop)
        {
            this.hddActual = hdd;
            this.laptopActual = laptop;
            ColocarDatos();
        }

        public DetallesHDDViewModel(HDD hdd, Laptop laptop, Usuario usuario)
        {
            this.hddActual = hdd;
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR 

        #region ATTRIBUTES

        public HDD hddActual;
        public Usuario? usuarioActual;
        public Laptop laptopActual;
        private bool isBtnModificarEnabled = false;

        //General
        public string? idRegistro = "";
        public string? modelo = "";
        public string? marca = "";
        public int? capacidad = 0;
        public string? interfaz = "";
        public int? cache = 0;
        public int? revoluciones = 0;
        public string? tamaño = "";

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

        public int? Capacidad
        {
            get { return this.capacidad; }
            set { SetValue(ref this.capacidad, value); }
        }

        public string? Interfaz
        {
            get { return this.interfaz; }
            set { SetValue(ref this.interfaz, value); }
        }

        public int? Cache
        {
            get { return this.cache; }
            set { SetValue(ref this.cache, value); }
        }

        public int? Revoluciones
        {
            get { return this.revoluciones; }
            set { SetValue(ref this.revoluciones, value); }
        }

        public string? Tamaño
        {
            get { return this.tamaño; }
            set { SetValue(ref this.tamaño, value); }
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
            this.ID = hddActual.idRegistro;
            this.Modelo = hddActual.modelo;
            this.Marca = hddActual.marca;
            this.Capacidad = hddActual.capacidad;
            this.Interfaz = hddActual.interfaz;
            this.Cache = hddActual.cache;
            this.Revoluciones = hddActual.revoluciones;
            this.Tamaño = hddActual.tamanio;

            if (usuarioActual != null) { isBtnModificarEnabled = true; }
        }

        private void Modificar()
        {
            MessageBox.Show("Modificar HDD");
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
