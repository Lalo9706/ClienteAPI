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
using System.Windows.Data;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace ClienteAPI.ViewModel
{
    public class InicioUsuarioViewModel : BaseViewModel
    {

        #region CONSTRUCTOR
        public InicioUsuarioViewModel()
        {
            ObtenerLaptopsAsync();
        }

        public InicioUsuarioViewModel(Usuario? usuario)
        {
            ObtenerLaptopsAsync();
            this.usuarioActual = usuario;
            this.NombreUsuario = usuarioActual?.NombreUsuario;
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        //API
        public APIRest apirest = new();

        //Busqueda
        public string txtBuscar = "";
        public Boolean checkboxBuscarPorID = false;

        //Usuario
        public Usuario? usuarioActual = null;
        public string? nombreUsuario = "";

        //Laptop
        private Laptop? laptopSeleccionada = null;
        private ObservableCollection<Laptop> listaLaptops = new ObservableCollection<Laptop>();

        //Información Laptop
        public string? idRegistro = "";
        public string? modelo = "";
        public string? memoriaRam = "";
        public string? tarjetaVideo = "";
        public string? almacenamiento = "";
        public string? procesador = "";
        public string? pantalla = "";

        #endregion ATTRIBUTES

        #region PROPERTIES

        #region General

        //Inicio de Sesión Usuario
        public string? NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { SetValue(ref this.nombreUsuario, value); }
        }

        public Usuario? UsuarioActual
        {
            get { return this.usuarioActual; }
            set { SetValue(ref this.usuarioActual, value); }
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

        // Laptop Seleccionada del DataGrid
        public Laptop? LaptopSeleccionada
        {
            get { return this.laptopSeleccionada; }
            set
            {
                SetValue(ref this.laptopSeleccionada, value);
                MostrarInformacionEvent();
            }
        }

        #endregion General

        #region Información Laptop

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

        public string? CPU
        {
            get { return this.procesador; }
            set { SetValue(ref this.procesador, value); }
        }

        public string? GPU
        {
            get { return this.tarjetaVideo; }
            set { SetValue(ref this.tarjetaVideo, value); }
        }

        public string? RAM
        {
            get { return this.memoriaRam; }
            set { SetValue(ref this.memoriaRam, value); }
        }

        public string? Almacenamiento
        {
            get { return this.almacenamiento; }
            set { SetValue(ref this.almacenamiento, value); }
        }

        public string? Pantalla
        {
            get { return this.pantalla; }
            set { SetValue(ref this.pantalla, value); }
        }

        #endregion Información Laptop

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

        #region Eventos

        private void MostrarInformacionEvent()
        {
            if(LaptopSeleccionada != null)
            {
                ID = LaptopSeleccionada.IdRegistro;
                Modelo = LaptopSeleccionada.Modelo;
                CPU = LaptopSeleccionada.Procesador;
                GPU = LaptopSeleccionada.TarjetaVideo;
                RAM = LaptopSeleccionada.MemoriaRam;
                Almacenamiento = LaptopSeleccionada.Almacenamiento;
                Pantalla = LaptopSeleccionada.Pantalla;
            }      
        }

        #endregion

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
                if (this.CheckBoxBuscarPorID == true)
                {
                    _ = ObtenerLaptopPorIDAsync(this.TxtBuscar);
                }
                else
                {
                    _ = ObtenerLaptopPorModeloAsync(this.TxtBuscar);
                }
            }
            else
            {
                MessageBox.Show("Especifica primero la busqueda");
            }
        }

        private void RegistrarLaptop()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new RegistrarLaptop();
            Application.Current.MainWindow.Show();
        }

        private void VerDetalles()
        {
            if(LaptopSeleccionada != null)
            {
                Application.Current.MainWindow.Hide();
                Application.Current.MainWindow = new DetallesLaptop(LaptopSeleccionada, usuarioActual);
                Application.Current.MainWindow.Show();
            }
            else { MessageBox.Show("Primero Selecciona una Laptop de la lista", "Aviso"); }
            
        }

        private void IniciarSesion()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new IniciarSesion();
            Application.Current.MainWindow.Show();
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
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new Inicio();
            Application.Current.MainWindow.Show();
        }

        #endregion

        #region DatosIniciales

        private async void ObtenerLaptopsAsync()
        {
            ListaLaptops = new ObservableCollection<Laptop>();

            List<Laptop>? laptops = await apirest.GetLaptops();
            if (laptops != null)
            {
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
            Laptop? laptop = await apirest.GetLaptopPorID(busqueda);
            if(laptop != null)
            {
                ListaLaptops.Clear();
                ListaLaptops.Add(laptop);
            }
            else
            {
                MessageBox.Show("No se encontró el ID de la laptop", "Aviso");
            }
        }

        private async Task ObtenerLaptopPorModeloAsync(string busqueda)
        {
            List<Laptop>? laptops = await apirest.GetLaptopPorModelo(busqueda);
            if (laptops != null)
            {
                ListaLaptops.Clear();
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

        #endregion METHODS

    }
}
