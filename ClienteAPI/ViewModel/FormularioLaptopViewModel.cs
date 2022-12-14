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
    public class FormularioLaptopViewModel : BaseViewModel
    {
        #region CONSTRUCTOR
        public FormularioLaptopViewModel(Usuario usuario)
        {
            this.usuarioActual = usuario;
        }

        public FormularioLaptopViewModel(Usuario usuario, Laptop laptop)
        {
            this.usuarioActual = usuario;
            this.laptopEnEdicion = laptop;
        }

        #endregion

        #region ATTRIBUTES

        //API
        public APIRest apirest = new APIRest();

        //Edición
        public Laptop? laptopEnEdicion = null;

        //Datos de la laptop
        public string modelo = "";
        public string procesador = "";
        public string tarjetaVideo = "";
        public string memoriaRam = "";
        public string almacenamiento = "";
        public string pantalla = "";
        public bool isSSD = false;
        public string tipoAlmacenamiento = "HDD";

        //Sesion
        public Usuario usuarioActual = new();

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

        public bool IsSSD
        {
            get { return this.isSSD; }
            set { SetValue(ref this.isSSD, value); }
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
            get { return new RelayCommand(Cerrar); }
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
                    RegistrarComponentes(response);
                    Cerrar();
                }
                else { MessageBox.Show("No se registró la laptop", "Aviso"); }
            }
            else { MessageBox.Show("Hay campos vacios", "Alerta"); }
        }

        private void RegistrarComponentes(string idRegistroLaptop)
        {

            Procesador procesador = new Procesador();
            procesador.idRegistro = idRegistroLaptop;
            procesador.modelo = this.Procesador;
            procesador.marca = "";
            procesador.numeroNucleos = 0;
            procesador.numeroHilos = 0;
            procesador.velocidadMaxima = 0;
            procesador.velocidadMinima = 0;
            procesador.litografia = 0;
            _ = apirest.PostProcesador(procesador);

            MemoriaRam memoriaRam = new MemoriaRam();
            memoriaRam.idRegistro = idRegistroLaptop;
            memoriaRam.modelo = this.MemoriaRam;
            memoriaRam.marca = "";
            memoriaRam.cantidadMemoria = 0;
            memoriaRam.cantidadMemorias = 0;
            memoriaRam.tipoMemoria = "";
            memoriaRam.velocidad = 0;
            memoriaRam.ecc = 0;
            _ = apirest.PostMemoriaRam(memoriaRam);


            if(isSSD == true)
            {
                Almacenamiento almacenamiento = new Almacenamiento();
                almacenamiento.idRegistro = idRegistroLaptop;
                almacenamiento.tipoAlmacenamiento = "SSD";
                _ = apirest.PostAlmacenamiento(almacenamiento);
            }
            else
            {
                Almacenamiento almacenamiento = new Almacenamiento();
                almacenamiento.idRegistro = idRegistroLaptop;
                almacenamiento.tipoAlmacenamiento = "HDD";
                _ = apirest.PostAlmacenamiento(almacenamiento);
            }

            TarjetaVideo tarjetaVideo = new TarjetaVideo();
            tarjetaVideo.idRegistro = idRegistroLaptop;
            tarjetaVideo.modelo = this.TarjetaVideo;
            tarjetaVideo.marca = "";
            tarjetaVideo.cantidadVram = 0;
            tarjetaVideo.tipoMemoria = "";
            tarjetaVideo.velocidadReloj = 0;
            tarjetaVideo.bits = 0;
            tarjetaVideo.tipo = "";
            _ = apirest.PostTarjetaVideo(tarjetaVideo);

            Pantalla pantalla = new Pantalla();
            pantalla.idRegistro = idRegistroLaptop;
            pantalla.tipoPantalla = this.Pantalla;
            pantalla.calidad = "";
            pantalla.modelo = "";
            pantalla.tamanio = "";
            pantalla.frecuenciaRefresco = 0;
            pantalla.resolucion = "";
            _ = apirest.PostPantalla(pantalla);

            if (isSSD == true)
            {
                tipoAlmacenamiento = "SSD";
                SSD ssd = new SSD();
                ssd.idRegistro = idRegistroLaptop;
                ssd.modelo = this.Almacenamiento;
                ssd.marca = "";
                ssd.capacidad = 0;
                ssd.velocidadLectura = "";
                ssd.durabilidad = "";
                ssd.velocidadEscritura = "";
                ssd.protocolo = "";
                ssd.factorForma = "";
                ssd.generacionMemorias = "";
                ssd.tipoMemorias = "";
                _ = apirest.PostSSD(ssd);
            }
            else
            {
                tipoAlmacenamiento = "HDD";
                HDD hdd = new HDD();
                hdd.idRegistro = idRegistroLaptop;
                hdd.modelo = this.Almacenamiento;
                hdd.marca = "";
                hdd.capacidad = 0;
                hdd.cache = 0;
                hdd.tamanio = "";
                hdd.interfaz = "";
                hdd.revoluciones = 0;
                _ = apirest.PostHDD(hdd);
            }

        }

        private void Cerrar()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new InicioUsuario(usuarioActual);
            Application.Current.MainWindow.Show();
        }

        #endregion METHODS

    }
}
