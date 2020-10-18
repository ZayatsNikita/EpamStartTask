using System;
using EpamStartTask.Models;
namespace EpamStartTask
{
    public class FigureFabrica //Проверить все точки на совпадение
    {

        static public bool IsCircle(params Point[] arr)
        {
            if (arr.Length != 2)
                return false;
            else
            {
                if (arr[0] == arr[1])
                    return false;
                else return true;
            }
        }
        static public bool IsTriangle(params Point[] arr)
        {
            if (arr.Length != 3)
                return false;
            else
            {
                if (AreThereDuplicatePoint(arr))
                    return false;
                else
                {
                    //Проверяем чтобы три вершины не лежали на одой прямой
                    if (PointManager.doesPointLieOnlLine(arr[2], arr[0], arr[1]))
                        return false;
                    else return true;
                }
            }
        }
        static public bool IsTrapeze(params Point[] arr)
        {
            if (arr.Length != 4)
                return false;
            else
            {
                if (AreThereDuplicatePoint(arr))
                    return false;
                else
                {
                    if ((PointManager.AreParallel(arr[0], arr[1], arr[2], arr[3]) && !PointManager.AreParallel(arr[1], arr[2], arr[3], arr[0])) || (!PointManager.AreParallel(arr[0], arr[1], arr[2], arr[3]) && PointManager.AreParallel(arr[1], arr[2], arr[3], arr[0])))
                    {
                        if (PointManager.AreCrossing(arr[1], arr[2], arr[3], arr[0]) == null)
                            return true;
                        else return false;
                    }
                    return false;
                }
            }
        }
        static public bool IsParallelogram(params Point[] arr)
        {
            if (arr.Length != 4)
                return false;
            else
            {
                if (AreThereDuplicatePoint(arr))
                    return false;
                else
                {

                    if (PointManager.AreParallel(arr[0], arr[1], arr[2], arr[3]) && PointManager.AreParallel(arr[1], arr[2], arr[3], arr[0]))
                    {
                        double cos = ((arr[1].X - arr[0].X) * (arr[2].X - arr[1].X)
                            + (arr[1].Y - arr[0].Y) * (arr[2].Y - arr[1].Y)) /
                            (Math.Sqrt(
                                (arr[1].X - arr[0].X) * (arr[1].X - arr[0].X) +
                                (arr[1].Y - arr[0].Y) * (arr[1].Y - arr[0].Y)) *
                              Math.Sqrt(
                                (arr[2].X - arr[1].X) * (arr[2].X - arr[1].X) +
                                (arr[2].Y - arr[1].Y) * (arr[2].Y - arr[1].Y))
                             );
                        if (cos == 0)
                            return false;
                        else return true;
                    }
                    else return false;
                }
            }
        }
        static public bool IsRectangle(params Point[] arr)
        {
            if (AreThereDuplicatePoint(arr))
                throw new ArgumentException("There are duplicate points!");
            else
            {
                if (arr.Length < 4)
                    return false;
                if (PointManager.AreParallel(arr[0], arr[1], arr[2], arr[3]) && PointManager.AreParallel(arr[1], arr[2], arr[3], arr[0]))
                {
                    double cos = ((arr[1].X - arr[0].X) * (arr[2].X - arr[1].X)
                            + (arr[1].Y - arr[0].Y) * (arr[2].Y - arr[1].Y)) /
                            (Math.Sqrt(
                                (arr[1].X - arr[0].X) * (arr[1].X - arr[0].X) +
                                (arr[1].Y - arr[0].Y) * (arr[1].Y - arr[0].Y)) *
                              Math.Sqrt(
                                (arr[2].X - arr[1].X) * (arr[2].X - arr[1].X) +
                                (arr[2].Y - arr[1].Y) * (arr[2].Y - arr[1].Y))
                             );
                    if (cos == 0)
                        return true;
                    else return false;
                }
                else return false;
            }
        }
        static public bool AreThereDuplicatePoint(params Point[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[i] == arr[j])
                        return true;
                }

            }
            return false;
        }




        static public Triangle CreateTriangle(params Point[] arr)
        {
            Triangle tr = new Triangle(arr[0], arr[1], arr[2]);
            return tr;
        }
        static public Rectangle CreateRectangle(params Point[] arr)
        {

            Rectangle rec = new Rectangle(arr[0], arr[1], arr[2], arr[3]);
            return rec;

        }
        static public Trapeze CreateTrapeze(params Point[] arr)
        {
            if (IsTrapeze(arr))
            {
                Trapeze tr = new Trapeze(arr[0], arr[1], arr[2], arr[3]);
                return tr;
            }
            else
                throw new ArgumentException("Is not Triangle");
        }
        static public Circle CreateCircle(params Point[] arr)
        {
            if (IsCircle(arr))
            {
                Circle ci = new Circle(arr[0], arr[1]);
                return ci;
            }
            else
                throw new ArgumentException("Is not Triangle");
        }
        static public Parallelogram CreateParallelogram(params Point[] arr)
        {
            Parallelogram pr = new Parallelogram(arr[0], arr[1], arr[2], arr[3]);
            return pr;
        }

        static public Figure CreateFigure(params Point[] array)
        {
            if (IsCircle(array))
                return CreateCircle(array);
            if (IsParallelogram(array))
                return CreateParallelogram(array);
            if (IsRectangle(array))
                return CreateRectangle(array);
            if (IsTrapeze(array))
                return CreateTrapeze(array);
            if (IsTriangle(array))
                return CreateTriangle(array);
            throw new ArgumentException("found a figure that is ouutside the allowed range(allowed fieres: circle, triangle, rectangle, trapezoid, parallelogram)");
        }
    }
}
