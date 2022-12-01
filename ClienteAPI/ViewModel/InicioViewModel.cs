using ClienteAPI.Model.POCO;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ClienteAPI.ViewModel
{
    public class InicioViewModel : BaseViewModel
    {

        public InicioViewModel()
        {
            InicializarDatos();
        }

        private void InicializarDatos()
        {
            
            ListaLaptops = new ObservableCollection<Laptop>();
            ListaLaptops.Add(new Laptop() { ID = 2300, Modelo = "HP Pavilion Y21H", CPU = "Ryzen 7", GPU = "RADEON GRAPHICS 7", RAM = "16 GB DDR4", Almacenamiento = "500 GB SSD" });
        }

        #region ATTRIBUTES

        private Laptop laptopSeleccionada;
        private ObservableCollection<Laptop> listaLaptops;

        public int id;
        public string modelo;
        public string cpu;
        public string gpu;
        public string ram;
        public string almacenamiento;

        public string txtBuscar;
        public int busquedaID;
        public string busquedaModelo;


        #endregion

        #region PROPERTIES

        //Busqueda

        public string TxtBuscar
        {
            get { return this.txtBuscar; }
            set { SetValue(ref this.txtBuscar, value); }
        }

        //Colección de Laptops

        public ObservableCollection<Laptop> ListaLaptops
        {
            get { return this.listaLaptops; }
            set { SetValue(ref this.listaLaptops, value); }
        }

        // Laptop (Seleccionada)


        public Laptop LaptopSeleccionada
        {
            get { return this.laptopSeleccionada; }
            set { SetValue(ref this.laptopSeleccionada, value); }
        }

        //Información de la Laptop

        public int ID
        {
            get { return this.id; }
            set { SetValue(ref this.id, value); }
        }

        public string Modelo
        {
            get { return this.modelo; }
            set { SetValue(ref this.modelo, value); }
        }

        public string CPU
        {
            get { return this.cpu; }
            set { SetValue(ref this.cpu, value); }
        }

        public string GPU
        {
            get { return this.gpu; }
            set { SetValue(ref this.gpu, value); }
        }

        public string RAM
        {
            get { return this.ram; }
            set { SetValue(ref this.ram, value); }
        }

        public string Almacenamiento
        {
            get { return this.almacenamiento; }
            set { SetValue(ref this.almacenamiento, value); }
        }

        #endregion

        #region COMMANDS

        public ICommand ClickBuscar
        {
            get { return new RelayCommand(Buscar); }
            set { }
        }

        public ICommand ClickRegistrarLaptop
        {
            get { return new RelayCommand(RegistrarLaptop); }
            set { }
        }

        public ICommand ClickVerDetalles
        {
            get { return new RelayCommand(VerDetalles); }
            set { }
        }

        public ICommand ClickIniciarSesion
        {
            get { return new RelayCommand(IniciarSesion); }
            set { }
        }

        public ICommand ClickRegistrarse
        {
            get { return new RelayCommand(Registrarse); }
            set { }
        }

        #endregion

        #region METHODS
        private void Buscar()
        {
            MessageBox.Show("Botón Buscar Presionado");
        }

        private void RegistrarLaptop()
        {
            MessageBox.Show("Botón Registrar Laptop Presionado");
        }

        private void VerDetalles()
        {
            MessageBox.Show("Botón Ver Detalles Presionado");
        }

        private void IniciarSesion()
        {
            MessageBox.Show("Botón Iniciar Sesión Presionado");
        }

        private void Registrarse()
        {
            MessageBox.Show("Botón Registrarse Presionado");
        }

        #endregion

    }
}
