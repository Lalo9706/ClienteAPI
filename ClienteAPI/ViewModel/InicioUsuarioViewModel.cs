using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using ClienteAPI.Model.API;
using Newtonsoft.Json;

namespace ClienteAPI.ViewModel
{
    public class InicioUsuarioViewModel : BaseViewModel
    {

        #region CONSTRUCTOR
        public InicioUsuarioViewModel()
        {
            ObtenerLaptopsAsync();
        }

        public InicioUsuarioViewModel(Usuario usuario)
        {
            ObtenerLaptopsAsync();
            this.usuarioActual = usuario;
            this.NombreUsuario = usuarioActual.nombreUsuario;
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        public Usuario usuarioActual;
        public string nombreUsuario = "";

        private Laptop laptopSeleccionada = new Laptop();
        private ObservableCollection<Laptop> listaLaptops = new ObservableCollection<Laptop>();

        public string idRegistro = "";
        public string modelo = "";
        public string memoriaRam = "";
        public string tarjetaVideo = "";
        public string pantalla = "";
        public string almacenamiento = "";
        public string procesador = "";

        public string txtBuscar = "";
        public Boolean checkboxBuscarPorID = false;

        //Variables
        public string busqueda = "";

        #endregion ATTRIBUTES

        #region PROPERTIES

        //Usuario

        public string NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { SetValue(ref this.nombreUsuario, value); }
        }

        //Busqueda

        public string TxtBuscar
        {
            get { return this.txtBuscar; }
            set { SetValue(ref this.txtBuscar, value); }
        }

        public Boolean CheckBoxBuscarPorID
        {
            get { return this.checkboxBuscarPorID; }
            set { SetValue(ref this.checkboxBuscarPorID, value); }
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

        public string ID
        {
            get { return this.idRegistro; }
            set { SetValue(ref this.idRegistro, value); }
        }

        public string Modelo
        {
            get { return this.modelo; }
            set { SetValue(ref this.modelo, value); }
        }

        public string CPU
        {
            get { return this.procesador; }
            set { SetValue(ref this.procesador, value); }
        }

        public string GPU
        {
            get { return this.tarjetaVideo; }
            set { SetValue(ref this.tarjetaVideo, value); }
        }

        public string RAM
        {
            get { return this.memoriaRam; }
            set { SetValue(ref this.memoriaRam, value); }
        }

        public string Almacenamiento
        {
            get { return this.almacenamiento; }
            set { SetValue(ref this.almacenamiento, value); }
        }

        public string Pantalla
        {
            get { return this.pantalla; }
            set { SetValue(ref this.pantalla, value); }
        }

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ClickInicio
        {
            get { return new RelayCommand(Reiniciar); }
            set { }
        }

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

        public ICommand ClickVerPerfil
        {
            get { return new RelayCommand(VerPerfil); }
            set { }
        }

        public ICommand ClickCerrarSesion
        {
            get { return new RelayCommand(CerrarSesion); }
            set { }
        }

        #endregion COMMANDS

        #region METHODS

        #region Botones

        private void Reiniciar()
        {
            this.ListaLaptops.Clear();
            ObtenerLaptopsAsync();
        }

        private void Buscar()
        {
            if (TxtBuscar != "")
            {
                //isNumber = int.TryParse(this.TxtBuscar, out busquedaID);
                if (this.CheckBoxBuscarPorID == true)
                {
                    ObtenerLaptopPorIDAsync(this.TxtBuscar);
                }
                else
                {
                    ObtenerLaptopPorModeloAsync(this.TxtBuscar);
                }
            }
            else
            {
                MessageBox.Show("Especifica primero la busqueda");
            }

        }

        private void RegistrarLaptop()
        {
            MessageBox.Show("Ventana Registrar Laptop", "Aviso");
        }

        private void VerDetalles()
        {
            if (LaptopSeleccionada == null)
            {
                MessageBox.Show("Primero selecciona una laptop de la lista");
            }
            else
            {
                ID = LaptopSeleccionada.idRegistro;
                Modelo = LaptopSeleccionada.modelo;
                CPU = LaptopSeleccionada.procesador;
                GPU = LaptopSeleccionada.tarjetaVideo;
                RAM = LaptopSeleccionada.memoriaRam;
                Almacenamiento = LaptopSeleccionada.almacenamiento;
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

        private void VerPerfil()
        {
            MessageBox.Show("Botón Ver Perfil Presionado");
        }

        private void CerrarSesion()
        {
            Inicio inicio = new Inicio();
            Application.Current.MainWindow.Close();
            inicio.Show();
        }

        #endregion

        #region DatosIniciales

        private async void ObtenerLaptopsAsync()
        {
            ListaLaptops = new ObservableCollection<Laptop>();

            string response = await APIRest.GetLaptops();
            if (response != "404")
            {
                List<Laptop> laptops = (DeserializarLaptops(response));
                foreach (Laptop lap in laptops)
                {
                    ListaLaptops.Add(lap);
                }

            }
            else
            {
                MessageBox.Show("No se encontró el recurso", "Alerta");
            }
        }

        #endregion

        #region Logica

        private async Task ObtenerLaptopPorIDAsync(string busqueda)
        {
            string response = await APIRest.GetLaptopPorID(busqueda);
            if(response != "404")
            {
                Laptop laptop = DeserializarLaptop(response);
                this.ListaLaptops.Clear();
                this.ListaLaptops.Add(laptop);
            }
            else
            {
                MessageBox.Show("No se encontró el ID de la laptop", "Aviso");
            }


        }

        private async Task ObtenerLaptopPorModeloAsync(string busqueda)
        {
            string response = await APIRest.GetLaptopPorModelo(busqueda);
            if (response != "404")
            {
                List<Laptop> laptops = DeserializarLaptops(response);
                this.ListaLaptops.Clear();
                foreach (Laptop laptop in laptops)
                {
                    this.ListaLaptops.Add(laptop);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el Modelo de la laptop", "Aviso");
            }
        }

        #endregion

        #region Deserialización

        private List<Laptop> DeserializarLaptops(string response)
        {
            List<Laptop> laptops = JsonConvert.DeserializeObject<List<Laptop>>(response);
            return laptops;
        }

        private Laptop DeserializarLaptop(string response)
        {
            Laptop laptop = JsonConvert.DeserializeObject<Laptop>(response);
            return laptop;
        }

        #endregion

        #endregion METHODS


    }
}
