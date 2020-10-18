using System;

namespace EpamStartTask.Models
{
    public class Triangle : Figure
    {
        public Triangle(Point one, Point two, Point three) : base(one, two, three)
        {

            Area = 0.5 * Math.Abs((vertices[0].X - vertices[2].X) * (vertices[1].Y - vertices[2].Y) -
                        (vertices[1].X - vertices[2].X) * (vertices[0].Y - vertices[2].Y));

            Perimeter = PointManager.DistanceBetweenPoints(vertices[0], vertices[1]) +
                   PointManager.DistanceBetweenPoints(vertices[1], vertices[2]) +
                   PointManager.DistanceBetweenPoints(vertices[2], vertices[0]);
        }
        public override double Area { get; set; }
        public override double Perimeter { get; set; }

    }
}
