using System;
using System.Collections.Generic;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    public class Latitude
    {
        internal IntPtr ptr;

        internal Latitude(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}
