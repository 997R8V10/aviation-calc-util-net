using System;
using System.Runtime.InteropServices;

namespace AviationCalcUtilNet.GeoTools
{
    public static class GeoUtil
    {
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateDirectBearingAfterTurn(IntPtr aircraft, IntPtr waypoint, double r, double curBearing);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateCrossTrackErrorM(IntPtr aircraft, IntPtr waypoint, double course, out double requiredCourse, out double alongTrackDistanceM);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateArcCourseInfo(IntPtr aircraft, IntPtr arcCenter, double startRadial, double endRadial, double radiusM, bool clockwise, out double requiredCourse, out double alongTrackDistanceM);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateTurnLeadInDistance(IntPtr ptr, double theta, double r);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateTurnLeadDistance(IntPtr pos, IntPtr wp, double trueTrack, double tas, double course, double trueWindDir, double windSpd, out double radiusOfTurn, out IntPtr intersection);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr GeoUtilFindIntersection(IntPtr position, IntPtr wp, double trueTrack, double course);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilNormalizeLongitude(double lon);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilNormalizeHeading(double hdg);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateMaxBankAngle(double groundSpeed, double bankLimit, double turnRate);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateRadiusOfTurn(double bankAngle, double groundSpeed);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateBankAngle(double radiusOfTurn, double groundSpeed);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateConstantRadiusTurn(double startBearing, double turnAmount, double windBearing, double windSpeed, double tas);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetHeadwindComponent(double windSpeed, double windBearing, double bearing);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateDistanceTravelledNMi(double groundSpeedKts, double timeMs);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateDegreesTurned(double distTravelledNMi, double radiusOfTurnNMi);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateEndHeading(double startHeading, double degreesTurned, bool isRightTurn);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GeoUtilCalculateChordHeadingAndDistance(double startHeading, double degreesTurned, double radiusOfTurnNMi, bool isRightTurn, out double chordHeading, out double chordDistance);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateTurnAmount(double currentHeading, double desiredHeading);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateDeltaToHeading(double currentHeading, double desiredHeading, bool isRightTurn);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetEarthRadiusM();


        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertDegMinSecToDecimalDegs(int degrees, uint mins, double secs);


        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GeoUtilConvertDecimalDegsToDegMinSec(double decimalDegs, out int degrees, out uint mins, out double secs);


        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GeoUtilConvertNatsToDecimalDegs([MarshalAs(UnmanagedType.LPStr)] string natsLat, [MarshalAs(UnmanagedType.LPStr)] string natsLon, out double decLat, out double decLon);


        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GeoUtilConvertDecimalDegsToNats(double decimalLat, double decimalLon, [MarshalAs(UnmanagedType.LPStr)] out string natsLat, [MarshalAs(UnmanagedType.LPStr)] out string natsLon);


        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GeoUtilConvertVrcToDecimalDegs([MarshalAs(UnmanagedType.LPStr)] string vrcLat, [MarshalAs(UnmanagedType.LPStr)] string vrcLon, out double decLat, out double decLon);


        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern void GeoUtilConvertDecimalDegsToVrc(double decimalLat, double decimalLon, [MarshalAs(UnmanagedType.LPStr)] out string vrcLat, [MarshalAs(UnmanagedType.LPStr)] out string vrcLon);

        /// <summary>
        /// Calculates the direct course to intercept towards a waypoint.
        /// Returns -1 if direct course is not possible to achieve.
        /// </summary>
        /// <param name="aircraft">Aircraft position</param>
        /// <param name="waypoint">Waypoint position</param>
        /// <param name="r">Radius of Turn</param>
        /// <param name="curBearing">Aircraft's current bearing</param>
        /// <returns><c>double</c> Direct bearing to waypoint after turn</returns>
        public static double CalculateDirectBearingAfterTurn(GeoPoint aircraft, GeoPoint waypoint, double r, double curBearing)
        {
            return GeoUtilCalculateDirectBearingAfterTurn(aircraft.ptr, waypoint.ptr, r, curBearing);
        }
        
        /// <summary>
        /// Calculates cross track error in meters
        /// </summary>
        /// <param name="aircraft"><c>GeoPoint</c> Aircraft's position.</param>
        /// <param name="waypoint"><c>GeoPoint</c> Waypoint's position</param>
        /// <param name="course"><c>double</c> Course to waypoint (degrees)</param>
        /// <param name="requiredCourse"><c>out double</c> Output's course along great circle path at current position.</param>
        /// <param name="alongTrackDistanceM"><c>out double</c> Output's distance along great circle path. Negative if station passage has occured.</param>
        /// <returns><c>double</c> Cross track error (m). Right: Positive; Left: Negative;</returns>
        public static double CalculateCrossTrackErrorM(GeoPoint aircraft, GeoPoint waypoint, double course, out double requiredCourse, out double alongTrackDistanceM)
        {
            return GeoUtilCalculateCrossTrackErrorM(aircraft.ptr, waypoint.ptr, course, out requiredCourse, out alongTrackDistanceM);
        }

        /// <summary>
        /// Calculates Cross Track Error in meters for an arc.
        /// </summary>
        /// <param name="aircraft">Aircraft's Position</param>
        /// <param name="arcCenter">Arc Center Position</param>
        /// <param name="startRadial">Start Radial (degrees)</param>
        /// <param name="endRadial">End Radial (degrees)</param>
        /// <param name="radiusM">Radius (m)</param>
        /// <param name="clockwise">Is Turn Clockwise?</param>
        /// <param name="requiredCourse">Output's course along arc at current position.</param>
        /// <param name="alongTrackDistanceM">Output's distance along arc. -1 if end radial has been passed</param>
        /// <returns>Cross track error (m). Right: Positive; Left: Negative;</returns>
        public static double CalculateArcCourseInfo(GeoPoint aircraft, GeoPoint arcCenter, double startRadial, double endRadial, double radiusM, bool clockwise, out double requiredCourse, out double alongTrackDistanceM)
        {
            return GeoUtilCalculateArcCourseInfo(aircraft.ptr, arcCenter.ptr, startRadial, endRadial, radiusM, clockwise, out requiredCourse, out alongTrackDistanceM);
        }


        /// <summary>
        /// Calculates required lead in distance for a turn.
        /// </summary>
        /// <param name="point"><c>GeoPoint</c> Intersection between current course and desired course.</param>
        /// <param name="theta"><c>Double</c> Amount of turn in degrees.</param>
        /// <param name="r"><c>double</c> Radius of turn.</param>
        /// <returns><c>double</c> Calculates distance prior to point that turn must begin. Units will match the units for r.</returns>
        public static double CalculateTurnLeadDistance(GeoPoint point, double theta, double r)
        {
            return GeoUtilCalculateTurnLeadInDistance(point.ptr, theta, r);
        }

        /// <summary>
        /// Calculates lead distance for a turn.
        /// </summary>
        /// <param name="pos"><c>GeoPoint</c> Aircraft's current position.</param>
        /// <param name="wp"><c>GeoPoint</c> Waypoint's position.</param>
        /// <param name="trueTrack"><c>double</c> Aircraft's true course (degrees).</param>
        /// <param name="tas"><c>double</c> Aircraft's true air speed (kts).</param>
        /// <param name="course"><c>double</c> Course to intercept to waypoint (degrees).</param>
        /// <param name="trueWindDir"><c>double</c> Wind True Direction (degrees)</param>
        /// <param name="windSpd"><c>double</c> Wind Speed (kts)</param>
        /// <param name="radiusOfTurn"><c>out double</c> Calculated radius of turn (nautical miles)</param>
        /// <param name="intersection"><c>out GeoPoint</c> Calculated intersection point</param>
        /// <returns><c>double</c> Lead distance from intersection that turn must begin (nautical miles).</returns>
        public static double CalculateTurnLeadDistance(GeoPoint pos, GeoPoint wp, double trueTrack, double tas, double course, double trueWindDir, double windSpd, out double radiusOfTurn, out GeoPoint intersection)
        {
            double toReturn = GeoUtilCalculateTurnLeadDistance(pos.ptr, wp.ptr, trueTrack, tas, course, trueWindDir, windSpd, out radiusOfTurn, out var intersectionIntPtr);
            intersection = intersectionIntPtr == IntPtr.Zero ? null : new GeoPoint(intersectionIntPtr);
            return toReturn;
        }

        /// <summary>
        /// Calculates the intersection between the aircraft's current track and a course to/from a waypoint.
        /// </summary>
        /// <param name="position"><c>GeoPoint</c> Aircraft Position</param>
        /// <param name="wp"><c>GeoPoint</c> Waypoint</param>
        /// <param name="course"><c>double</c> Course To/From Waypoint (degrees).</param>
        /// <returns><c>GeoPoint</c> The intersection, should one exist; otherwise <c>null</c></returns>
        public static GeoPoint FindIntersection(GeoPoint position, GeoPoint wp, double trueTrack, double course)
        {
            IntPtr toReturn =  GeoUtilFindIntersection(position.ptr, wp.ptr, trueTrack, course);
            return toReturn == IntPtr.Zero ? null : new GeoPoint(toReturn);
        }

        /// <summary>
        /// Normalizes Longitude between -180 and +180 degrees
        /// </summary>
        /// <param name="lon">Input Longitude (degrees)</param>
        /// <returns>Normalized Longitude (degrees)</returns>
        public static double NormalizeLongitude(double lon)
        {
            return GeoUtilNormalizeLongitude(lon);
        }

        /// <summary>
        /// Normalizes Heading between 0 and 360 degrees
        /// </summary>
        /// <param name="hdg">Input Heading (degrees)</param>
        /// <returns>Normalized Heading (degrees)</returns>
        public static double NormalizeHeading(double hdg)
        {
            return GeoUtilNormalizeHeading(hdg);
        }

        /// <summary>
        /// Calculates maximum bank angle for a given rate of turn.
        /// </summary>
        /// <param name="groundSpeed">Ground speed (kts)</param>
        /// <param name="bankLimit">Bank limit (degrees)</param>
        /// <param name="turnRate">Rate of turn (degrees/s)</param>
        /// <returns>Bank angle (degrees)</returns>
        public static double CalculateMaxBankAngle(double groundSpeed, double bankLimit, double turnRate)
        {
            return GeoUtilCalculateMaxBankAngle(groundSpeed, bankLimit, turnRate);
        }

        /// <summary>
        /// Calculates radius of turn at a certain bank angle.
        /// </summary>
        /// <param name="bankAngle">Bank angle (degrees)</param>
        /// <param name="groundSpeed">Ground speed (kts)</param>
        /// <returns>Radius of turn (nautical miles)</returns>
        public static double CalculateRadiusOfTurn(double bankAngle, double groundSpeed)
        {
            return GeoUtilCalculateRadiusOfTurn(bankAngle, groundSpeed);
        }

        /// <summary>
        /// Calculates bank angle at a certain radius of turn.
        /// </summary>
        /// <param name="radiusOfTurn">Radius of turn (nautical miles)</param>
        /// <param name="groundSpeed">Ground speed (kts)</param>
        /// <returns>Bank angle (degrees)</returns>
        public static double CalculateBankAngle(double radiusOfTurn, double groundSpeed)
        {
            return GeoUtilCalculateBankAngle(radiusOfTurn, groundSpeed);
        }

        /// <summary>
        /// Calculates the radius of turn required for a constant radius turn with wind.
        /// </summary>
        /// <param name="startBearing">Start bearing (degrees)</param>
        /// <param name="turnAmount">Amount to turn (degrees)</param>
        /// <param name="windBearing">Bearing that wind is coming from (degrees)</param>
        /// <param name="windSpeed">Wind speed (kts)</param>
        /// <param name="tas">True air speed (kts)</param>
        /// <returns>Radius of turn (nautical miles)</returns>
        public static double CalculateConstantRadiusTurn(double startBearing, double turnAmount, double windBearing, double windSpeed, double tas)
        {
            return GeoUtilCalculateConstantRadiusTurn(startBearing, turnAmount, windBearing, windSpeed, tas);
        }

        /// <summary>
        /// Gets the headwind/tailwind component.
        /// </summary>
        /// <param name="windSpeed">Wind speed (kts)</param>
        /// <param name="windBearing">Bearing that wind is coming from (degrees)</param>
        /// <param name="bearing">Bearing that aircraft is headed in (degrees)</param>
        /// <returns>Headwind Component (negative for tailwind) (kts)</returns>
        public static double HeadwindComponent(double windSpeed, double windBearing, double bearing)
        {
            return GeoUtilGetHeadwindComponent(windSpeed, windBearing, bearing);
        }

        /// <summary>
        /// Calculate distance travelled in nautical miles.
        /// </summary>
        /// <param name="groundSpeedKts">Ground speed (kts)</param>
        /// <param name="timeMs">Time (ms)</param>
        /// <returns>Distance travelled (nautical miles)</returns>
        public static double CalculateDistanceTravelledNMi(double groundSpeedKts, double timeMs)
        {
            return GeoUtilCalculateDistanceTravelledNMi(groundSpeedKts, timeMs);
        }

        /// <summary>
        /// Calculate amount of degrees turned.
        /// </summary>
        /// <param name="distTravelledNMi">Distance travelled (nautical miles)</param>
        /// <param name="radiusOfTurnNMi">Radius of turn (nautical miles)</param>
        /// <returns>Degrees turned (degrees)</returns>
        public static double CalculateDegreesTurned(double distTravelledNMi, double radiusOfTurnNMi)
        {
            return GeoUtilCalculateDegreesTurned(distTravelledNMi, radiusOfTurnNMi);
        }

        /// <summary>
        /// Calculate roll out heading.
        /// </summary>
        /// <param name="startHeading">Start heading (degrees)</param>
        /// <param name="degreesTurned">Amount of turn (degrees)</param>
        /// <param name="isRightTurn">Is the turn to the right?</param>
        /// <returns>Roll out heading (degrees)</returns>
        public static double CalculateEndHeading(double startHeading, double degreesTurned, bool isRightTurn)
        {
            return GeoUtilCalculateEndHeading(startHeading, degreesTurned, isRightTurn);
        }

        /// <summary>
        /// Calculate direct heading and distance along a circle (chord line)
        /// </summary>
        /// <param name="startHeading">Start heading (degrees)</param>
        /// <param name="degreesTurned">Amount of turn (degrees)</param>
        /// <param name="radiusOfTurnNMi">Radius of turn (nautical miles)</param>
        /// <param name="isRightTurn">Is the turn to the right?</param>
        /// <returns>Chord heading (degrees), Chord distance (nautical miles)</returns>
        public static Tuple<double, double> CalculateChordHeadingAndDistance(double startHeading, double degreesTurned, double radiusOfTurnNMi, bool isRightTurn)
        {
            GeoUtilCalculateChordHeadingAndDistance(startHeading, degreesTurned, radiusOfTurnNMi, isRightTurn, out var chordHeading, out var chordDistance);
            return new Tuple<double, double>(chordHeading, chordDistance);
        }

        /// <summary>
        /// Calculate amount of turn between two headings (0-360)
        /// </summary>
        /// <param name="currentHeading">Current heading (degrees)</param>
        /// <param name="desiredHeading">Desired heading (degrees)</param>
        /// <returns>Amount of turn (degrees). Negative is left.</returns>
        public static double CalculateTurnAmount(double currentHeading, double desiredHeading)
        {
            return GeoUtilCalculateTurnAmount(currentHeading, desiredHeading);
        }

        /// <summary>
        /// Calculate the delta to the desired heading (0-360)
        /// </summary>
        /// <param name="currentHeading">Current heading (degrees)</param>
        /// <param name="desiredHeading">Desired heading (degrees)</param>
        /// <param name="isRightTurn"></param>
        /// <returns>Delta to Heading (degrees).</returns>
        public static double CalculateDeltaToHeading(double currentHeading, double desiredHeading, bool isRightTurn)
        {
            return GeoUtilCalculateDeltaToHeading(currentHeading, desiredHeading, isRightTurn);
        }

        public static double EARTH_RADIUS_M => GeoUtilGetEarthRadiusM();

        /// <summary>
        /// Convert from degrees.minutes.seconds to decimal degrees.
        /// </summary>
        /// <param name="degrees">Degrees (signed integer)</param>
        /// <param name="mins">Minutes (unsigned integer)</param>
        /// <param name="secs">Seconds (double)</param>
        /// <returns>Decimal degrees</returns>
        public static double ConvertDegMinSecToDecimalDegs(int degrees, uint mins, double secs)
        {
            return GeoUtilConvertDegMinSecToDecimalDegs(degrees, mins, secs);
        }

        /// <summary>
        /// Convert from decimal degrees to degrees.minutes.seconds.
        /// </summary>
        /// <param name="decimalDegs">Decimal degrees</param>
        /// <param name="degrees">Output degrees (signed integer)</param>
        /// <param name="mins">Output minutes (unsigned integer)</param>
        /// <param name="secs">Output seconds (double)</param>
        public static void ConvertDecimalDegsToDegMinSec(double decimalDegs, out int degrees, out uint mins, out double secs)
        {
            GeoUtilConvertDecimalDegsToDegMinSec(decimalDegs, out degrees, out mins, out secs);
        }

        /// <summary>
        /// Convert from NATS style coordinates to decimal degrees.
        /// </summary>
        /// <param name="natsLat">NATS style latitude</param>
        /// <param name="natsLon">NATS style longitude</param>
        /// <param name="decimalLat">Decimal latitude out variable</param>
        /// <param name="decimalLon">Decimal longitude out variable</param>
        public static void ConvertNatsToDecimalDegs(string natsLat, string natsLon, out double decimalLat, out double decimalLon)
        {
            GeoUtilConvertNatsToDecimalDegs(natsLat, natsLon, out decimalLat, out decimalLon);
        }

        /// <summary>
        /// Convert from decimal degrees to NATS style coordinates.
        /// </summary>
        /// <param name="decimalLat">Decimal latitude</param>
        /// <param name="decimalLon">Decimal longitude</param>
        /// <param name="natsLat">Out NATS latitude</param>
        /// <param name="natsLon">Out NATS longitude</param>
        public static void ConvertDecimalDegsToNats(double decimalLat, double decimalLon, out string natsLat, out string natsLon)
        {
            GeoUtilConvertDecimalDegsToNats(decimalLat, decimalLon, out natsLat, out natsLon);
        }

        /// <summary>
        /// Convert from VRC/Euroscope style coordinates to decimal degrees.
        /// </summary>
        /// <param name="vrcLat">VRC/Euroscope style latitude</param>
        /// <param name="vrcLon">VRC/Euroscope style longitude</param>
        /// <param name="decimalLat">Out decimal latitude</param>
        /// <param name="decimalLon">Out decimal longitude</param>
        public static void ConvertVrcToDecimalDegs(string vrcLat, string vrcLon, out double decimalLat, out double decimalLon)
        {
            GeoUtilConvertVrcToDecimalDegs(vrcLat, vrcLon, out decimalLat, out decimalLon);
        }

        /// <summary>
        /// Convert from decimal degrees to VRC/Euroscope style coordinates.
        /// </summary>
        /// <param name="decimalLat">Decimal latitude</param>
        /// <param name="decimalLon">Decimal longitude</param>
        /// <param name="vrcLat">Out VRC/Euroscope style latitude</param>
        /// <param name="vrcLon">Out VRC/Euroscope style longitude</param>
        public static void ConvertDecimalDegsToVrc(double decimalLat, double decimalLon, out string vrcLat, out string vrcLon)
        {
            GeoUtilConvertDecimalDegsToVrc(decimalLat, decimalLon, out vrcLat, out vrcLon);
        }
    }
}