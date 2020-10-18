using System;
using System.Collections.Generic;
using System.Linq;
using EpamStartTask.Models;
namespace EpamStartTask
{
    public static class FigureManager
    {
        public static double AvaregePerimetr(List<Figure> list, string type)
        {
            double perimetr = 0;
            int count = 0;
            foreach (Figure fg in list)
            {
                if (fg.GetType().Name == type || type == "*")
                {
                    count++;
                    perimetr += fg.Perimeter;
                }
            }
            if (count == 0)
                return 0;
            perimetr = perimetr / count++; ;
            return perimetr;
        }
        public static double AvaregeArea(List<Figure> list, string type)
        {
            double area = 0;
            int count = 0;
            foreach (Figure fg in list)
            {
                if (fg.GetType().Name == type || type == "*")
                {
                    count++;
                    area += fg.Area;
                }
            }
            if (count == 0)
                return 0;
            area = area / count;
            return area;
        }
        public static Figure MaxArea(List<Figure> list, string type)
        {
            Figure maxFigure;
            if (list.Count != 0)
                maxFigure = null;
            else
                throw new ArgumentNullException();
            foreach (Figure fg in list)
            {
                if (fg.GetType().Name == type || type == "*")
                {
                    if (maxFigure == null)
                        maxFigure = fg;
                    else
                       if (maxFigure.Area >= fg.Area)
                        maxFigure = fg;
                }
            }

            return maxFigure;
        }
        public static Figure MaxPerimetr(List<Figure> list, string type)
        {
            Figure maxFigure;
            if (list.Count != 0)
                maxFigure = list.First();
            else
                throw new ArgumentNullException();
            foreach (Figure fg in list)
            {
                if (fg.GetType().Name == type || type == "*")
                    if (maxFigure.Perimeter >= fg.Perimeter)
                        maxFigure = fg;
            }
            return maxFigure;
        }
        public static void TypeWithMaxAveragePerimetr(List<Figure> list)
        {
            if (list.Count == 0)
            {
                Console.WriteLine("Список пуст");
                return;
            }
            double CircleMaxArea = 0, ParallelogramMaxArea = 0, RectangleMaxArea = 0, TrapezeMaxArea = 0, TriangleMaxArea = 0;
            CircleMaxArea = AvaregePerimetr(list, "Circle");
            ParallelogramMaxArea = AvaregePerimetr(list, "Parallelogram");
            RectangleMaxArea = AvaregePerimetr(list, "Rectangle");
            TrapezeMaxArea = AvaregePerimetr(list, "Trapeze");
            TriangleMaxArea = AvaregePerimetr(list, "Triangle");

            if (CircleMaxArea >= ParallelogramMaxArea && CircleMaxArea >= RectangleMaxArea && CircleMaxArea >= TrapezeMaxArea && CircleMaxArea >= TriangleMaxArea)
                Console.WriteLine("Фигура с максимальным периметром - круг");
            else
            {
                if (ParallelogramMaxArea >= RectangleMaxArea && ParallelogramMaxArea >= TrapezeMaxArea && ParallelogramMaxArea >= TriangleMaxArea)
                    Console.WriteLine("Фигура с максимальным периметром - паролелограмм");
                else
                {
                    if (RectangleMaxArea >= TriangleMaxArea && RectangleMaxArea >= TrapezeMaxArea)
                        Console.WriteLine("Фигура с максимальным периметром - прямоугольник");
                    else
                    {
                        if (TriangleMaxArea >= TrapezeMaxArea)
                            Console.WriteLine("Фигура с максимальным периметром - треугольник");
                        else
                            Console.WriteLine("Фигура с максимальным периметром - трапеция");
                    }
                }
            }
        }
    }
}
