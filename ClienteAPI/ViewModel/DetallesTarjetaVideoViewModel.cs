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
    public class DetallesTarjetaVideoViewModel : BaseViewModel
    {

        #region CONSTRUCTOR

        public DetallesTarjetaVideoViewModel(TarjetaVideo tarjetaVideo, Laptop laptop)
        {
            this.tarjetaVideoActual = tarjetaVideo;
            this.laptopActual = laptop;
            ColocarDatos();
        }

        public DetallesTarjetaVideoViewModel(TarjetaVideo tarjetaVideo, Laptop laptop, Usuario usuario)
        {
            this.tarjetaVideoActual = tarjetaVideo;
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR 

        #region ATTRIBUTES

        public TarjetaVideo tarjetaVideoActual;
        public Usuario? usuarioActual;
        public Laptop laptopActual;
        private bool isBtnModificarEnabled = false;

        //General
        public string? idRegistro = "";
        public string? modelo = "";
        public string? marca = "";
        public int? cantidadVRAM = 0;
        public string? tipoMemoria = "";
        public int? bits = 0;
        public double? velocidadReloj = 0;
        public string? tipo = "";

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

        public int? CantidadVRAM
        {
            get { return this.cantidadVRAM; }
            set { SetValue(ref this.cantidadVRAM, value); }
        }

        public string? TipoMemoria
        {
            get { return this.tipoMemoria; }
            set { SetValue(ref this.tipoMemoria, value); }
        }

        public int? Bits
        {
            get { return this.bits; }
            set { SetValue(ref this.bits, value); }
        }

        public double? VelocidadReloj
        {
            get { return this.velocidadReloj; }
            set { SetValue(ref this.velocidadReloj, value); }
        }

        public string? Tipo
        {
            get { return this.tipo; }
            set { SetValue(ref this.tipo, value); }
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
            this.ID = tarjetaVideoActual.idRegistro;
            this.Modelo = tarjetaVideoActual.modelo;
            this.Marca = tarjetaVideoActual.marca;
            this.CantidadVRAM = tarjetaVideoActual.cantidadVram;
            this.TipoMemoria = tarjetaVideoActual.tipoMemoria;
            this.Bits = tarjetaVideoActual.bits;
            this.VelocidadReloj = tarjetaVideoActual.velocidadReloj;
            this.Tipo = tarjetaVideoActual.tipo;

            if (usuarioActual != null) { isBtnModificarEnabled = true; }
        }

        private void Modificar()
        {
            MessageBox.Show("Modificar Tarjeta Video");
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
