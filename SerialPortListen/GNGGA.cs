using System;
using System.Runtime.InteropServices.ComTypes;

namespace SerialPortListen
{
    public class GNGGA
    {
        public DateTime TimeInUtc { get; }
        public Coordinate Latitude { get; }
        public Coordinate Longitude { get; }
        public QualityCode Quality { get; }
        public int NumOfSatellites { get; }
        public int HorizontalDelusion { get; }
        public int Altitude { get; }

        public GNGGA(DateTime timeInUtc, Coordinate latitude, Coordinate longitude, QualityCode quality, int numOfSatellites, int horizontalDelusion, int altitude)
        {
            TimeInUtc = timeInUtc;
            Latitude = latitude;
            Longitude = longitude;
            Quality = quality;
            NumOfSatellites = numOfSatellites;
            HorizontalDelusion = horizontalDelusion;
            Altitude = altitude;
        }
    }
}