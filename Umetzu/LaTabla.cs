using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlTypes;

namespace Umetzu
{
    public class LaTabla
    {
        public LaTabla()
        {
            id = "";
            valor = "";
            mensaje = "";
            fecha = SqlDateTime.MinValue.Value;
            insertado = false;
        }
        public string id { get; set; }
        public string valor { get; set; }
        public string mensaje { get; set; }
        public DateTime fecha { get; set; }
        public bool insertado { get; set; }
    }
}
