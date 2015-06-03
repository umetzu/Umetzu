using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Umetzu
{
    public class Persona : INotifyPropertyChanged
    {
        public int id { get; set; }
        public bool Estado { get; set; }
        public string ip { get; set; }
        public string amount { get; set; }
        public string expire { get; set; }
        public string cvv { get; set; }
        public string cardtype { get; set; }
        public string card { get; set; }
        public string app { get; set; }
        public string pass { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string country { get; set; }
        public string pCode { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string name { get; set; }
        public string pin { get; set; }
        public DateTime? fecha { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private string mensaje;
        public string Mensaje
        {
            get { return mensaje; }
            set
            {
                if (value != null && mensaje != value)
                {
                    mensaje = value;
                    OnPropertyChanged("Mensaje");
                }
            }
        }

        private string nivel;
        public string Nivel
        {
            get { return nivel; }
            set
            {
                if (value != null && nivel != value)
                {
                    nivel = value;
                    OnPropertyChanged("Nivel");
                }
            }
        }

        private string ccpais;
        public string CCPais
        {
            get { return ccpais; }
            set
            {
                if (value != null && ccpais != value)
                {
                    ccpais = value;
                    OnPropertyChanged("CCPais");
                }
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
