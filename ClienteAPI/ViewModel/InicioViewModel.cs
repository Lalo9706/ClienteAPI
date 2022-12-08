﻿using ClienteAPI.Model.API;
using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
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
            ObtenerLaptopsAsync();
        }


        #region ATTRIBUTES

        private Laptop laptopSeleccionada = new Laptop();
        private ObservableCollection<Laptop> listaLaptops = new ObservableCollection<Laptop>();

        public string idRegistro = "";
        public string modelo = "";
        public string procesador = "";
        public string tarjetaVideo = "";
        public string memoriaRam = "";
        public string almacenamiento = "";
        public string pantalla = "";

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

        private List<Laptop> DeserializarLaptops(string response)
        {
            List<Laptop> laptops = JsonConvert.DeserializeObject<List<Laptop>>(response);
            return laptops;
        }

        #endregion

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

        #endregion

        #region Logica
        private void ObtenerLaptopPorID(int busquedaID)
        {
            MessageBox.Show("Metódo Buscar Laptop por ID: "+busquedaID);
        }

        private void ObtenerLaptopPorModelo(string busquedaModelo)
        {
            MessageBox.Show("Metódo Buscar Laptop por Modelo: " + busquedaModelo);
        }

        #endregion

        #endregion

    }
}
