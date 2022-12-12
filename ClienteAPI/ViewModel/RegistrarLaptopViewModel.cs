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
    public class RegistrarLaptopViewModel : BaseViewModel
    {
        #region CONSTRUCTOR
        public RegistrarLaptopViewModel(Usuario usuario)
        {
            this.usuarioActual = usuario;
        }

        #endregion

        #region ATTRIBUTES

        //API
        public APIRest apirest = new APIRest();

        //Datos de la laptop
        public string modelo = "";
        public string procesador = "";
        public string tarjetaVideo = "";
        public string memoriaRam = "";
        public string almacenamiento = "";
        public string pantalla = "";

        //Sesion
        public Usuario? usuarioActual = new();

        #endregion ATTRIBUTES

        #region PROPERTIES

        public string Modelo
        {
            get { return this.modelo; }
            set { SetValue(ref this.modelo, value); }
        }

        public string Procesador
        {
            get { return this.procesador; }
            set { SetValue(ref this.procesador, value); }
        }

        public string TarjetaVideo
        {
            get { return this.tarjetaVideo; }
            set { SetValue(ref this.tarjetaVideo, value); }
        }

        public string MemoriaRam
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

        public ICommand ClickRegistrarLaptop
        {
            get { return new RelayCommand(RegistrarLaptopAsync); }
            set { }
        }

        public ICommand ClickCancelar
        {
            get { return new RelayCommand(Cancelar); }
            set { }
        }

        #endregion COMMANDS

        #region METHODS

        private async void RegistrarLaptopAsync()
        {
            if(!this.Modelo.Equals("") &&
                !this.Procesador.Equals("") &&
                !this.TarjetaVideo.Equals("") &&
                !this.MemoriaRam.Equals("") &&
                !this.Almacenamiento.Equals("") &&
                !this.Pantalla.Equals(""))
            {
                Laptop laptop = new();
                laptop.idRegistro = "r";
                laptop.modelo = this.Modelo;
                laptop.procesador = this.Procesador;
                laptop.tarjetaVideo = this.TarjetaVideo;
                laptop.memoriaRam = this.MemoriaRam;
                laptop.almacenamiento = this.Almacenamiento;
                laptop.pantalla = this.Pantalla;

                string response = await apirest.PostLaptop(laptop);
                if(response != "500")
                {
                    MessageBox.Show("Laptop Registrada con Exito", "Aviso");
                }
                else
                {
                    MessageBox.Show("No se registró la laptop", "Aviso");
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios", "Alerta");
            }
        }

        private void Cancelar()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new InicioUsuario(usuarioActual);
            Application.Current.MainWindow.Show();
        }

        #endregion METHODSa

    }
}
