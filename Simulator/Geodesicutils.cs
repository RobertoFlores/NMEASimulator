using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulator
{
    /*Just a point, latitude and longitue values.*/
    class position
    {

        public double lat;
        public double lon;
        /*Constructor*/
        public position(double _lat, double _lon)
        {
            this.lat = _lat;
            this.lon = _lon;
        }


    }
    /*to hold the distance, and to the convert to other units.*/
    class distance
    {
        /*constant to use later in this clase*/
        const decimal EARTH_RADIUS_IN_METERS = 6372797.560856M;
        const double METERS_TO_NAUTICALS_MILES = 0.000539956803;

        double _distanceInArcRad;

        /*constructor*/
        public distance(double distance)
        {//receive the distance in arc radians.
            _distanceInArcRad = distance;
        }
        public double distanceInArcRad
        {
            get { return _distanceInArcRad; }
            set { value = distanceInArcRad; }
        }
        public double distanceInMeters
        {
            get { return distanceInArcRad * (double)EARTH_RADIUS_IN_METERS; }
            set { distanceInArcRad = value / (double)EARTH_RADIUS_IN_METERS; }
        }
        public double distanceInKilometers
        {
            get { return (_distanceInArcRad * (double)EARTH_RADIUS_IN_METERS) / 1000.0; }
            set { distanceInArcRad = (value * 1000.0) / (double)EARTH_RADIUS_IN_METERS; }
        }
        public double distanceInNauticalsMiles
        {
            get { return (distanceInArcRad * (double)EARTH_RADIUS_IN_METERS) * METERS_TO_NAUTICALS_MILES; }
            set
            {
                double meters = value / METERS_TO_NAUTICALS_MILES;
                distanceInArcRad = meters / (double)EARTH_RADIUS_IN_METERS;
            }
        }
    }
    /*The haversine formula to calculate the distance between two lat/lon coordinates  */
    class geodesicUtils
    {
        const decimal DEG_TO_RAD = 0.017453292519943295769236907684886M;
        const decimal EARTH_RADIUS_IN_METERS = 6372797.560856M;
        const double METERS_TO_NAUTICALS_MILES = 0.000539956803;
        //const decimal EARTH_RADIUS_IN_METERS = 6371000.00M;

        /*if you need to check just a point*/
        bool checkCoordinates(position a)
        {

            if (((a.lat < 90) && (a.lat > -90)) && ((a.lon < 180) && (a.lon > -180)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static float nauticalMilesToKilometer(float NauticalMiles) 
        {
            float kilometers = NauticalMiles * (float)1.852;
            return kilometers;
            
        }

        /*Convert coordinates from Degrees, Minutes, Seconds to decimal degrees*/
        public static double coordinatesFromDMStoDecimalDegrees(int D, int M, int S)
        {

            double decimalDegrees;


            if (D < 0)
            {

                decimalDegrees = D - M / 60.0 - S / 3600.0;

            }
            else
            {
                decimalDegrees = D + M / 60.0 + S / 3600.0;

            }

            return decimalDegrees;

        }

        /*convert coordinates from decimal degrees To  Degrees, Minutes, Seconds 
         *Jus to see that in a format: 001°43′47″
         */
        public static string coordinatesFromDecimalDegToDMS(double decimmalDegrees)
        {
            double D, M, S;


            D = Math.Truncate(decimmalDegrees);
            // M = TRUNC((58.65375 − 58) × 60′) = TRUNC(39.225′) = 39′
            M = Math.Truncate((decimmalDegrees - D) * 60.0);
            //s = (58.65375 − 58 − 39/60) × 3600″ = 0.0375 × 3600″ = 13.5″
            //s = (58.65375 − 58) × 3600″ − 39 × 60″ = 2353.5″ − 2340″ = 13.5″
            //S = ((decimmalDegrees - D) * 3600.0) - (M * 60.0);
            S = (decimmalDegrees - D - M / 60) * 3600.0;
            string output = (D + "° " + M + "' " + S + "\"");

            return output;

        }

        /*If you need to check a pair of coordinates.*/
        bool checkCoordinates(position a, position b)
        {
            if ((checkCoordinates(a)) && (checkCoordinates(b)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        double arcInRad(position from, position to)
        {
            /*to use the trigonometric function, first convert to radians*/

            double latitudeArc = (from.lat - to.lat) * (double)DEG_TO_RAD;
            double longitudeArc = (from.lon - to.lon) * (double)DEG_TO_RAD;

            double latitudeH = Math.Sin(latitudeArc * 0.5);
            latitudeH *= latitudeH;
            double lontitudeH = Math.Sin(longitudeArc * 0.5);
            lontitudeH *= lontitudeH;
            double tmp = Math.Cos(from.lat * (double)DEG_TO_RAD) * Math.Cos(to.lat * (double)DEG_TO_RAD);
            return 2.0 * Math.Asin(Math.Sqrt(latitudeH + tmp * lontitudeH));

        }

        double DistanceInMeters(position a, position b)
        {
            return (double)EARTH_RADIUS_IN_METERS * this.arcInRad(a, b);
        }

        double DistanceInKilometers(position a, position b)
        {
            return (double)EARTH_RADIUS_IN_METERS * this.arcInRad(a, b) / 1000.0;
        }


        /*To calculate a lat of destination point, given distance and bearing from start point
        * The return of destinatin lat is in decimal degrees
        * position has lat/lon implicit data
        */
        public static position FindPointAtDistanceFrom(position startPoint, double initialBearingRadians, double distanceKilometres)
        {

            const double radiusEarthKilometres = (double)(EARTH_RADIUS_IN_METERS) / 1000.0;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.lat);
            var startLonRad = DegreesToRadians(startPoint.lon);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));

            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads));

            position endPoint = new position(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));

            return endPoint;

        }

        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }

        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }
        /*
         * This function, calculate the Initial bearing, the input data is, lat1 = initial point
         * and lat2 = final point
         * the output is a double in degrees
         */
        public static double bearingInicial(position startPoint, position finalPoint)
        {
            //calculate de delta lon
            double Δlong = DegreesToRadians(finalPoint.lon - startPoint.lon);
            //get the lat values
            double lat1 = DegreesToRadians(startPoint.lat);
            double lat2 = DegreesToRadians(finalPoint.lat);
            //divide and conqueror
            double y = Math.Sin(Δlong) * Math.Cos(lat2);
            double x = ((Math.Cos(lat1) * Math.Sin(lat2)) - (Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(Δlong)));
            //tc1=mod(atan2(sin(lon1-lon2)*cos(lat2),cos(lat1)*sin(lat2)-sin(lat1)*cos(lat2)*cos(lon1-lon2)), 2*pi)

            //apply the values obtained
            //double θ = Math.Atan2(y,x) % (2*Math.PI);
            //θ = RadiansToDegrees(θ);
            double θ = RadiansToDegrees(Math.Atan2(y, x));
            θ = (θ + 360) % 360;
            //return the value in decial degrees  θ+360) % 360
            return θ;
        }

        public static double bearingFinal(position startPoint, position finalPoint)
        {
            //calculate de delta lon
            double Δlong =   DegreesToRadians(finalPoint.lon - startPoint.lon);
            //get the lat values
            double lat1 = DegreesToRadians(startPoint.lat);
            double lat2 = DegreesToRadians(finalPoint.lat);
            //divide and conqueror
            double y = Math.Sin(Δlong) * Math.Cos(lat2);
            double x = ((Math.Cos(lat1) * Math.Sin(lat2)) - (Math.Sin(lat1) * Math.Cos(lat2) * Math.Cos(Δlong)));
            //tc1=mod(atan2(sin(lon1-lon2)*cos(lat2),cos(lat1)*sin(lat2)-sin(lat1)*cos(lat2)*cos(lon1-lon2)), 2*pi)

            //apply the values obtained
            //double θ = Math.Atan2(y,x) % (2*Math.PI);
            //θ = RadiansToDegrees(θ);
            double θ = RadiansToDegrees(Math.Atan2(y, x));
            θ = (θ + 180) % 360;
            //return the value in decial degrees  θ+360) % 360
            return θ;
        }

    }
}
