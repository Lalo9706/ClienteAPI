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
    public class RegistrarUsuarioViewModel : BaseViewModel
    {

        #region CONSTRUCTOR

        public RegistrarUsuarioViewModel() { }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        //General
        public readonly APIRest apirest = new();
        public string titulo = "Registrar Nuevo Usuario";
        //public Usuario? usuarioActual = null;

        //Datos Usuario
        public string nombreUsuario = "";
        public string nombre = "";
        public string apellido = "";
        public string correoElectronico = "";
        public string contraseña = "";
        public string contraseñaC = "";
        public int Administrador = 0;
        public Boolean isAdministrador = false;

        #endregion ATRIBUTES

        #region PROPERTIES

        public string Titulo
        {
            get { return this.titulo; }
            set { SetValue(ref this.titulo, value); }
        }

        public string NombreUsuario
        {
            get { return this.nombreUsuario; }
            set { SetValue(ref this.nombreUsuario, value); }
        }

        public string Nombre
        {
            get { return this.nombre; }
            set { SetValue(ref this.nombre, value); }
        }

        public string Apellido
        {
            get { return this.apellido; }
            set { SetValue(ref this.apellido, value); }
        }

        public string CorreoElectronico
        {
            get { return this.correoElectronico; }
            set { SetValue(ref this.correoElectronico, value); }
        }

        public string Contraseña
        {
            get { return this.contraseña; }
            set { SetValue(ref this.contraseña, value); }
        }

        public string ContraseñaC
        {
            get { return this.contraseñaC; }
            set { SetValue(ref this.contraseñaC, value); }
        }

        public Boolean IsAdministrador
        {
            get { return this.isAdministrador; }
            set 
            {
                SetValue(ref this.isAdministrador, value);
                if (isAdministrador == true) { Administrador = 1; } else { Administrador = 0; }
            }
        }

        #endregion PROPERTIES

        #region COMMANDS

        public ICommand ClickRegistrarUsuario
        {
            get { return new RelayCommand(RegistrarUsuarioAsync); }
            set { }
        }

        public ICommand ClickCancelar
        {
            get { return new RelayCommand(Cerrar); }
            set { }
        }

        #endregion COMMANDS

        #region METHODS

        private async void RegistrarUsuarioAsync()
        {
            if (!this.NombreUsuario.Equals("") &&
                !this.Nombre.Equals("") &&
                !this.Apellido.Equals("") &&
                !this.CorreoElectronico.Equals("") &&
                !this.Contraseña.Equals("") &&
                !this.ContraseñaC.Equals(""))
            {
                if(this.Contraseña == this.ContraseñaC)
                {
                    Usuario usuario = new();
                    usuario.nombreUsuario = this.NombreUsuario;
                    usuario.nombre = this.Nombre;
                    usuario.apellido = this.Apellido;
                    usuario.correoElectronico = this.CorreoElectronico;
                    usuario.contrasena = this.Contraseña;
                    usuario.administrador = this.Administrador;

                    string response = await apirest.PostUsuario(usuario);
                    if (response != "500")
                    {
                        MessageBox.Show("Usuario Registrado con Exito", "Aviso");
                        Cerrar();
                    }
                    else { MessageBox.Show("No se registró el usuario", "Error: HTTP 500"); }
                }
                else { MessageBox.Show("Las contraseñas No coinciden", "Alerta"); }
            }
            else { MessageBox.Show("Hay campos vacios", "Alerta"); }
        }

        private void Cerrar()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new Inicio();
            Application.Current.MainWindow.Show();
        }

        #endregion METHODS
    }
}
