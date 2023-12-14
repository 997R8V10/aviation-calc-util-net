using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.InteropTools
{
    internal class InteropUtil
    {
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void general_free_string(IntPtr ptr);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern void general_free_vec_f64(InteropArrStruct ptr);

        internal static string MarshallUnmanagedStringPtr(IntPtr strPtr)
        {
            string str = Marshal.PtrToStringAnsi(strPtr);

            general_free_string(strPtr);

            return str;
        }

        internal static double[] MarshallUnmanagedDoubleArr(InteropArrStruct arrStr)
        {
            double[] asArray = new double[(int)arrStr.length];
            Marshal.Copy(arrStr.ptr, asArray, 0, (int) arrStr.length);
            general_free_vec_f64(arrStr);
            return asArray;
        }

        internal static InteropDateStruct ManagedDateToDateStruct(DateTime date)
        {
            date = date.ToUniversalTime();

            return new InteropDateStruct() {
                year = date.Year,
                month = (uint) date.Month,
                day = (uint)date.Day
            };
        }

        internal static DateTime DateStructToManagedDate(InteropDateStruct date)
        {
            return DateTime.SpecifyKind(new DateTime(date.year, (int) date.month, (int) date.day), DateTimeKind.Utc);
        }

        internal static InteropDateTimeStruct ManagedDateToDateTimeStruct(DateTime date)
        {
            date = date.ToUniversalTime();
            var new_date = (DateTimeOffset) date;
            var secs = new_date.ToUnixTimeSeconds();
            var on_second_date = DateTimeOffset.FromUnixTimeSeconds(secs);
            var nanos = (new_date - on_second_date).Ticks * 100;

            return new InteropDateTimeStruct()
            {
                secs = secs,
                nsecs = (uint) nanos
            };
        }

        internal static DateTime DateTimeStructToManagedDate(InteropDateTimeStruct ns)
        {
            long ticks = ns.secs * TimeSpan.TicksPerSecond;
            ticks += (ns.nsecs / 100);
            return new DateTime(ticks, DateTimeKind.Utc);
        }

        internal static InteropDateTimeStruct ManagedTimeSpanToDateTimeStruct(TimeSpan timeSpan)
        {
            long secs = (long) timeSpan.TotalSeconds;
            var ticks = timeSpan.Ticks - (secs * TimeSpan.TicksPerSecond);
            uint nsecs = (uint)(ticks * 100);

            return new InteropDateTimeStruct()
            {
                secs = secs,
                nsecs = nsecs
            };
        }

        internal static TimeSpan DateTimeStructToManagedTimeSpan(InteropDateTimeStruct s)
        {
            long ticks = s.secs * TimeSpan.TicksPerSecond;
            ticks += (s.nsecs / 100);

            return new TimeSpan(ticks);
        }
    }
}
