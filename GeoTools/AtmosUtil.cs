using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.GeoTools
{
    public static class AtmosUtil
    {
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_R_DRY_AIR();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_SPEC_HEAT_RATIO_AIR();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_TEMP_K();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_TEMP_C();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_PRES_Pa();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_PRES_hPa();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_DENS();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_LAPSE_RATE();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_EARTH_G();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilGetConst_ISA_STD_PRES_DROP_ft_PER_hPa();
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateDryAirDensity(double p, double T);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateImpactPressure1(double cas);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateImpactPressure2(double M, double p);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateCalibratedAirspeed(double qc);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateMachNumber(double qc, double p);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateEas(double M, double p);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertMachToTas(double M, double T);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertTasToMach(double tas, double T);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculatePressureAtAlt(double h, double h0, double p0, double T);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateTempAtAlt(double h, double h0, double T0);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateDensityAltitude(double p, double T);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateSpeedOfSoundDryAir(double T);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertIasToTas(double ias_kts, double refPress_hPa, double alt_ft, double refAlt_ft, double refTemp_K, out double mach);
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertTasToIas(double tas_kts, double refPress_hPa, double alt_ft, double refAlt_ft, double refTemp_K, out double mach);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertIndicatedToAbsoluteAlt(double alt_ind_ft, double pres_set_hpa, double sfc_pres_hpa);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertAbsoluteToIndicatedAlt(double alt_abs_ft, double pres_set_hpa, double sfc_pres_hpa);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilConvertIndicatedToPressureAlt(double alt_ind_ft, double pres_set_hpa);
		[DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)] private static extern double AtmosUtilCalculateIsaTemp(double alt_pres_ft);

		/// <summary>
		/// Specific Gas Constant for dry air (J/(kg*K))
		/// </summary>
		public static double R_DRY_AIR => AtmosUtilGetConst_R_DRY_AIR();

		/// <summary>
		/// Ratio of specific heat at a constant pressure to heat at a constant volume for air
		/// </summary>
		public static double SPEC_HEAT_RATIO_AIR => AtmosUtilGetConst_SPEC_HEAT_RATIO_AIR();

		/// <summary>
		/// ISA Sea Level Standard Temperature (K)
		/// </summary>
		public static double ISA_STD_TEMP_K => AtmosUtilGetConst_ISA_STD_TEMP_K();

		/// <summary>
		/// ISA Sea Level Standard Temperature (C)
		/// </summary>
		public static double ISA_STD_TEMP_C => AtmosUtilGetConst_ISA_STD_TEMP_C();

		/// <summary>
		/// ISA Sea Level Standard Pressure (Pa)
		/// </summary>
		public static double ISA_STD_PRES_Pa => AtmosUtilGetConst_ISA_STD_PRES_Pa();

		/// <summary>
		/// ISA Sea Level Standard Pressure (hPa)
		/// </summary>
		public static double ISA_STD_PRES_hPa => AtmosUtilGetConst_ISA_STD_PRES_hPa();

		/// <summary>
		/// ISA Sea Level Air Density (kg/m^3)
		/// </summary>
		public static double ISA_STD_DENS => AtmosUtilGetConst_ISA_STD_DENS();

		/// <summary>
		/// ISA Standard Lapse Rate (K/m) below 11000m altitude.
		/// </summary>
		public static double ISA_STD_LAPSE_RATE => AtmosUtilGetConst_ISA_STD_LAPSE_RATE();

		/// <summary>
		/// Earth Surface Gravitational Acceleration (m/s^2)
		/// </summary>
		public static double EARTH_G => AtmosUtilGetConst_EARTH_G();

		/// <summary>
		/// Conversion Factor between hPa and ft of altitude.
		/// </summary>
		public static double ISA_STD_PRES_DROP_ft_PER_hPa => AtmosUtilGetConst_ISA_STD_PRES_DROP_ft_PER_hPa();

		/// <summary>
		/// Calculates the density of dry air at a given temperature and pressure.
		/// </summary>
		/// <param name="p">Absolute pressure (Pa)</param>
		/// <param name="T">Absolute temperature (K)</param>
		/// <returns>rho: Dry air density (kg/m^3)</returns>
		public static double CalculateDryAirDensity(double p, double T)
        {
			return AtmosUtilCalculateDryAirDensity(p, T);
        }

		/// <summary>
		/// Calculates the impact pressure
		/// </summary>
		/// <param name="cas">Calibrated airspeed (m/s)</param>
		/// <returns>qc: Impact pressure (Pa)</returns>
		public static double CalculateImpactPressure(double cas)
        {
			return AtmosUtilCalculateImpactPressure1(cas);
        }

		/// <summary>
		/// Calculates the impact pressure
		/// </summary>
		/// <param name="M">Mach number</param>
		/// <param name="p">Absolute pressure (Pa)</param>
		/// <returns>qc: Impact pressure (Pa)</returns>
		public static double CalculateImpactPressure(double M, double p)
        {
			return AtmosUtilCalculateImpactPressure2(M, p);
        }

		/// <summary>
		/// Calculates the calibrated air speed
		/// </summary>
		/// <param name="qc">Impact pressure (Pa)</param>
		/// <returns>cas: Calibrated air speed (m/s)</returns>
		public static double CalculateCalibratedAirspeed(double qc)
        {
			return AtmosUtilCalculateCalibratedAirspeed(qc);
        }

		/// <summary>
		/// Calculates the mach number
		/// </summary>
		/// <param name="qc">Impact pressure (Pa)</param>
		/// <param name="p">Absolute pressure (Pa)</param>
		/// <returns>M: Mach number</returns>
		public static double CalculateMachNumber(double qc, double p)
        {
			return AtmosUtilCalculateMachNumber(qc, p);
        }

		/// <summary>
		/// Calculates the equivalent air speed
		/// </summary>
		/// <param name="M">Mach number</param>
		/// <param name="p">Absolute pressure (Pa)</param>
		/// <returns>eas: Equivalent air speed (m/s)</returns>
		public static double CalculateEas(double M, double p)
        {
			return AtmosUtilCalculateEas(M, p);
        }

		/// <summary>
		/// Calculates the true air speed from mach number
		/// </summary>
		/// <param name="M">Mach number</param>
		/// <param name="T">Absolute temperature (K)</param>
		/// <returns>tas: True air speed (m/s)</returns>
		public static double ConvertMachToTas(double M, double T)
        {
			return AtmosUtilConvertMachToTas(M, T);
        }

		/// <summary>
		/// Calculates the mach number from the true air speed.
		/// </summary>
		/// <param name="tas">True air speed (m/s)</param>
		/// <param name="T">Absolute temperature (K)</param>
		/// <returns>M: Mach number</returns>
		public static double ConvertTasToMach(double tas, double T)
        {
			return AtmosUtilConvertTasToMach(tas, T);
        }

		/// <summary>
		/// Calculates the static air pressure at a given altitude
		/// </summary>
		/// <param name="h">Desired altitude above mean sea level (m)</param>
		/// <param name="h0">Reference altitude above mean sea level (m)</param>
		/// <param name="p0">Reference static air pressure (Pa)</param>
		/// <param name="T">Absolute temperature at h (K)</param>
		/// <returns>p: Static air pressure at h (Pa)</returns>
		public static double CalculatePressureAtAlt(double h, double h0, double p0, double T)
        {
			return AtmosUtilCalculatePressureAtAlt(h, h0, p0, T);
        }

		/// <summary>
		/// Calculates the absolute temperature at a given altitude
		/// </summary>
		/// <param name="h">Desired altitude above mean sea level (m)</param>
		/// <param name="h0">Reference altitude above mean sea level (m)</param>
		/// <param name="T0">Reference absolute temperature (K)</param>
		/// <returns>T: Absolute temperature at h (K)</returns>
		public static double CalculateTempAtAlt(double h, double h0, double T0)
        {
			return AtmosUtilCalculateTempAtAlt(h, h0, T0);
        }

		/// <summary>
		/// Calculates the density altitude
		/// </summary>
		/// <param name="p">Absolute pressure (Pa)</param>
		/// <param name="T">Absolute temperature (K)</param>
		/// <returns>Density altitude (m)</returns>
		public static double CalculateDensityAltitude(double p, double T)
        {
			return AtmosUtilCalculateDensityAltitude(p, T);
        }

		/// <summary>
		/// Calculates the speed of sound in dry air at a given temperature
		/// </summary>
		/// <param name="T">Absolute temperature (K)</param>
		/// <returns>Speed of sound (m/s)</returns>
		public static double CalculateSpeedOfSoundDryAir(double T)
        {
			return AtmosUtilCalculateSpeedOfSoundDryAir(T);
        }

		/// <summary>
		/// Converts Indicated Air Speed to True Air Speed
		/// </summary>
		/// <param name="ias_kts">Indicated air speed (kts)</param>
		/// <param name="refPress_hPa">Reference pressure (hPa)</param>
		/// <param name="alt_ft True">altitude (ft)</param>
		/// <param name="refAlt_ft">Reference altitude (ft)</param>
		/// <param name="refTemp_K">Reference temperature (K)</param>
		/// <param name="mach">output Mach number</param>
		/// <returns>True air speed (kts)</returns>
		public static double ConvertIasToTas(double ias_kts, double refPress_hPa, double alt_ft, double refAlt_ft, double refTemp_K, out double mach)
        {
			return AtmosUtilConvertIasToTas(ias_kts, refPress_hPa, alt_ft, refAlt_ft, refTemp_K, out mach);
        }

		/// <summary>
		/// Converts True Air Speed to Indicated Air Speed
		/// </summary>
		/// <param name="tas_kts">True air speed (kts)</param>
		/// <param name="refPress_hPa">Reference pressure (hPa)</param>
		/// <param name="alt_ft True">altitude (ft)</param>
		/// <param name="refAlt_ft">Reference altitude (ft)</param>
		/// <param name="refTemp_K">Reference temperature (K)</param>
		/// <param name="mach">output Mach number</param>
		/// <returns>Indicated air speed (kts)</returns>
		public static double ConvertTasToIas(double tas_kts, double refPress_hPa, double alt_ft, double refAlt_ft, double refTemp_K, out double mach)
		{
			return AtmosUtilConvertTasToIas(tas_kts, refPress_hPa, alt_ft, refAlt_ft, refTemp_K, out mach);
		}

		/// <summary>
		/// Converts Indicated Altitude to Absolute Altitude
		/// </summary>
		/// <param name="alt_ind_ft">Indicated altitude (ft)</param>
		/// <param name="pres_set_hpa">Pressure setting (hPa)</param>
		/// <param name="sfc_pres_hpa">Surface pressure (hPa)</param>
		/// <returns>Absolute altitude (ft)</returns>
		public static double ConvertIndicatedToAbsoluteAlt(double alt_ind_ft, double pres_set_hpa, double sfc_pres_hpa)
        {
			return AtmosUtilConvertIndicatedToAbsoluteAlt(alt_ind_ft, pres_set_hpa, sfc_pres_hpa);
        }

		/// <summary>
		/// Converts Absolute Altitude to Indicated Altitude
		/// </summary>
		/// <param name="alt_abs_ft">Absolute altitude (ft)</param>
		/// <param name="pres_set_hpa">Pressure setting (hPa)</param>
		/// <param name="sfc_pres_hpa">Surface pressure (hPa)</param>
		/// <returns>Indicated altitude (ft)</returns>
		public static double ConvertAbsoluteToIndicatedAlt(double alt_abs_ft, double pres_set_hpa, double sfc_pres_hpa)
        {
			return AtmosUtilConvertAbsoluteToIndicatedAlt(alt_abs_ft, pres_set_hpa, sfc_pres_hpa);
		}

		/// <summary>
		/// Converts Indicated Altitude to Pressure Altitude
		/// </summary>
		/// <param name="alt_ind_ft">Indicated altitude (ft)</param>
		/// <param name="pres_set_hpa">Pressure setting (hPa)</param>
		/// <returns>Pressure altitude (ft)</returns>
		public static double ConvertIndicatedToPressureAlt(double alt_ind_ft, double pres_set_hpa)
        {
			return AtmosUtilConvertIndicatedToPressureAlt(alt_ind_ft, pres_set_hpa);

		}

		/// <summary>
		/// Calculate ISA (International Standard Atmosphere) Temperature at a Pressure Altitude.
		/// </summary>
		/// <param name="alt_pres_ft">Pressure altitude (ft)</param>
		/// <returns>ISA Temp (C)</returns>
		public static double CalculateIsaTemp(double alt_pres_ft)
        {
			return AtmosUtilCalculateIsaTemp(alt_pres_ft);
        }
	}
}
