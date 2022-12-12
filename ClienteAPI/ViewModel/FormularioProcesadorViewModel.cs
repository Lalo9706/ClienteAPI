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
    public class FormularioProcesadorViewModel : BaseViewModel
    {
        #region CONSTRUCTOR

        public FormularioProcesadorViewModel(Laptop laptop, Usuario usuario)
        {
            this.UsuarioActual = usuario;
            this.LaptopActual = laptop;
            this.ID = LaptopActual.idRegistro;
            this.Titulo = "Registrar Procesador";
        }

        public FormularioProcesadorViewModel(Laptop laptop, Usuario usuario, Procesador procesador)
        {
            this.UsuarioActual = usuario;
            this.LaptopActual = laptop;
            this.ProcesadorEnEdicion = procesador;
            this.Titulo = "Actualizar Procesador";
            this.isEdicion = true;
            ColocarDatos();
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        //General
        public readonly APIRest apirest = new();

        public Laptop LaptopActual;
        public Usuario UsuarioActual;
        public Procesador? ProcesadorEnEdicion = null;
        public bool isEdicion = false;

        public string? titulo = "";

        //Procesador
        public string? idRegistro = "";
        public string? modelo = "";
        public string? marca = "";
        public int numeroNucleos = 0;
        public int numeroHilos = 0;
        public double velocidadMinima = 0;
        public double velocidadMaxima = 0;
        public int litografia = 0;

        #endregion ATRIBUTES

        #region PROPERTIES

        public string? Titulo
        {
            get { return this.titulo; }
            set { SetValue(ref this.titulo, value); }
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

        public int NumeroNucleos
        {
            get { return this.numeroNucleos; }
            set { SetValue(ref this.numeroNucleos, value); }
        }

        public int NumeroHilos
        {
            get { return this.numeroHilos; }
            set { SetValue(ref this.numeroHilos, value); }
        }

        public double VelocidadMinima
        {
            get { return this.velocidadMinima; }
            set { SetValue(ref this.velocidadMinima, value); }
        }

        public double VelocidadMaxima
        {
            get { return this.velocidadMaxima; }
            set { SetValue(ref this.velocidadMaxima, value); }
        }

        public int Litografia
        {
            get { return this.litografia; }
            set { SetValue(ref this.litografia, value); }
        }

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ClickRegistrarProcesador
        {
            get { return new RelayCommand(RegistrarProcesadorAsync); }
            set { }
        }

        public ICommand ClickCancelar
        {
            get { return new RelayCommand(Cerrar); }
            set { }
        }

        #endregion COMMANDS

        #region METHODS

        private void ColocarDatos()
        {
            if(ProcesadorEnEdicion != null)
            {
                ID = this.ProcesadorEnEdicion.idRegistro;
                Modelo = this.ProcesadorEnEdicion.modelo;
                Marca = this.ProcesadorEnEdicion.marca;
                NumeroNucleos = this.ProcesadorEnEdicion.numeroNucleos;
                NumeroHilos = this.ProcesadorEnEdicion.numeroHilos;
                VelocidadMinima = this.ProcesadorEnEdicion.velocidadMinima;
                VelocidadMaxima = this.ProcesadorEnEdicion.velocidadMaxima;
                Litografia = this.ProcesadorEnEdicion.litografia;
            } 
            
        }

        private async void RegistrarProcesadorAsync()
        {
            if (!this.ID.Equals("") &&
                !this.Modelo.Equals("") &&
                !this.Marca.Equals("") &&
                !this.NumeroNucleos.Equals(0) &&
                !this.NumeroHilos.Equals(0) &&
                !this.VelocidadMinima.Equals(0) &&
                !this.VelocidadMaxima.Equals(0) &&
                !this.Litografia.Equals(0))
            {
                Procesador procesador = new Procesador();
                procesador.idRegistro = ID;
                procesador.modelo = Modelo;
                procesador.marca = Marca;
                procesador.numeroNucleos = NumeroNucleos;
                procesador.numeroHilos = NumeroHilos;
                procesador.velocidadMinima = VelocidadMinima;
                procesador.velocidadMaxima = VelocidadMaxima;
                procesador.litografia = Litografia;

                if (isEdicion == true)
                {
                    
                    string responsePut = await apirest.PutProcesador(procesador);
                    if (responsePut != "500")
                    {
                        MessageBox.Show("Procesador Actualizado con Exito", "Aviso");
                        Cerrar();
                    }
                    else { MessageBox.Show("No se actualizó el procesador", "Aviso"); }
                }
                else
                {
                    string responsePost = await apirest.PostProcesador(procesador);
                    if (responsePost != "500")
                    {
                        MessageBox.Show("Procesador Registrado con Exito", "Aviso");
                        Cerrar();
                    }
                    else { MessageBox.Show("No se registró el procesador", "Aviso"); }
                }

                
            }
            else { MessageBox.Show("Hay campos vacios", "Alerta"); }
        }

        private void Cerrar()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new DetallesLaptop(LaptopActual, UsuarioActual);
            Application.Current.MainWindow.Show();
        }

        #endregion METHODS





    }
}
