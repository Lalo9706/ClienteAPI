using ClienteAPI.Model.API;
using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace ClienteAPI.ViewModel
{
    public class IniciarSesionViewModel : BaseViewModel
    {

        #region CONSTRUCTOR
        public IniciarSesionViewModel() { }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        public string correo = "h_david_mr@hotmail.com";
        public string contraseña = "HALOcea205";

        public APIRest apirest = new();

        #endregion

        #region PROPERTIES

        public string Correo
        {
            get { return this.correo; }
            set { SetValue(ref this.correo, value);  }
        }

        public string Contraseña
        {
            get { return this.contraseña; }
            set { SetValue(ref this.contraseña, value); }
        }

        #endregion

        #region COMMANDS

        public ICommand ClickIniciarSesion
        {
            get {  return new RelayCommand(IniciarSesion); }
            set { }
        }

        public ICommand ClickRegistrarse
        {
            get { return new RelayCommand(Registrarse); }
        }

        public ICommand ClickVolver
        {
            get { return new RelayCommand(Volver); }
        }

        #endregion

        #region METHODS

        private void IniciarSesion() { IniciarSesionAsync(); }

        private async void IniciarSesionAsync()
        {
            string _correo = this.Correo;
            string _contraseña = this.Contraseña;

            if(!_correo.Equals("") && !_contraseña.Equals(""))
            {
                
                Usuario? usuario = await apirest.GetUsuarioPorCorreo(_correo);

                if(usuario != null)
                {
                    if (_contraseña == usuario.contrasena)
                    {
                        MessageBox.Show("Inicio de Sesión Exitoso", "Aviso");
                        Application.Current.MainWindow.Hide();
                        Application.Current.MainWindow = new InicioUsuario(usuario);
                        Application.Current.MainWindow.Show();                        
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "Alerta");
                    }
                }
                else
                {
                    MessageBox.Show("No existe un usuario con ese correo electronico","Alerta");
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios", "Alerta");
            }
        }

        private void Registrarse()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new RegistrarUsuario();
            Application.Current.MainWindow.Show();
        }

        private void Volver()
        {
            Application.Current.MainWindow.Hide();
            Application.Current.MainWindow = new Inicio();
            Application.Current.MainWindow.Show();            
        }

        #endregion

    }
}
