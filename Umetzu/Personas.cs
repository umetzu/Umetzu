using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Umetzu
{
    public class Personas : ObservableCollection<Persona>
    {
        public Personas()
        {

        }
        public Personas(List<Persona> list)
            : base(list)
        {

        }
        public Personas(IEnumerable<Persona> collection)
            : base(collection)
        {

        }
    }
}