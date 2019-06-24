namespace SerialPortListen
{
    public class Coordinate
    {
        public Coordinate(string data, string direction, CoordinateType coordinateType)
        {
            Data = data;
            Direction = direction;
            CoordinateType = coordinateType;
        }

        public string Data { get; }
        public string Direction { get; }
        public CoordinateType CoordinateType { get; }
    }
}