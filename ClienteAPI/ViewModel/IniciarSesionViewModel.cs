using ClienteAPI.Model.API;
using ClienteAPI.Model.POCO;
using ClienteAPI.View;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public IniciarSesionViewModel()
        {

        }

        #region ATTRIBUTES

        public string correo = "";
        public string contraseña = "";
        

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

        private void IniciarSesion()
        {
            IniciarSesionAsync();
        }

        private async void IniciarSesionAsync()
        {
            string _correo = this.Correo;
            string _contraseña = this.Contraseña;

            if(!_correo.Equals("") && !_contraseña.Equals(""))
            {
                string respuesta = await APIRest.GetUsuarioPorCorreo(_correo);

                if(respuesta != "404")
                {
                    Usuario usuario = DeserializarUsuario(respuesta);


                    //Validación Usuario 1
                    if (_contraseña == usuario.contrasena)
                    {
                        MessageBox.Show("Inicio de Sesión Exitoso", "Aviso");
                        InicioUsuario inicioUsuario = new InicioUsuario();
                        Application.Current.MainWindow.Close();
                        System.Threading.Thread.Sleep(1000);
                        inicioUsuario.Show();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta", "Alerta");
                    }
                }
                else
                {
                    MessageBox.Show("No existe un usuario con es correo electronico","Alerta");
                }
            }
            else
            {
                MessageBox.Show("Hay campos vacios", "Alerta");
            }

                

        }

        public Usuario DeserializarUsuario(string respuesta)
        {
            Usuario user = JsonConvert.DeserializeObject<Usuario>(respuesta);
            return user;
        }



        

        private void Registrarse()
        {
            MessageBox.Show("Botón Registrarse Presionado");
        }

        private void Volver()
        {
            Inicio ventanaInicio = new();
            Application.Current.MainWindow.Close();
            ventanaInicio.Show();
        }


        #endregion

    }
}
