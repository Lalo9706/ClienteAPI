using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
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
            ListaLaptops.Add(new Laptop() { ID = 2400, Modelo = "LENOVO ThinkPad F720", CPU = "Intel Core i8", GPU = "GEFORCE GTX 14221", RAM = "16 GB DDR4", Almacenamiento = "1000 GB SSD" });
            ListaLaptops.Add(new Laptop() { ID = 2444, Modelo = "Acer GTurbo 10", CPU = "Intel Core i7", GPU ="GEFORCE GTX 14050", RAM = "18 GB DDR4", Almacenamiento = "500 GB SSD" });
        }


        #region ATTRIBUTES

        private Laptop laptopSeleccionada = new Laptop();
        private ObservableCollection<Laptop> listaLaptops = new ObservableCollection<Laptop>();

        public int id = 0;
        public string modelo = "";
        public string cpu = "";
        public string gpu = "";
        public string ram = "";
        public string almacenamiento = "";

        public string txtBuscar = "";

        //Variables
        bool isNumber = false;
        public int busquedaID = 0;
        public string busquedaModelo = "";

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


        #region Botones
        private void Buscar()
        {
            if(TxtBuscar != "")
            {
                isNumber = int.TryParse(this.TxtBuscar, out busquedaID);
                if (isNumber == true)
                {
                    ObtenerLaptopPorID(busquedaID);
                }
                else
                {
                    busquedaModelo = TxtBuscar;
                    ObtenerLaptopPorModelo(busquedaModelo);
                }
            }
            else
            {
                MessageBox.Show("Especifica primero la busqueda");
            }

            
        }

        private void RegistrarLaptop()
        {
            MessageBox.Show("Botón Registrar Laptop Presionado");
        }

        private void VerDetalles()
        {
            if(LaptopSeleccionada == null)
            {
                MessageBox.Show("Primero selecciona una laptop de la lista");
            }
            else
            {
                ID = LaptopSeleccionada.ID;
                Modelo = LaptopSeleccionada.Modelo;
                CPU = LaptopSeleccionada.CPU;
                GPU = LaptopSeleccionada.GPU;
                RAM = LaptopSeleccionada.RAM;
                Almacenamiento = LaptopSeleccionada.Almacenamiento;
            }
        }

        private void IniciarSesion()
        {
            IniciarSesion ventanaIniciarSesión = new();
            Application.Current.MainWindow.Close();
            ventanaIniciarSesión.Show();
            

        }

        private void Registrarse()
        {
            MessageBox.Show("Botón Registrarse Presionado");
        }

        #endregion

        private void ObtenerLaptopPorID(int busquedaID)
        {
            MessageBox.Show("Metódo Buscar Laptop por ID: "+busquedaID);
        }

        private void ObtenerLaptopPorModelo(string busquedaModelo)
        {
            MessageBox.Show("Metódo Buscar Laptop por Modelo: " + busquedaModelo);
        }

        #endregion

    }
}
