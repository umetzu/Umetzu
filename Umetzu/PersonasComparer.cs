using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Umetzu
{
    class PersonasComparer : IEqualityComparer<Persona>
    {
        #region IEqualityComparer<Persona> Members

        public bool Equals(Persona x, Persona y)
        {
            if (x.Mensaje.Length > 6)
            {
                return false;
            }

            if (x.card == y.card)
            {
                if (x.cvv == y.cvv)
                {
                    if (x.expire == y.expire)
                    {
                        return true;
                    }
                    
                }
            }

            return false;
        }

        public int GetHashCode(Persona obj)
        {
            return obj.card.ToLower().GetHashCode();

        }

        #endregion
    }
}
