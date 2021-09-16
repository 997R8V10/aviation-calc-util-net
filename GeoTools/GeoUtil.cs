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
        private static extern double GeoUtilConvertIndicatedToAbsoluteAlt(double alt_ind_ft, double pres_set_hpa, double sfc_pres_hpa);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertAbsoluteToIndicatedAlt(double alt_abs_ft, double pres_set_hpa, double sfc_pres_hpa);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertIndicatedToPressureAlt(double alt_ind_ft, double pres_set_hpa);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateIsaTemp(double alt_pres_ft);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertPressureToDensityAlt(double alt_pres_ft, double sat);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertIasToTas(double ias, double pres_set_hpa, double alt_ind_ft, double sat);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertTasToIas(double tas, double pres_set_hpa, double alt_ind_ft, double sat);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertIasToTasFromDensityAltitude(double ias, double alt_dens_ft);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilConvertTasToIasDensityAltitude(double tas, double alt_dens_ft);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilCalculateTurnAmount(double currentHeading, double desiredHeading);

        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetEarthRadiusM();
        
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetStdPresHpa();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetStdTempC();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetStdLapseRate();
        [DllImport("aviationcalc", CallingConvention = CallingConvention.Cdecl)]
        private static extern double GeoUtilGetStdPresDrop();
        
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

        public static double CalculateMaxBankAngle(double groundSpeed, double bankLimit, double turnRate)
        {
            return GeoUtilCalculateMaxBankAngle(groundSpeed, bankLimit, turnRate);
        }

        public static double CalculateRadiusOfTurn(double bankAngle, double groundSpeed)
        {
            return GeoUtilCalculateRadiusOfTurn(bankAngle, groundSpeed);
        }

        public static double CalculateBankAngle(double radiusOfTurn, double groundSpeed)
        {
            return GeoUtilCalculateBankAngle(radiusOfTurn, groundSpeed);
        }

        public static double CalculateConstantRadiusTurn(double startBearing, double turnAmount, double windBearing, double windSpeed, double tas)
        {
            return GeoUtilCalculateConstantRadiusTurn(startBearing, turnAmount, windBearing, windSpeed, tas);
        }

        public static double HeadwindComponent(double windSpeed, double windBearing, double bearing)
        {
            return GeoUtilGetHeadwindComponent(windSpeed, windBearing, bearing);
        }

        public static double CalculateDistanceTravelledNMi(double groundSpeedKts, double timeMs)
        {
            return GeoUtilCalculateDistanceTravelledNMi(groundSpeedKts, timeMs);
        }

        public static double CalculateDegreesTurned(double distTravelledNMi, double radiusOfTurnNMi)
        {
            return GeoUtilCalculateDegreesTurned(distTravelledNMi, radiusOfTurnNMi);
        }

        public static double CalculateEndHeading(double startHeading, double degreesTurned, bool isRightTurn)
        {
            return GeoUtilCalculateEndHeading(startHeading, degreesTurned, isRightTurn);
        }
        
        public static Tuple<double, double> CalculateChordHeadingAndDistance(double startHeading, double degreesTurned, double radiusOfTurnNMi, bool isRightTurn)
        {
            GeoUtilCalculateChordHeadingAndDistance(startHeading, degreesTurned, radiusOfTurnNMi, isRightTurn, out var chordHeading, out var chordDistance);
            return new Tuple<double, double>(chordHeading, chordDistance);
        }

        public static double ConvertIndicatedToAbsoluteAlt(double alt_ind_ft, double pres_set_hpa, double sfc_pres_hpa)
        {
            return GeoUtilConvertIndicatedToAbsoluteAlt(alt_ind_ft, pres_set_hpa, sfc_pres_hpa);
        }

        public static double ConvertAbsoluteToIndicatedAlt(double alt_abs_ft, double pres_set_hpa, double sfc_pres_hpa)
        {
            return GeoUtilConvertAbsoluteToIndicatedAlt(alt_abs_ft, pres_set_hpa, sfc_pres_hpa);
        }

        public static double ConvertIndicatedToPressureAlt(double alt_ind_ft, double pres_set_hpa)
        {
            return GeoUtilConvertIndicatedToPressureAlt(alt_ind_ft, pres_set_hpa);
        }

        public static double CalculateIsaTemp(double alt_pres_ft)
        {
            return GeoUtilCalculateIsaTemp(alt_pres_ft);
        }

        public static double ConvertPressureToDensityAlt(double alt_pres_ft, double sat)
        {
            return GeoUtilConvertPressureToDensityAlt(alt_pres_ft, sat);
        }

        public static double ConvertIasToTas(double ias, double pres_set_hpa, double alt_ind_ft, double sat)
        {
            return GeoUtilConvertIasToTas(ias, pres_set_hpa, alt_ind_ft, sat);
        }

        public static double ConvertTasToIas(double tas, double pres_set_hpa, double alt_ind_ft, double sat)
        {
            return GeoUtilConvertTasToIas(tas, pres_set_hpa, alt_ind_ft, sat);
        }

        public static double ConvertIasToTas(double ias, double alt_dens_ft)
        {
            return GeoUtilConvertIasToTasFromDensityAltitude(ias, alt_dens_ft);
        }

        public static double ConvertTasToIas(double tas, double alt_dens_ft)
        {
            return GeoUtilConvertTasToIasDensityAltitude(tas, alt_dens_ft);
        }

        public static double CalculateTurnAmount(double currentHeading, double desiredHeading)
        {
            return GeoUtilCalculateTurnAmount(currentHeading, desiredHeading);
        }
        
        public static double EARTH_RADIUS_M => GeoUtilGetEarthRadiusM();
        public static double STD_PRES_HPA => GeoUtilGetStdPresHpa();
        public static double STD_TEMP_C => GeoUtilGetStdTempC();
        public static double STD_LAPSE_RATE => GeoUtilGetStdLapseRate();
        public static double STD_PRES_DROP => GeoUtilGetStdPresDrop();
    }
}