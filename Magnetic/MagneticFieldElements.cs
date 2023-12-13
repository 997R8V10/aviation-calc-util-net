using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.GeoTools.MagneticTools
{
    public class MagneticFieldElements
    {
        internal IntPtr ptr;

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr CreateMagneticFieldElements();

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void DisposeMagneticElements(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetX(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetX(IntPtr ptr, double newX);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetY(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetY(IntPtr ptr, double newY);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetZ(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetZ(IntPtr ptr, double newZ);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetH(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetH(IntPtr ptr, double newH);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetF(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetF(IntPtr ptr, double newF);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetDecl(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetDecl(IntPtr ptr, double newDecl);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MagneticFieldElementsGetIncl(IntPtr ptr);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void MagneticFieldElementsSetIncl(IntPtr ptr, double newIncl);

        internal MagneticFieldElements(IntPtr ptr)
        {
            this.ptr = ptr;
        }
        public MagneticFieldElements()
        {
            ptr = CreateMagneticFieldElements();
        }

        public double NorthComponent
        {
            get => MagneticFieldElementsGetX(ptr);
            set => MagneticFieldElementsSetX(ptr, value);
        }

        public double EastComponent
        {
            get => MagneticFieldElementsGetY(ptr);
            set => MagneticFieldElementsSetY(ptr, value);
        }

        public double DownComponent
        {
            get => MagneticFieldElementsGetZ(ptr);
            set => MagneticFieldElementsSetZ(ptr, value);
        }

        public double HorizontalIntensity
        {
            get => MagneticFieldElementsGetH(ptr);
            set => MagneticFieldElementsSetH(ptr, value);
        }

        public double TotalIntensity
        {
            get => MagneticFieldElementsGetF(ptr);
            set => MagneticFieldElementsSetF(ptr, value);
        }

        public double Declination
        {
            get => MagneticFieldElementsGetDecl(ptr);
            set => MagneticFieldElementsSetDecl(ptr, value);
        }

        public double Inclination
        {
            get => MagneticFieldElementsGetIncl(ptr);
            set => MagneticFieldElementsSetIncl(ptr, value);
        }

        ~MagneticFieldElements()
        {
            DisposeMagneticElements(ptr);
        }
        
    }
}