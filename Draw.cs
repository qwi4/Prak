using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prak
{
    public class Draw
    {
        public int GetPoint(Random rnd)
        {
            return rnd.Next(0, 10);
        }
    }
}
