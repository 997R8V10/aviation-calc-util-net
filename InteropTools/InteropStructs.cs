using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.InteropTools
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DegMinSec
    {
        internal int degrees;
        internal uint mins;
        internal double secs;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropWindStruct
    {
        internal IntPtr dir;
        internal IntPtr spd;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropSpeedMachStruct
    {
        internal IntPtr speed;
        internal double mach;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropDateStruct
    {
        internal int year;
        internal uint month;
        internal uint day;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropDateTimeStruct
    {
        internal long secs;
        internal uint nsecs;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropArrStruct
    {
        internal IntPtr ptr;
        internal UIntPtr length;
        internal UIntPtr capacity;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropCourseInterceptInfo
    {
        internal IntPtr required_course;
        internal IntPtr along_track_distance;
        internal IntPtr cross_track_error;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropChordLine
    {
        internal IntPtr bearing;
        internal IntPtr distance;
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct InteropTurnLeadDistance
    {
        internal bool is_null;
        internal IntPtr turn_lead_dist;
        internal IntPtr radius_of_turn;
        internal IntPtr intersection;
    }
}
