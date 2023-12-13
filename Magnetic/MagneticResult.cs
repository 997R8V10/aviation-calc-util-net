using System;
using System.Runtime.InteropServices;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;

namespace AviationCalcUtilNet.Magnetic
{
    public class MagneticResult
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr CreateMagneticResult(IntPtr model, IntPtr point, InteropDateStruct dStruct);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern void DisposeMagneticResult(IntPtr ptr);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr MagneticResultGetMainFieldElements(IntPtr ptr);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr MagneticResultGetSecularFieldElements(IntPtr ptr);


        internal MagneticResult(IntPtr ptr)
        {
            this.ptr = ptr;
        }

        public MagneticResult(MagneticModel model, GeoPoint point, DateTime dateTime)
        {
            ptr = CreateMagneticResult(model.ptr, point.ptr, InteropUtil.ManagedDateToDateStruct(dateTime));
        }

        ~MagneticResult()
        {
            DisposeMagneticResult(ptr);
        }

        public MagneticFieldElements MainFieldElements
        {
            get
            {
                IntPtr intPtr = MagneticResultGetMainFieldElements(ptr);
                if (intPtr != IntPtr.Zero)
                {
                    return new MagneticFieldElements(intPtr);
                }
                return new MagneticFieldElements();
            }
        }
        public MagneticFieldElements SecularFieldElements
        {
            get
            {
                IntPtr intPtr = MagneticResultGetSecularFieldElements(ptr);
                if (intPtr != IntPtr.Zero)
                {
                    return new MagneticFieldElements(intPtr);
                }
                return new MagneticFieldElements();
            }
        }
    }
}