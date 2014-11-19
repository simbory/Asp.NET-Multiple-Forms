namespace AspNet.HtmlControls
{
    public  interface ICoordinate
    {
        double Latitude { get; set; }

        double Longitude { get; set; }
    }

    internal static class CoordinateExtension
    {
        public static bool IsLatitudeValid(ICoordinate coordinate)
        {
            return coordinate.Latitude >= -90.000d && coordinate.Latitude <= 90.000d;
        }

        public static bool IsLongitudeValid(ICoordinate coordinate)
        {
            return coordinate.Longitude >= -180.000d && coordinate.Latitude <= 180.000d;
        }
    }
}
