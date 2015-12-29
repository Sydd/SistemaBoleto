using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Modelo
{
    public class Asiento
    {
        int _id;
        int _nroAsiento;

        /*PROPIEDADES___________________________________________________________*/
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int NroAsiento
        {
            get { return _nroAsiento; }
            set { _nroAsiento = value; }
        }
        /*CONTRUCTOR_____________________________________________________________*/

        public Asiento(){ }

        public Asiento(int p_Id, int p_Asiento) 
        {
            Id = p_Id;
            NroAsiento = p_Asiento;
        }


    }
}