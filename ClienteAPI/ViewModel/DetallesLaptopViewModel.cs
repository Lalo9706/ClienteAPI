﻿using ClienteAPI.Model.API;
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
    public class DetallesLaptopViewModel : BaseViewModel
    {

        #region CONSTRUCTOR

        public DetallesLaptopViewModel(Laptop laptop)
        {
            this.laptopActual = laptop;
            InicializarDatos();
        }

        public DetallesLaptopViewModel(Laptop laptop, Usuario usuario)
        {
            this.laptopActual = laptop;
            this.usuarioActual = usuario;
            InicializarDatos();
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        //CONSTANTES
        private readonly APIRest apirest = new();
        private static readonly int ADMINISTRADOR = 1;

        private bool isBtnModificarEnabled = false;
        private bool isBtnEliminarEnabled = false;

        private readonly Laptop laptopActual = new();
        private readonly Usuario? usuarioActual = null;

        private string? id = "";
        private string? modelo = "";
        private string? procesador = "";
        private string? memoriaRam = "";
        private string? almacenamiento = "";
        private string? tarjetaVideo = "";
        private string? pantalla = "";

        #endregion ATTRIBUTES

        #region PROPERTIES

        #region General
        public bool IsBtnModificarEnabled
        {
            get { return this.isBtnModificarEnabled; }
            set { SetValue(ref this.isBtnModificarEnabled, value); }
        }

        public bool IsBtnEliminarEnabled
        {
            get { return this.isBtnEliminarEnabled; }
            set { SetValue(ref this.isBtnEliminarEnabled, value); }
        }

        #endregion General

        #region Información Laptop

        public string? ID
        {
            get { return this.id; }
            set { SetValue(ref this.id, value); }
        }

        public string? Modelo
        {
            get { return this.modelo; }
            set { SetValue(ref this.modelo, value); }
        }

        public string? Procesador
        {
            get { return this.procesador; }
            set { SetValue(ref this.procesador, value); }
        }

        public string? MemoriaRam
        {
            get { return this.memoriaRam; }
            set { SetValue(ref this.memoriaRam, value); }
        }

        public string? Almacenamiento
        {
            get { return this.almacenamiento; }
            set { SetValue(ref this.almacenamiento, value); }
        }

        public string? TarjetaVideo
        {
            get { return this.tarjetaVideo; }
            set { SetValue(ref this.tarjetaVideo, value); }
        }

        public string? Pantalla
        {
            get { return this.pantalla; }
            set { SetValue(ref this.pantalla, value); }
        }

        #endregion Información Laptop

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ClickProcesador
        {
            get { return new RelayCommand(VerProcesadorAsync); }
            set { }
        }

        public ICommand ClickMemoriaRam
        {
            get { return new RelayCommand(VerMemoriaRamAsync); }
            set { }
        }

        public ICommand ClickAlmacenamiento
        {
            get { return new RelayCommand(VerAlmacenamiento); }
            set { }
        }

        public ICommand ClickTarjetaVideo
        {
            get { return new RelayCommand(VerTarjetaVideo); }
            set { }
        }

        public ICommand ClickPantalla
        {
            get { return new RelayCommand(VerPantalla); }
            set { }
        }

        public ICommand ClickModificar
        {
            get { return new RelayCommand(Modificar); }
            set { }
        }

        public ICommand ClickEliminar
        {
            get { return new RelayCommand(Eliminar); }
            set { }
        }

        public ICommand ClickCerrar
        {
            get { return new RelayCommand(Cerrar); }
            set { }
        }

        #endregion COMMANDS

        #region METHODS

        //InicializarDatos
        private void InicializarDatos()
        {
            ID = laptopActual.idRegistro;
            Modelo = laptopActual.modelo;
            Procesador = laptopActual.procesador;
            MemoriaRam = laptopActual.memoriaRam;
            Almacenamiento = laptopActual.almacenamiento;
            TarjetaVideo = laptopActual.tarjetaVideo;
            Pantalla = laptopActual.pantalla;

            if(usuarioActual != null) 
            { 
                isBtnModificarEnabled = true;
                if (usuarioActual.administrador == ADMINISTRADOR) { isBtnEliminarEnabled = true; }
            }  
        }

        public async void VerProcesadorAsync()
        {
            Procesador? procesador = new() ;
            if (laptopActual.idRegistro != null) { procesador = await apirest.GetProcesador(laptopActual.idRegistro); }
            if (procesador != null)
            {
                Application.Current.MainWindow.Hide();
                if (usuarioActual != null)
                {                   
                    Application.Current.MainWindow = new DetallesProcesador(procesador, laptopActual, usuarioActual);
                }
                else
                {
                    Application.Current.MainWindow = new DetallesProcesador(procesador, laptopActual);
                }
                Application.Current.MainWindow.Show();
            }
            else
            {
                if (usuarioActual != null)
                {
                    MessageBoxResult respuesta =
                    MessageBox.Show("No se encontró el procesador ¿Desea registrarlo?", "Aviso", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        Application.Current.MainWindow.Hide();
                        Application.Current.MainWindow = new FormularioProcesador(laptopActual, usuarioActual);
                        Application.Current.MainWindow.Show();
                    }
                }
                else { MessageBox.Show("No se encontró el procesador\nInicie sesión para poder registrarlo", "Aviso"); }

            }
        }

        public async void VerMemoriaRamAsync()
        {
            MemoriaRam? memoriaRam = new();
            if (laptopActual.idRegistro != null) { memoriaRam = await apirest.GetMemoriaRam(laptopActual.idRegistro); }
            if (memoriaRam != null)
            {
                Application.Current.MainWindow.Hide();
                if (usuarioActual != null)
                {
                    Application.Current.MainWindow = new DetallesRAM(memoriaRam, laptopActual, usuarioActual);
                }
                else
                {
                    Application.Current.MainWindow = new DetallesRAM(memoriaRam, laptopActual);
                }
                Application.Current.MainWindow.Show();
            }
            else
            {
                if (usuarioActual != null)
                {
                    MessageBoxResult respuesta =
                    MessageBox.Show("No se encontró la memoria RAM ¿Desea registrarla?", "Aviso", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        Application.Current.MainWindow.Hide();
                        Application.Current.MainWindow = new FormularioProcesador(laptopActual, usuarioActual);
                        Application.Current.MainWindow.Show();
                    }
                }
                else { MessageBox.Show("No se encontró la RAM\nInicie sesión para poder registrarla", "Aviso"); }

            }
        }

        public async void VerAlmacenamiento()
        {
            Almacenamiento? almacenamiento = new();
            if (laptopActual.idRegistro != null) { almacenamiento = await apirest.GetAlmacenamiento(laptopActual.idRegistro); }
            if (almacenamiento != null)
            {
                Application.Current.MainWindow.Hide();
                if (almacenamiento.tipoAlmacenamiento == "HDD")
                {
                    HDD? hdd = await apirest.GetHDD(laptopActual.idRegistro);
                    if (usuarioActual != null)
                    {
                        Application.Current.MainWindow = new DetallesHDD(hdd, laptopActual, usuarioActual);
                    }
                    else
                    {
                        Application.Current.MainWindow = new DetallesHDD(hdd, laptopActual);
                    }
                }
                else
                {
                    SSD? ssd = await apirest.GetSSD(laptopActual.idRegistro);
                    if (usuarioActual != null)
                    {
                        Application.Current.MainWindow = new DetallesSSD(ssd, laptopActual, usuarioActual);
                    }
                    else
                    {
                        Application.Current.MainWindow = new DetallesSSD(ssd, laptopActual);
                    }
                }                
                
                Application.Current.MainWindow.Show();
            }
            else
            {
                if (usuarioActual != null)
                {
                    MessageBoxResult respuesta =
                    MessageBox.Show("No se encontró la memoria RAM ¿Desea registrarla?", "Aviso", MessageBoxButton.YesNo);
                    if (respuesta == MessageBoxResult.Yes)
                    {
                        Application.Current.MainWindow.Hide();
                        Application.Current.MainWindow = new FormularioProcesador(laptopActual, usuarioActual);
                        Application.Current.MainWindow.Show();
                    }
                }
                else { MessageBox.Show("No se encontró la RAM\nInicie sesión para poder registrarla", "Aviso"); }

            }
        }

        public static void VerTarjetaVideo()
        {
            MessageBox.Show("Ver GPU", "Aviso");
        }

        public static void VerPantalla()
        {
            MessageBox.Show("Ver Pantalla", "Aviso");
        }

        public static void Modificar()
        {
            MessageBox.Show("Modificar Laptop", "Aviso");
        }

        public static void Eliminar()
        {
            MessageBox.Show("Eliminar Laptop", "Aviso");
        }

        public void Cerrar()
        {
            Application.Current.MainWindow.Hide();
            if(usuarioActual != null)
            {
                Application.Current.MainWindow = new InicioUsuario(usuarioActual);
            }
            else
            {
                Application.Current.MainWindow = new Inicio();
            }
            Application.Current.MainWindow.Show();
        }


        #endregion METHODS
    }
}
