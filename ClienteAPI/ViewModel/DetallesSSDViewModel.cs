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
    public class DetallesSSDViewModel : BaseViewModel
    {

        #region CONSTRUCTOR

        public DetallesSSDViewModel(SSD ssd, Laptop laptop)
        {
            this.ssdActual = ssd;
            this.laptopActual = laptop;
            ColocarDatos();
        }

        public DetallesSSDViewModel(SSD ssd, Laptop laptop, Usuario usuario)
        {
            this.ssdActual = ssd;
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR 

        #region ATTRIBUTES

        public SSD ssdActual;
        public Usuario? usuarioActual;
        public Laptop laptopActual;
        private bool isBtnModificarEnabled = false;

        //General
        public string? idRegistro = "";
        public string? modelo = "";
        public string? marca = "";
        public int? capacidad = 0;
        public string? factorForma = "";
        public string? durabilidad = "";
        public string? tipoMemorias = "";
        public string? generacionMemorias = "";
        public string? velocidadLectura = "";
        public string? velocidadEscritura = "";
        public string? protocolo = "";

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

        public string? FactorForma
        {
            get { return this.factorForma; }
            set { SetValue(ref this.factorForma, value); }
        }

        public string? Durabilidad
        {
            get { return this.durabilidad; }
            set { SetValue(ref this.durabilidad, value); }
        }

        public string? TipoMemorias
        {
            get { return this.tipoMemorias; }
            set { SetValue(ref this.tipoMemorias, value); }
        }

        public string? GeneracionMemorias
        {
            get { return this.generacionMemorias; }
            set { SetValue(ref this.generacionMemorias, value); }
        }

        public string? VelocidadLectura
        {
            get { return this.velocidadLectura; }
            set { SetValue(ref this.velocidadLectura, value); }
        }

        public string? VelocidadEscritura
        {
            get { return this.velocidadEscritura; }
            set { SetValue(ref this.velocidadEscritura, value); }
        }

        public string? Protocolo
        {
            get { return this.protocolo; }
            set { SetValue(ref this.protocolo, value); }
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
            this.ID = ssdActual.idRegistro;
            this.Modelo = ssdActual.modelo;
            this.Marca = ssdActual.marca;
            this.Capacidad = ssdActual.capacidad;
            this.FactorForma = ssdActual.factorForma;
            this.Durabilidad = ssdActual.durabilidad;
            this.TipoMemorias = ssdActual.tipoMemorias;
            this.GeneracionMemorias = ssdActual.generacionMemorias;
            this.VelocidadLectura = ssdActual.velocidadLectura;
            this.VelocidadEscritura = ssdActual.velocidadEscritura;
            this.Protocolo = ssdActual.protocolo;

            if (usuarioActual != null) { isBtnModificarEnabled = true; }
        }

        private void Modificar()
        {
            MessageBox.Show("Modificar SSD");
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
