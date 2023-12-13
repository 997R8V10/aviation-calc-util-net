using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Units
{
    /// <summary>
    /// A Class to perform math functions on Units.
    /// Analagous to System.Math for Unit types.
    /// </summary>
    public static class UnitMath
    {
        public static Length Abs(Length a)
        {
            return new Length(units_length_abs(a.ptr));
        }

        public static Length Pow(Length a, double n)
        {
            return new Length(units_length_powf(a.ptr, n));
        }

        public static Length Sqrt(Length a)
        {
            return new Length(units_length_sqrt(a.ptr));
        }

        public static Length Sin(Length a)
        {
            return new Length(units_length_sin(a.ptr));
        }

        public static Length Cos(Length a)
        {
            return new Length(units_length_cos(a.ptr));
        }

        public static Length Tan(Length a)
        {
            return new Length(units_length_tan(a.ptr));
        }

        public static Length Sinh(Length a)
        {
            return new Length(units_length_sinh(a.ptr));
        }

        public static Length Cosh(Length a)
        {
            return new Length(units_length_cosh(a.ptr));
        }

        public static Length Tanh(Length a)
        {
            return new Length(units_length_tanh(a.ptr));
        }

        public static Length Asin(Length a)
        {
            return new Length(units_length_asin(a.ptr));
        }

        public static Length Acos(Length a)
        {
            return new Length(units_length_acos(a.ptr));
        }

        public static Length Atan(Length a)
        {
            return new Length(units_length_atan(a.ptr));
        }

        public static Length Atan2(Length a, Length b)
        {
            return new Length(units_length_atan2(a.ptr, b.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_abs(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_powf(IntPtr ptr, double n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_sqrt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_sin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_cos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_tan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_sinh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_cosh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_tanh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_asin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_acos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_atan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_length_atan2(IntPtr ptr, IntPtr other_ptr);

        public static Pressure Abs(Pressure a)
        {
            return new Pressure(units_pressure_abs(a.ptr));
        }

        public static Pressure Pow(Pressure a, double n)
        {
            return new Pressure(units_pressure_powf(a.ptr, n));
        }

        public static Pressure Sqrt(Pressure a)
        {
            return new Pressure(units_pressure_sqrt(a.ptr));
        }

        public static Pressure Sin(Pressure a)
        {
            return new Pressure(units_pressure_sin(a.ptr));
        }

        public static Pressure Cos(Pressure a)
        {
            return new Pressure(units_pressure_cos(a.ptr));
        }

        public static Pressure Tan(Pressure a)
        {
            return new Pressure(units_pressure_tan(a.ptr));
        }

        public static Pressure Sinh(Pressure a)
        {
            return new Pressure(units_pressure_sinh(a.ptr));
        }

        public static Pressure Cosh(Pressure a)
        {
            return new Pressure(units_pressure_cosh(a.ptr));
        }

        public static Pressure Tanh(Pressure a)
        {
            return new Pressure(units_pressure_tanh(a.ptr));
        }

        public static Pressure Asin(Pressure a)
        {
            return new Pressure(units_pressure_asin(a.ptr));
        }

        public static Pressure Acos(Pressure a)
        {
            return new Pressure(units_pressure_acos(a.ptr));
        }

        public static Pressure Atan(Pressure a)
        {
            return new Pressure(units_pressure_atan(a.ptr));
        }

        public static Pressure Atan2(Pressure a, Pressure b)
        {
            return new Pressure(units_pressure_atan2(a.ptr, b.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_abs(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_powf(IntPtr ptr, double n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_sqrt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_sin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_cos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_tan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_sinh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_cosh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_tanh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_asin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_acos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_atan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_pressure_atan2(IntPtr ptr, IntPtr other_ptr);

        public static Temperature Abs(Temperature a)
        {
            return new Temperature(units_temperature_abs(a.ptr));
        }

        public static Temperature Pow(Temperature a, double n)
        {
            return new Temperature(units_temperature_powf(a.ptr, n));
        }

        public static Temperature Sqrt(Temperature a)
        {
            return new Temperature(units_temperature_sqrt(a.ptr));
        }

        public static Temperature Sin(Temperature a)
        {
            return new Temperature(units_temperature_sin(a.ptr));
        }

        public static Temperature Cos(Temperature a)
        {
            return new Temperature(units_temperature_cos(a.ptr));
        }

        public static Temperature Tan(Temperature a)
        {
            return new Temperature(units_temperature_tan(a.ptr));
        }

        public static Temperature Sinh(Temperature a)
        {
            return new Temperature(units_temperature_sinh(a.ptr));
        }

        public static Temperature Cosh(Temperature a)
        {
            return new Temperature(units_temperature_cosh(a.ptr));
        }

        public static Temperature Tanh(Temperature a)
        {
            return new Temperature(units_temperature_tanh(a.ptr));
        }

        public static Temperature Asin(Temperature a)
        {
            return new Temperature(units_temperature_asin(a.ptr));
        }

        public static Temperature Acos(Temperature a)
        {
            return new Temperature(units_temperature_acos(a.ptr));
        }

        public static Temperature Atan(Temperature a)
        {
            return new Temperature(units_temperature_atan(a.ptr));
        }

        public static Temperature Atan2(Temperature a, Temperature b)
        {
            return new Temperature(units_temperature_atan2(a.ptr, b.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_abs(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_powf(IntPtr ptr, double n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_sqrt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_sin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_cos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_tan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_sinh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_cosh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_tanh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_asin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_acos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_atan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_temperature_atan2(IntPtr ptr, IntPtr other_ptr);

        public static Velocity Abs(Velocity a)
        {
            return new Velocity(units_velocity_abs(a.ptr));
        }

        public static Velocity Pow(Velocity a, double n)
        {
            return new Velocity(units_velocity_powf(a.ptr, n));
        }

        public static Velocity Sqrt(Velocity a)
        {
            return new Velocity(units_velocity_sqrt(a.ptr));
        }

        public static Velocity Sin(Velocity a)
        {
            return new Velocity(units_velocity_sin(a.ptr));
        }

        public static Velocity Cos(Velocity a)
        {
            return new Velocity(units_velocity_cos(a.ptr));
        }

        public static Velocity Tan(Velocity a)
        {
            return new Velocity(units_velocity_tan(a.ptr));
        }

        public static Velocity Sinh(Velocity a)
        {
            return new Velocity(units_velocity_sinh(a.ptr));
        }

        public static Velocity Cosh(Velocity a)
        {
            return new Velocity(units_velocity_cosh(a.ptr));
        }

        public static Velocity Tanh(Velocity a)
        {
            return new Velocity(units_velocity_tanh(a.ptr));
        }

        public static Velocity Asin(Velocity a)
        {
            return new Velocity(units_velocity_asin(a.ptr));
        }

        public static Velocity Acos(Velocity a)
        {
            return new Velocity(units_velocity_acos(a.ptr));
        }

        public static Velocity Atan(Velocity a)
        {
            return new Velocity(units_velocity_atan(a.ptr));
        }

        public static Velocity Atan2(Velocity a, Velocity b)
        {
            return new Velocity(units_velocity_atan2(a.ptr, b.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_abs(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_powf(IntPtr ptr, double n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_sqrt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_sin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_cos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_tan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_sinh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_cosh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_tanh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_asin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_acos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_atan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_velocity_atan2(IntPtr ptr, IntPtr other_ptr);

        public static Angle Abs(Angle a)
        {
            return new Angle(units_angle_abs(a.ptr));
        }

        public static Angle Pow(Angle a, double n)
        {
            return new Angle(units_angle_powf(a.ptr, n));
        }

        public static Angle Sqrt(Angle a)
        {
            return new Angle(units_angle_sqrt(a.ptr));
        }

        public static Angle Sin(Angle a)
        {
            return new Angle(units_angle_sin(a.ptr));
        }

        public static Angle Cos(Angle a)
        {
            return new Angle(units_angle_cos(a.ptr));
        }

        public static Angle Tan(Angle a)
        {
            return new Angle(units_angle_tan(a.ptr));
        }

        public static Angle Sinh(Angle a)
        {
            return new Angle(units_angle_sinh(a.ptr));
        }

        public static Angle Cosh(Angle a)
        {
            return new Angle(units_angle_cosh(a.ptr));
        }

        public static Angle Tanh(Angle a)
        {
            return new Angle(units_angle_tanh(a.ptr));
        }

        public static Angle Asin(Angle a)
        {
            return new Angle(units_angle_asin(a.ptr));
        }

        public static Angle Acos(Angle a)
        {
            return new Angle(units_angle_acos(a.ptr));
        }

        public static Angle Atan(Angle a)
        {
            return new Angle(units_angle_atan(a.ptr));
        }

        public static Angle Atan2(Angle a, Angle b)
        {
            return new Angle(units_angle_atan2(a.ptr, b.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_abs(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_powf(IntPtr ptr, double n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_sqrt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_sin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_cos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_tan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_sinh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_cosh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_tanh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_asin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_acos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_atan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angle_atan2(IntPtr ptr, IntPtr other_ptr);

        public static AngularVelocity Abs(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_abs(a.ptr));
        }

        public static AngularVelocity Pow(AngularVelocity a, double n)
        {
            return new AngularVelocity(units_angular_velocity_powf(a.ptr, n));
        }

        public static AngularVelocity Sqrt(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_sqrt(a.ptr));
        }

        public static AngularVelocity Sin(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_sin(a.ptr));
        }

        public static AngularVelocity Cos(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_cos(a.ptr));
        }

        public static AngularVelocity Tan(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_tan(a.ptr));
        }

        public static AngularVelocity Sinh(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_sinh(a.ptr));
        }

        public static AngularVelocity Cosh(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_cosh(a.ptr));
        }

        public static AngularVelocity Tanh(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_tanh(a.ptr));
        }

        public static AngularVelocity Asin(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_asin(a.ptr));
        }

        public static AngularVelocity Acos(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_acos(a.ptr));
        }

        public static AngularVelocity Atan(AngularVelocity a)
        {
            return new AngularVelocity(units_angular_velocity_atan(a.ptr));
        }

        public static AngularVelocity Atan2(AngularVelocity a, AngularVelocity b)
        {
            return new AngularVelocity(units_angular_velocity_atan2(a.ptr, b.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_abs(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_powf(IntPtr ptr, double n);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_sqrt(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_sin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_cos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_tan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_sinh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_cosh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_tanh(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_asin(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_acos(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_atan(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr units_angular_velocity_atan2(IntPtr ptr, IntPtr other_ptr);
    }
}
