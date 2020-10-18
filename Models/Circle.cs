using System;

namespace EpamStartTask.Models
{
    public class Circle : Figure
    {
        public Circle(Point one, Point two) : base(one, two)
        {
            Perimeter = Math.PI * 2 * PointManager.DistanceBetweenPoints(vertices[0], vertices[1]);
            Area = Math.PI * PointManager.DistanceBetweenPoints(vertices[0], vertices[1]) * PointManager.DistanceBetweenPoints(vertices[0], vertices[1]);
        }
        public override double Area { get; set; }
        public override double Perimeter { get; set; }
    }
}
