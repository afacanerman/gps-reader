using System;
using System.Text;

namespace SerialPortListen
{
    /// <summary>
    /// Example: $GNGGA,123519,4807.038,N,01131.000,E,1,08,0.9,545.4,M,46.9,M,,*47
    ///    GGA          Global Positioning System Fix Data
    ///    123519       Fix taken at 12:35:19 UTC
    ///    4807.038,N Latitude 48 deg 07.038' N
    ///    01131.000,E Longitude 11 deg 31.000' E
    ///    1            Fix quality: 0 = invalid
    ///                 1 = GPS fix(SPS)
    ///                 2 = DGPS fix
    ///                 3 = PPS fix
    ///                 4 = Real Time Kinematic
    ///                 5 = Float RTK
    ///                 6 = estimated(dead reckoning) (2.3 feature)
    ///                 7 = Manual input mode
    ///                 8 = Simulation mode
    ///    08           Number of satellites being tracked
    ///    0.9          Horizontal dilution of position
    ///    545.4,M Altitude, Meters, above mean sea level
    ///    46.9,M Height of geoid(mean sea level) above WGS84
    ///    ellipsoid
    ///    (empty field) time in seconds since last DGPS update
    ///    (empty field) DGPS station ID number
    ///    *47          the checksum data, always begins with*
    /// </summary>
    public class GNGGAParser
    {
        private readonly string _message;

        public GNGGAParser(string message)
        {
            if (!_message.StartsWith("$GNGGA"))
            {
                throw new Exception("The message is not GNGGA type");
            }

            _message = message;
        }

        public GNGGA Parse()
        {
            var splitMessage = _message.Split(',');

            var timeInUtc = ParseTime(splitMessage[1]);
            var latitude = new Coordinate(splitMessage[2], splitMessage[3], CoordinateType.Latitude);
            var longitude = new Coordinate(splitMessage[4], splitMessage[5], CoordinateType.Longitude);
            var quality = (QualityCode) int.Parse(splitMessage[6]);
            var numOfSatellites = int.Parse(splitMessage[7]);
            var horizontalDelusion = int.Parse(splitMessage[8]);
            var altitude = int.Parse(splitMessage[9]);

            return new GNGGA(timeInUtc, latitude, longitude, quality, numOfSatellites, horizontalDelusion, altitude);
        }

        private DateTime ParseTime(string timeStr)
        {
            var s = DateTime.UtcNow;
            var timeList = timeStr.SplitInParts(2);
            var splitTime = string.Join(",", timeList).Split(',');
            var ts = new TimeSpan(int.Parse(splitTime[0]), int.Parse(splitTime[1]), int.Parse(splitTime[2]));
            s = s.Date + ts;
            return s;
        }
    }
}