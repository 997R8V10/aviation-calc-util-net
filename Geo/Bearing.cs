using System;
using System.Collections.Generic;
using System.Text;

namespace AviationCalcUtilNet.Geo
{
    public class Bearing
    {
        internal IntPtr ptr;

        internal Bearing(IntPtr ptr)
        {
            this.ptr = ptr;
        }
    }
}
