using System;

namespace EpamStartTask.Models
{
    public class Point
    {
        public Point(string x, string y)
        {

            double xValue, yValue;
            if (double.TryParse(x, out xValue) && double.TryParse(y, out yValue))
            {
                this.Y = yValue;
                this.X = xValue;
            }
            else throw new ArgumentException("can't conver to Point.");
        }
        public Point()
        {
            X = default;
            Y = default;
        }
        public double X { get; set; }
        public double Y { get; set; }
        public static bool operator ==(in Point one, in Point two)
        {
            if ((Object)one == null && (Object)two == null)
                return true;
            if (((Object)one == null && (Object)two != null) || ((Object)one != null && (Object)two == null))
                return false;
            return ((one.X == two.X) && (one.Y == two.Y));
        }
        public static bool operator !=(in Point one, in Point two)
        {
            if (one == two)
                return false;
            else return true;
        }
    }
}
