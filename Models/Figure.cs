using System;
using System.Text;

namespace EpamStartTask.Models
{
    public abstract class Figure
    {
        public Figure(params Point[] vertices)
        {
            this.vertices = vertices;
        }

        public Figure()
        {
        }

        protected Point[] vertices;
        public override string ToString()
        {
            StringBuilder res = new StringBuilder();
            foreach (Point point in vertices)
            {
                res.Append("(" + Convert.ToString(point.X) + " " + Convert.ToString(point.Y) + ") ");
            }

            return res.ToString();
        }

        abstract public double Perimeter { get; set; }
        abstract public double Area { get; set; }
    }
}
