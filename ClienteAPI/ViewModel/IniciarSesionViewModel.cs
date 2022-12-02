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
            get { return new RelayCommand(IniciarSesion); }
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
            Boolean validacion1 = false;
            Boolean validacion2 = false;
            string _correo = this.Correo;
            string _contraseña = this.Contraseña;

            if(_correo != "")
            {
                validacion1 = true;
            }
            if(_contraseña != "")
            {
                validacion2 = true;
            }
            if(validacion1 && validacion2)
            {
                MessageBox.Show("Iniciando sesión");
            }
            else
            {
                MessageBox.Show("HAY CAMPOS VACIOS");
            }


            
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
