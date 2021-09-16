using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.MathTools
{
    public static class MathUtil
    {
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilGetConvFactorKelvinC();

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilGetConvFactorMFt();

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilGetConvFactorHpaInhg();

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilGetConvFactorNmiM();

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilGetConvFactorMpersKts();

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertDegreesToRadians(double degrees);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertRadiansToDegrees(double radians);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertHpaToInhg(double hPa);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertInhgToHpa(double inHg);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertMetersToFeet(double meters);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertFeetToMeters(double feet);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertMetersToNauticalMiles(double meters);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertNauticalMilesToMeters(double NMi);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertKelvinToCelsius(double kelvin);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertCelsiusToKelvin(double celsius);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertMpersToKts(double mpers);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double MathUtilConvertKtsToMpers(double kts);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern long MathUtilFactorial(int n);

        public static double CONV_FACTOR_KELVIN_C => MathUtilGetConvFactorKelvinC();
        public static double CONV_FACTOR_M_FT => MathUtilGetConvFactorMFt();
        public static double CONV_FACTOR_HPA_INHG => MathUtilGetConvFactorHpaInhg();
        public static double CONV_FACTOR_NMI_M => MathUtilGetConvFactorNmiM();
        public static double CONV_FACTOR_MPERS_KTS => MathUtilGetConvFactorMpersKts();

        public static double ConvertDegreesToRadians(double degrees)
        {
            return MathUtilConvertDegreesToRadians(degrees);
        }

        public static double ConvertRadiansToDegrees(double radians)
        {
            return MathUtilConvertRadiansToDegrees(radians);
        }

        public static double ConvertMetersToFeet(double meters)
        {
            return MathUtilConvertMetersToFeet(meters);
        }

        public static double ConvertFeetToMeters(double feet)
        {
            return MathUtilConvertFeetToMeters(feet);
        }

        public static double ConvertHpaToInhg(double hPa)
        {
            return MathUtilConvertHpaToInhg(hPa);
        }

        public static double ConvertInhgToHpa(double inHg)
        {
            return MathUtilConvertInhgToHpa(inHg);
        }

        public static double ConvertMetersToNauticalMiles(double meters)
        {
            return MathUtilConvertMetersToNauticalMiles(meters);
        }

        public static double ConvertNauticalMilesToMeters(double NMi)
        {
            return MathUtilConvertNauticalMilesToMeters(NMi);
        }

        public static double ConvertKelvinToCelsius(double kelvin)
        {
            return MathUtilConvertKelvinToCelsius(kelvin);
        }

        public static double ConvertCelsiusToKelvin(double celsius)
        {
            return MathUtilConvertCelsiusToKelvin(celsius);
        }

        public static double ConvertMpersToKts(double mpers)
        {
            return MathUtilConvertMpersToKts(mpers);
        }

        public static double ConvertKtsToMpers(double kts)
        {
            return MathUtilConvertKtsToMpers(kts);
        }

        public static long Factorial(int n)
        {
            return MathUtilFactorial(n);
        }
    }
}