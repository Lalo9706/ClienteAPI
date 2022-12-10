using ClienteAPI.Model.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteAPI.ViewModel
{
    public class DetallesLaptopViewModel : BaseViewModel
    {

        #region CONSTRUCTOR
        public DetallesLaptopViewModel(Laptop laptop)
        {
            this.laptopActual = laptop;
        }

        #endregion CONSTRUCTOR

        #region ATTRIBUTES

        public Laptop laptopActual = new Laptop();

        #endregion ATTRIBUTES


    }
}
