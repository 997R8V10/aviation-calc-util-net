using AviationCalcUtilNet.Geo;
using AviationCalcUtilNet.GeoTools;
using AviationCalcUtilNet.InteropTools;
using AviationCalcUtilNet.Units;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace AviationCalcUtilNet.Aviation
{
    /// <summary>
    /// Aviation Related Calculations
    /// </summary>
    public static class AviationUtil
    {
        /// <summary>
        /// Calculates a maximum bank angle for a given rate of turn, ground speed, and bank angle limit.
        /// </summary>
        public static Angle CalculateMaxBankAngle(Velocity groundSpeed, Angle bankLimit, AngularVelocity turnRate)
        {
            return new Angle(aviation_calculate_max_bank_angle(groundSpeed.ptr, bankLimit.ptr, turnRate.ptr));
        }

        /// <summary>
        /// Calculates radius of turn at a bank angle and ground speed.
        /// </summary>
        public static Length CalculateRadiusOfTurn(Velocity groundSpeed, Angle bankAngle)
        {
            return new Length(aviation_calculate_radius_of_turn(groundSpeed.ptr, bankAngle.ptr));
        }

        /// <summary>
        /// Calculates bank angle at a certain radius of turn and ground_speed
        /// </summary>
        public static Angle CalculateBankAngle(Length radiusOfTurn, Velocity groundSpeed)
        {
            return new Angle(aviation_calculate_bank_angle(radiusOfTurn.ptr, groundSpeed.ptr));
        }

        /// <summary>
        /// Calculates the minimum turn radius for a particular turn.
        /// Factors in wind and makes sure the bank will remain below the bank limit.
        /// </summary>
        public static Length CalculateConstantRadiusTurn(Bearing startBearing, Angle turnAmount, Bearing windBearing, Velocity windSpeed, Velocity trueAirspeed, Angle bankLimit, AngularVelocity turnRate)
        {
            return new Length(aviation_calculate_constant_radius_turn(startBearing.ptr, turnAmount.ptr, windBearing.ptr, windSpeed.ptr, trueAirspeed.ptr, bankLimit.ptr, turnRate.ptr));
        }

        /// <summary>
        /// Calculates the maximum ground speed that will be achieved in a turn.
        /// </summary>
        public static Velocity CalculateMaxGroundSpeedForTurn(Bearing startBearing, Angle turnAmount, Bearing windBearing, Velocity windSpeed, Velocity trueAirspeed)
        {
            return new Velocity(aviation_calculate_max_ground_speed_for_turn(startBearing.ptr, turnAmount.ptr, windBearing.ptr, windSpeed.ptr, trueAirspeed.ptr));
        }

        /// <summary>
        /// Get the headwind component.
        /// Tailwind will be returned as negative
        /// </summary>
        public static Velocity GetHeadwindComponent(Bearing windBearing, Velocity windSpeed, Bearing bearing)
        {
            return new Velocity(aviation_get_headwind_component(windBearing.ptr, windSpeed.ptr, bearing.ptr));
        }

        /// <summary>
        /// Calculates the chord line bearing and distance for a turn.
        /// </summary>
        public static (Bearing chordBearing, Length chordLength) CalculateChordForTurn(Bearing startBearing, Angle turnAmount, Length radiusOfTurn)
        {
            var ret = aviation_calculate_chord_for_turn(startBearing.ptr, turnAmount.ptr, radiusOfTurn.ptr);

            return (new Bearing(ret.bearing), new Length(ret.distance));
        }

        /// <summary>
        /// Calculates the bearing to end point after a turn from start point.
        /// i.e. An aircraft turning direct a waypoint
        /// </summary>
        /// <returns>Bearing. If a bearing cannot be calculated, null is returned.</returns>
        public static Bearing CalculateDirectBearingAfterTurn(GeoPoint startPoint, GeoPoint endPoint, Length radiusOfTurn, Bearing startBearing)
        {
            var ret = aviation_calculate_direct_bearing_after_turn(startPoint.ptr, endPoint.ptr, radiusOfTurn.ptr, startBearing.ptr);

            if (ret == IntPtr.Zero) return null;

            return new Bearing(ret);
        }

        /// <summary>
        /// Calculates the course intercept information for a linear course to a waypoint.
        /// </summary>
        /// <returns>`required_course`: Required course along great circle path at current position <br />
        /// `along_track_distance`: Distance along course great circle path. Negative if station passage has occured <br />
        /// `cross_track_error`: Lateral offset from course. Right: Positive; Left: Negative;</returns>
        public static (Bearing requiredCourse, Length alongTrackDistance, Length crossTrackError) CalculateLinearCourseIntercept(GeoPoint aircraft, GeoPoint waypoint, Bearing course)
        {
            var ret = aviation_calculate_linear_course_intercept(aircraft.ptr, waypoint.ptr, course.ptr);

            return (new Bearing(ret.required_course), new Length(ret.along_track_distance), new Length(ret.cross_track_error));
        }

        /// <summary>
        /// Calculates the course intercept information for an arc course.
        /// </summary>
        /// <returns>`required_course`: Required course along great circle path at current position <br />
        /// `along_track_distance`: Distance along course great circle path. Negative if station passage has occured <br />
        /// `cross_track_error`: Lateral offset from course. Right: Positive; Left: Negative;</returns>
        public static (Bearing requiredCourse, Length alongTrackDistance, Length crossTrackError) CalculateArcCourseIntercept(GeoPoint aircraft, GeoPoint arcCenter, Bearing startRadial, Bearing endRadial, Length radius, bool isClockwise)
        {
            var ret = aviation_calculate_arc_course_intercept(aircraft.ptr, arcCenter.ptr, startRadial.ptr, endRadial.ptr, radius.ptr, isClockwise);

            return (new Bearing(ret.required_course), new Length(ret.along_track_distance), new Length(ret.cross_track_error));
        }

        /// <summary>
        /// Calculates the distance between the intersecion of two tangent lines of a circle and the tangent point of the circle.
        /// </summary>
        public static Length CalculateArcTangentDistance(Angle theta, Length r)
        {
            return new Length(aviation_calculate_arc_tangent_distance(theta.ptr, r.ptr));
        }

        /// <summary>
        /// Calculates turn lead distance and some other parameters
        /// </summary>
        /// <returns>(Turn Lead Distance, Radius of Turn, Intersection). Returns null if no intersection can be calculated.</returns>
        public static (Length turnLeadDistance, Length radiusOfTurn, GeoPoint intersection)? CalculateTurnLeadDistance(GeoPoint pos, GeoPoint wp, Bearing curBearing, Velocity trueAirspeed, Bearing course, Bearing windDirection, Velocity windSpeed, Angle bankLimit, AngularVelocity turnRate)
        {
            var ret = aviation_calculate_turn_lead_distance(pos.ptr, wp.ptr, curBearing.ptr, trueAirspeed.ptr, course.ptr, windDirection.ptr, windSpeed.ptr, bankLimit.ptr, turnRate.ptr);

            if (ret.is_null != 0)
            {
                return null;
            }

            return (new Length(ret.turn_lead_dist), new Length(ret.radius_of_turn), new GeoPoint(ret.intersection));
        }

        /// <summary>
        /// Finds intersection between an aircraft and a course to/from a waypoint.
        /// Will try both radials of the waypoint ONLY.
        /// </summary>
        /// <returns>Intersection. Null if no intersection can be calculated.</returns>
        public static GeoPoint FindIntersectionToCourse(GeoPoint position, GeoPoint wp, Bearing curBearing, Bearing course)
        {
            var ret = aviation_find_intersection_to_course(position.ptr, wp.ptr, curBearing.ptr, course.ptr);

            if (ret == IntPtr.Zero) return null;

            return new GeoPoint(ret);
        }

        /// <summary>
        /// Calculates Flight Path Angle (FPA)
        /// </summary>
        public static Angle CalculateFlightPathAngle(Velocity groundSpeed, Velocity verticalSpeed)
        {
            return new Angle(aviation_calculate_flight_path_angle(groundSpeed.ptr, verticalSpeed.ptr));
        }

        /// <summary>
        /// Calculate Vertical Speed from Flight Path Angle
        /// </summary>
        public static Velocity CalculateVerticalSpeed(Velocity groundSpeed, Angle flightPathAngle)
        {
            return new Velocity(aviation_calculate_vertical_speed(groundSpeed.ptr, flightPathAngle.ptr));
        }

        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropCourseInterceptInfo aviation_calculate_arc_course_intercept(IntPtr aircraft, IntPtr arc_center, IntPtr start_radial, IntPtr end_radial, IntPtr radius, bool is_clockwise);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_arc_tangent_distance(IntPtr theta, IntPtr r);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_bank_angle(IntPtr radius_of_turn, IntPtr ground_speed);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropChordLine aviation_calculate_chord_for_turn(IntPtr start_bearing, IntPtr turn_amount, IntPtr radius_of_turn);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_constant_radius_turn(IntPtr start_bearing, IntPtr turn_amount, IntPtr wind_bearing, IntPtr wind_speed, IntPtr true_airspeed, IntPtr bank_limit, IntPtr turn_rate);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_direct_bearing_after_turn(IntPtr start_point, IntPtr end_point, IntPtr radius_of_turn, IntPtr start_bearing);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropCourseInterceptInfo aviation_calculate_linear_course_intercept(IntPtr aircraft, IntPtr waypoint, IntPtr course);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_max_bank_angle(IntPtr ground_speed, IntPtr bank_limit, IntPtr turn_rate);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_max_ground_speed_for_turn(IntPtr start_bearing, IntPtr turn_amount, IntPtr wind_bearing, IntPtr wind_speed, IntPtr true_airspeed);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_radius_of_turn(IntPtr ground_speed, IntPtr bank_angle);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern InteropTurnLeadDistance aviation_calculate_turn_lead_distance(IntPtr pos, IntPtr wp, IntPtr cur_bearing, IntPtr true_airspeed, IntPtr course, IntPtr wind_direction, IntPtr wind_speed, IntPtr bank_limit, IntPtr turn_rate);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_find_intersection_to_course(IntPtr position, IntPtr wp, IntPtr cur_bearing, IntPtr course);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_get_headwind_component(IntPtr wind_bearing, IntPtr wind_speed, IntPtr bearing);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_flight_path_angle(IntPtr ground_speed, IntPtr vertical_speed);
        [DllImport("aviation_calc_util_ffi", CallingConvention = CallingConvention.Cdecl)] private static extern IntPtr aviation_calculate_vertical_speed(IntPtr ground_speed, IntPtr flight_path_angle);
    }
}
