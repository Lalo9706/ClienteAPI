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
    public class DetallesRAMViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public DetallesRAMViewModel(MemoriaRam ram, Laptop laptop)
        {
            this.ramActual = ram;
            this.laptopActual = laptop;
            ColocarDatos();
        }

        public DetallesRAMViewModel(MemoriaRam ram, Laptop laptop, Usuario usuario)
        {
            this.ramActual = ram;
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        public MemoriaRam ramActual;
        public Usuario? usuarioActual;
        public Laptop laptopActual;
        private bool isBtnModificarEnabled = false;

        //General

        public string? idRegistro = "";
        public string? modelo = "";
        public string? marca = "";
        public string? tipoMemoria = "";
        public int? cantidadMemoria = 0;
        public int? cantidadMemorias = 0;
        public int? velocidad = 0;
        public int? ecc = 0;

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

        public string? TipoMemoria
        {
            get { return this.tipoMemoria; }
            set { SetValue(ref this.tipoMemoria, value); }
        }

        public int? CantidadMemoria
        {
            get { return this.cantidadMemoria; }
            set { SetValue(ref this.cantidadMemoria, value); }
        }

        public int? CantidadMemorias
        {
            get { return this.cantidadMemorias; }
            set { SetValue(ref this.cantidadMemorias, value); }
        }

        public int? Velocidad
        {
            get { return this.velocidad; }
            set { SetValue(ref this.velocidad, value); }
        }

        public int? ECC
        {
            get { return this.ecc; }
            set { SetValue(ref this.ecc, value); }
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
            this.ID = ramActual.idRegistro;
            this.Modelo = ramActual.modelo;
            this.Marca = ramActual.marca;
            this.TipoMemoria = ramActual.tipoMemoria;
            this.CantidadMemoria = ramActual.cantidadMemoria;
            this.CantidadMemorias = ramActual.cantidadMemorias;
            this.Velocidad = ramActual.velocidad;
            this.ECC = ramActual.ecc;

            if (usuarioActual != null) { isBtnModificarEnabled = true; }
        }

        private void Modificar()
        {
            MessageBox.Show("Modificando RAM", "Aviso");
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
