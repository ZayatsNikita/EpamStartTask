namespace EpamStartTask.Models
{
    public class Rectangle : Figure
    {
        public Rectangle(Point one, Point two, Point three, Point four) : base(one, two, three, four)
        {
            Area = PointManager.DistanceBetweenPoints(vertices[0], vertices[1]) * PointManager.DistanceBetweenPoints(vertices[1], vertices[2]);
            Perimeter = PointManager.DistanceBetweenPoints(vertices[0], vertices[1]) * 2 + PointManager.DistanceBetweenPoints(vertices[1], vertices[2]) * 2;
        }
        public override double Area { get; set; }
        public override double Perimeter { get; set; }
    }
}
