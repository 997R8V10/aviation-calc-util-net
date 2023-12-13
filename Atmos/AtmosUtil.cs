using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Atmos
{
    /// <summary>
    /// Atmospheric Calculations
    /// </summary>
    public static class AtmosUtil
    {
        /// <summary>
        /// Specific Gas Constant for dry air (J/(kg*K))
        /// </summary>
        public static double R_DRY_AIR => atmos_get_const_R_DRY_AIR();

        /// <summary>
        /// Ratio of specific heat at a constant pressure to heat at a constant volume for air
        /// </summary>
        public static double SPEC_HEAT_RATIO_AIR => atmos_get_const_SPEC_HEAT_RATIO_AIR();

        /// <summary>
        /// ISA Sea Level Standard Temperature
        /// </summary>
        public static Temperature ISA_STD_TEMP => new Temperature(atmos_get_const_ISA_STD_TEMP());

        /// <summary>
        /// ISA Sea Level Standard Pressure
        /// </summary>
        public static Pressure ISA_STD_PRES => new Pressure(atmos_get_const_ISA_STD_PRES());

        /// <summary>
        /// ISA Sea Level Air Density (kg/m^3)
        /// </summary>
        public static double ISA_STD_DENS => atmos_get_const_ISA_STD_DENS();

        /// <summary>
        /// ISA Standard Lapse Rate (K/m) below 11000m altitude.
        /// </summary>
        public static double ISA_STD_LAPSE_RATE => atmos_get_const_ISA_STD_LAPSE_RATE();

        /// <summary>
        /// ISA Temperature in the Stratosphere (above 11000m)
        /// </summary>
        public static Temperature ISA_STRATO_TEMP => new Temperature(atmos_get_const_ISA_STRATO_TEMP());

        /// <summary>
        /// Conversion Factor between Pressure and Altitude (m/Pa)
        /// </summary>
        public static double ISA_STD_PRES_DROP_PER_ALT => atmos_get_const_ISA_STD_PRES_DROP_PER_ALT();

        /// <summary>
        /// Calculates the density of dry air at a given temperature and pressure.
        /// </summary>
        /// <param name="p">Absolute pressure</param>
        /// <param name="t">Absolute temperature</param>
        /// <returns>rho: Dry air density (kg/m^3)</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Density_of_air">Reference</see></remarks>
        public static double CalculateDryAirDensity(Pressure p, Temperature t)
        {
            return atmos_calculate_dry_air_density(p.ptr, t.ptr);
        }

        /// <summary>
        /// Calculates static air pressure at a given altitude
        /// </summary>
        /// <param name="h">Desired altitude above mean sea level</param>
        /// <param name="h_0">Reference altitude above mean sea level</param>
        /// <param name="p_0">Reference static air pressure</param>
        /// <param name="t">Absolute temperature at `h`</param>
        /// <returns>Static air pressure at `h`</returns>
        /// <remarks><see href="https://www.omnicalculator.com/physics/air-pressure-at-altitude">Reference</see></remarks>
        public static Pressure CalculatePressureAtAlt(Length h, Length h_0, Pressure p_0, Temperature t)
        {
            return new Pressure(atmos_calculate_pressure_at_alt(h.ptr, h_0.ptr, p_0.ptr, t.ptr));
        }

        /// <summary>
        /// Calculates the absolute temperature at a given altitude
        /// </summary>
        /// <param name="h">Desired altitude above mean sea level</param>
        /// <param name="h_0">Reference altitude above mean sea level</param>
        /// <param name="t_0">Reference absolute temperature</param>
        /// <returns>T: Absolute temperature at h</returns>
        public static Temperature CalculateTempAtAlt(Length h, Length h_0, Temperature t_0)
        {
            return new Temperature(atmos_calculate_temp_at_alt(h.ptr, h_0.ptr, t_0.ptr));
        }

        /// <summary>
        /// Calculates the density altitude
        /// </summary>
        /// <param name="p">Absolute pressure</param>
        /// <param name="t">Absolute temperature</param>
        /// <returns>Density altitude</returns>
        /// <remarks><see href="https://www.omnicalculator.com/physics/air-pressure-at-altitude">Reference</see></remarks>
        public static Length CalculateDensityAltitude(Pressure p, Temperature t)
        {
            return new Length(atmos_calculate_density_altitude(p.ptr, t.ptr));
        }

        /// <summary>
        /// Calculates the impact pressure
        /// </summary>
        /// <param name="cas">Calibrated airspeed</param>
        /// <returns>qc: Impact pressure</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Calibrated_airspeed">Reference</see></remarks>
        public static Pressure CalculateImpactPressure(Velocity cas)
        {
            return new Pressure(atmos_calculate_impact_pressure_at_cas(cas.ptr));
        }

        /// <summary>
        /// Calculates the calibrated air speed
        /// </summary>
        /// <param name="qc">Impact pressure</param>
        /// <returns>cas: Calibrated air speed</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Calibrated_airspeed">Reference</see></remarks>
        public static Velocity CalculateCalibratedAirspeed(Pressure qc)
        {
            return new Velocity(atmos_calculate_calibrated_airspeed(qc.ptr));
        }

        /// <summary>
        /// Calculates the mach number
        /// </summary>
        /// <param name="qc">Impact pressure</param>
        /// <param name="p">Absolute pressure</param>
        /// <returns>M: Mach number</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Mach_number">Reference</see></remarks>
        public static double CalculateMachNumber(Pressure qc, Pressure p)
        {
            return atmos_calculate_mach_number(qc.ptr, p.ptr);
        }

        /// <summary>
        /// Calculates the equivalent air speed
        /// </summary>
        /// <param name="m">Mach number</param>
        /// <param name="p">Absolute pressure</param>
        /// <returns>eas: Equivalent air speed</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Equivalent_airspeed">Reference</see></remarks>
        public static Velocity CalculateEas(double m, Pressure p)
        {
            return new Velocity(atmos_calculate_eas(m, p.ptr));
        }

        /// <summary>
        /// Calculates the speed of sound in dry air at a given temperature
        /// </summary>
        /// <param name="t">Absolute temperature</param>
        /// <returns>Speed of sound</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Mach_number">Reference</see></remarks>
        public static Velocity CalculateSpeedOfSoundDryAir(Temperature t)
        {
            return new Velocity(atmos_calculate_speed_of_sound_dry_air(t.ptr));
        }

        /// <summary>
        /// Calculates the true air speed from mach number
        /// </summary>
        /// <param name="m">Mach number</param>
        /// <param name="t">Absolute temperature</param>
        /// <returns>tas: True air speed</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/True_airspeed">Reference</see></remarks>
        public static Velocity ConvertMachToTas(double m, Temperature t)
        {
            return new Velocity(atmos_convert_mach_to_tas(m, t.ptr));
        }

        /// <summary>
        /// Calculates the impact pressure
        /// </summary>
        /// <param name="m">Mach number</param>
        /// <param name="p">Absolute pressure</param>
        /// <returns>qc: Impact pressure</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Impact_pressure">Reference</see></remarks>
        public static Pressure CalculateImpactPressure(double m, Pressure p)
        {
            return new Pressure(atmos_calculate_impact_pressure(m, p.ptr));
        }

        /// <summary>
        /// Calculates the mach number from the true air speed.
        /// </summary>
        /// <param name="tas">True air speed</param>
        /// <param name="t">Absolute temperature</param>
        /// <returns>M: Mach number</returns>
        /// <remarks><see href="https://en.wikipedia.org/wiki/True_airspeed">Reference</see></remarks>
        public static double ConvertTasToMach(Velocity tas, Temperature t)
        {
            return atmos_convert_tas_to_mach(tas.ptr, t.ptr);
        }

        /// <summary>
        /// Converts Indicated Air Speed to True Air Speed
        /// </summary>
        /// <param name="ias">Indicated air speed</param>
        /// <param name="ref_press">Reference pressure</param>
        /// <param name="alt">True Altitude</param>
        /// <param name="ref_alt">Reference altitude</param>
        /// <param name="ref_temp">Reference temperature</param>
        /// <returns>True air speed, Mach Number</returns>
        public static (Velocity tas, double mach) ConvertIasToTas(Velocity ias, Pressure ref_press, Length alt, Length ref_alt, Temperature ref_temp)
        {
            var ret = atmos_convert_ias_to_tas(ias.ptr, ref_press.ptr, alt.ptr, ref_alt.ptr, ref_temp.ptr);
            return (new Velocity(ret.speed), ret.mach);
        }

        /// <summary>
        /// Converts True Air Speed to Indicated Air Speed
        /// </summary>
        /// <param name="tas">True air speed</param>
        /// <param name="ref_press">Reference pressure</param>
        /// <param name="alt">True altitude</param>
        /// <param name="ref_alt">Reference altitude</param>
        /// <param name="ref_temp">Reference temperature</param>
        /// <returns>Indicated air speed, Mach Number</returns>
        public static (Velocity ias, double mach) ConvertTasToIas(Velocity tas, Pressure ref_press, Length alt, Length ref_alt, Temperature ref_temp)
        {
            var ret = atmos_convert_tas_to_ias(tas.ptr, ref_press.ptr, alt.ptr, ref_alt.ptr, ref_temp.ptr);
            return (new Velocity(ret.speed), ret.mach);
        }

        /// <summary>
        /// Converts Indicated Altitude to Absolute Altitude
        /// </summary>
        /// <param name="alt_ind">Indicated altitude</param>
        /// <param name="pres_set">Pressure setting</param>
        /// <param name="sfc_pres">Surface pressure</param>
        /// <returns>Absolute altitude</returns>
        public static Length ConvertIndicatedToAbsoluteAlt(Length alt_ind, Pressure pres_set, Pressure sfc_pres)
        {
            return new Length(atmos_convert_indicated_to_absolute_alt(alt_ind.ptr, pres_set.ptr, sfc_pres.ptr));
        }

        /// <summary>
        /// Converts Absolute Altitude to Indicated Altitude
        /// </summary>
        /// <param name="alt_abs">Absolute altitude</param>
        /// <param name="pres_set">Pressure setting</param>
        /// <param name="sfc_pres">Surface pressure</param>
        /// <returns>Indicated altitude</returns>
        public static Length ConvertAbsoluteToIndicatedAlt(Length alt_abs, Pressure pres_set, Pressure sfc_pres)
        {
            return new Length(atmos_convert_absolute_to_indicated_alt(alt_abs.ptr, pres_set.ptr, sfc_pres.ptr));
        }

        /// <summary>
        /// Converts Indicated Altitude to Pressure Altitude
        /// </summary>
        /// <param name="alt_ind">Indicated altitude</param>
        /// <param name="pres_set">Pressure setting</param>
        /// <returns>Pressure altitude</returns>
        public static Length ConvertIndicatedToPressureAlt(Length alt_ind, Pressure pres_set)
        {
            return new Length(atmos_convert_indicated_to_pressure_alt(alt_ind.ptr, pres_set.ptr));

        }

        /// <summary>
        /// Calculate ISA (International Standard Atmosphere) Temperature at a Pressure Altitude.
        /// </summary>
        /// <param name="alt_pres">Pressure altitude</param>
        /// <returns>ISA Temp</returns>
        public static Temperature CalculateIsaTemp(Length alt_pres)
        {
            return new Temperature(atmos_calculate_isa_temp(alt_pres.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_calibrated_airspeed(IntPtr qc);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_density_altitude(IntPtr p, IntPtr t);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_calculate_dry_air_density(IntPtr p, IntPtr t);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_eas(double m, IntPtr p);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_impact_pressure(double m, IntPtr p);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_impact_pressure_at_cas(IntPtr cas);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_isa_temp(IntPtr alt_pres);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_calculate_mach_number(IntPtr qc, IntPtr p);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_pressure_at_alt(IntPtr h, IntPtr h_0, IntPtr p_0, IntPtr t);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_speed_of_sound_dry_air(IntPtr t);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_calculate_temp_at_alt(IntPtr h, IntPtr h_0, IntPtr t_0);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_convert_absolute_to_indicated_alt(IntPtr alt_abs, IntPtr pres_set, IntPtr sfc_pres);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropSpeedMachStruct atmos_convert_ias_to_tas(IntPtr ias, IntPtr ref_press, IntPtr alt, IntPtr ref_alt, IntPtr ref_temp);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_convert_indicated_to_absolute_alt(IntPtr alt_ind, IntPtr pres_set, IntPtr sfc_pres);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_convert_indicated_to_pressure_alt(IntPtr alt_ind, IntPtr pres_set);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_convert_mach_to_tas(double m, IntPtr t);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropSpeedMachStruct atmos_convert_tas_to_ias(IntPtr tas, IntPtr ref_pres, IntPtr alt, IntPtr ref_alt, IntPtr ref_temp);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_convert_tas_to_mach(IntPtr tas, IntPtr t);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_get_const_ISA_STD_DENS();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_get_const_ISA_STD_LAPSE_RATE();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_get_const_ISA_STD_PRES();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_get_const_ISA_STD_PRES_DROP_PER_ALT();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_get_const_ISA_STD_TEMP();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr atmos_get_const_ISA_STRATO_TEMP();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_get_const_R_DRY_AIR();
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double atmos_get_const_SPEC_HEAT_RATIO_AIR();
    }
}
