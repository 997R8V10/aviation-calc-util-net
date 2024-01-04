using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Physics
{
    /// <summary>
    /// Physics Calculations
    /// </summary>
    public static class PhysicsUtil
    {
        /// <summary>
        /// Calculates Final Velocity <br />
        /// 
        /// Kinematics Equation: V<sub>f</sub> = V<sub>i</sub> + a * t
        /// </summary>
        public static Velocity KinematicsFinalVelocity(Velocity initialVelocity, Acceleration acceleration, TimeSpan time)
        {
            return new Velocity(physics_kinematics_final_velocity(initialVelocity.ptr, acceleration.ptr, InteropUtil.ManagedTimeSpanToDateTimeStruct(time)));
        }

        /// <summary>
        /// Calculates Final Velocity <br />
        /// 
        /// Kinematics Equation: V<sub>f</sub> = V<sub>i</sub> + a * t <br />
        /// 
        /// **Note**: All Units must be kept constant!
        /// </summary>
        public static double KinematicsFinalVelocity(double initialVelocity, double acceleration, double time)
        {
            return physics_kinematics_final_velocity_general(initialVelocity, acceleration, time);
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr physics_kinematics_final_velocity(IntPtr initial_velocity, IntPtr acceleration, InteropDateTimeStruct time);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double physics_kinematics_final_velocity_general(double initial_velocity, double acceleration, double time);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr physics_kinematics_displacement_1(IntPtr initial_velocity, IntPtr final_velocity, InteropDateTimeStruct time);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double physics_kinematics_displacement_1_general(double initial_velocity, double final_velocity, double time);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr physics_kinematics_displacement_2(IntPtr initial_velocity, IntPtr acceleration, InteropDateTimeStruct time);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double physics_kinematics_displacement_2_general(double initial_velocity, double acceleration, double time);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropDateTimeStruct physics_kinematics_time_1(IntPtr displacement, IntPtr initial_velocity, IntPtr final_velocity);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern double physics_kinematics_time_1_general(double displacement, double initial_velocity, double final_velocity);
    }
}