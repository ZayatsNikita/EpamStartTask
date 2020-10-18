using System;

namespace EpamStartTask.Models
{
    public class Parallelogram : Figure
    {
        public Parallelogram(Point one, Point two, Point three, Point four) : base(one, two, three, four)
        {
            Area = 1 / 2 * (Math.Abs(vertices[0].X * vertices[1].Y +
                    vertices[1].X * vertices[2].Y +
                    vertices[2].X * vertices[3].Y +
                    vertices[3].X * vertices[0].Y -
                    vertices[1].X * vertices[0].Y -
                    vertices[2].X * vertices[1].Y -
                    vertices[3].X * vertices[2].Y -
                    vertices[0].X * vertices[3].Y));
            Perimeter = PointManager.DistanceBetweenPoints(vertices[0], vertices[1]) + PointManager.DistanceBetweenPoints(vertices[1], vertices[2]) +
                PointManager.DistanceBetweenPoints(vertices[2], vertices[3]) + PointManager.DistanceBetweenPoints(vertices[0], vertices[3]);
        }
        public override double Perimeter { get; set; }
        public override double Area { get; set; }
    }
}
