using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.InteropTools
{
    [StructLayout(LayoutKind.Sequential)]
    internal class InteropDateStruct
    {
        internal int year;
        internal int month;
        internal int day;
    }

    internal class InteropUtil
    {
        internal static InteropDateStruct ManagedDateToDateStruct(DateTime date)
        {
            date = date.ToUniversalTime();

            return new InteropDateStruct() {
                year = date.Year,
                month = date.Month,
                day = date.Day
            };
        }

        internal static DateTime DateStructToManagedDate(InteropDateStruct date)
        {
            return DateTime.SpecifyKind(new DateTime(date.year, date.month, date.day), DateTimeKind.Utc);
        }

        internal static ulong ManagedDateToNs(DateTime date)
        {
            date = date.ToUniversalTime();

            //C# offset till 1400.01.01 00:00:00
            long netEpochOffset = 441481536000000000L;

            // Get Nanoseconds since boost epoch
            return (ulong) (date.Ticks - netEpochOffset);
        }

        internal static DateTime NsToManagedDate(ulong ns)
        {
            return new DateTime((long)ns, DateTimeKind.Utc);
        }
    }
}
