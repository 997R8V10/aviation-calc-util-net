using System;
using System.Collections.Generic;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    public class Longitude
    {
        internal IntPtr ptr;

        internal Longitude(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}
