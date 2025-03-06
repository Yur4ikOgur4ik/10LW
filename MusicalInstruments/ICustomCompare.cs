using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInstruments
{
    public interface ICustomComparer: IInit, IComparable<ICustomComparer>
    {
        public int CompareTo(ICustomComparer other);
    }
}
