using System;

namespace EpamStartTask.Models
{
    public class PointManager
    {
        public static double DistanceBetweenPoints(in Point one, in Point two)
        {
            return Math.Sqrt((one.X - two.X) * (one.X - two.X) + (one.Y - two.Y) * (one.Y - two.Y));
        }
        public static bool AreParallel(in Point oneA, in Point oneB, in Point twoA, in Point twoB)
        {
            double delXOne = oneB.X - oneA.X, delXTwo = twoB.X - twoA.X;
            if (delXOne == 0 && delXTwo == 0)
                return true;
            else
            {
                if (delXOne == 0 || delXTwo == 0)
                    return false;
                if ((oneB.Y - oneA.Y) / delXOne == (twoB.Y - twoA.Y) / delXTwo)
                    return true;
                return false;
            }
        }
        public static Point AreCrossing(in Point oneA, in Point oneB, in Point twoA, in Point twoB)
        {
            Point crossPoint; //точка пересечения
            double deltaXOne = oneB.X - oneA.X, deltaYOne = oneB.Y - oneA.Y;
            double deltaXTwo = twoB.X - twoA.X, deltaYtwo = twoB.Y - twoA.Y;

            double A, B, delB, delA;

            if ((deltaXOne == 0 && deltaYOne == 0) || (deltaYOne == 0 && deltaYtwo == 0))
                return null;
            else
            {
                crossPoint = new Point();
                //Если  там и там наклонные прямые
                if (deltaXOne != 0 && deltaXTwo != 0 && deltaYOne != 0 && deltaYtwo != 0)
                {

                    //A - сводный член в первом уравнении, В - свободный член во втором уравненинии
                    A = (-oneA.X * deltaYOne / deltaXOne + oneA.Y);
                    B = (-twoA.X * deltaYtwo / deltaXTwo + twoA.Y);

                    ///delA - произодная первого уравнния delB - производная второго уравнения
                    delA = deltaYOne / deltaXOne;
                    delB = deltaYtwo / deltaXTwo;

                    crossPoint.X = (A - B) / (delB - delA);
                    crossPoint.Y = crossPoint.X * delA + A;
                }
                else
                {
                    //Если что - то равно нулю
                    if (deltaXOne == 0 || deltaXTwo == 0)
                    {
                        if (deltaXOne == 0)
                        {
                            B = (-twoA.X * deltaYtwo / deltaXTwo + twoA.Y);
                            delB = deltaYtwo / deltaXTwo;
                            crossPoint.X = (oneA.X - B) / delB;
                            crossPoint.Y = (delB * crossPoint.X) + B;
                        }
                        if (deltaXTwo == 0)
                        {
                            A = (-oneA.X * deltaYOne / deltaXOne + oneA.Y);
                            delA = deltaYOne / deltaXOne;
                            crossPoint.X = (twoA.X - A) / delA;
                            crossPoint.Y = (delA * crossPoint.X) + A;
                        }
                    }
                    else
                    {
                        // y =delA*x+a
                        // y= delB*x+B
                        if (deltaYOne == 0)
                        {
                            //y=y1
                            //y=delB*x+b
                            //x=(y1-b)delB
                            B = (-twoA.X * deltaYtwo / deltaXTwo + twoA.Y);
                            delB = deltaYtwo / deltaXTwo;
                            crossPoint.Y = oneA.Y;
                            crossPoint.X = crossPoint.Y - B / delB;
                        }
                        if (deltaYtwo == 0)
                        {
                            //y=delA*x+a
                            //y=y2;
                            //x=(y2-a)/delA
                            A = (-oneA.X * deltaYOne / deltaXOne + oneA.Y);
                            delA = deltaYOne / deltaXOne;
                            crossPoint.Y = twoA.Y;
                            crossPoint.X = crossPoint.Y - A / delA;
                        }
                    }
                }
                if (!doesPointLieOnlLine(crossPoint, oneA, oneB) && !doesPointLieOnlLine(crossPoint, twoA, twoB))
                    return null;
                else return crossPoint;
            }
        }
        public static bool doesPointLieOnlLine(in Point point, in Point linePointA, in Point linePointB)
        {

            double deltaX = linePointB.X - linePointA.X;
            double deltaY = linePointB.Y - linePointA.Y;
            double minY, maxY, maxX, minX;
            if (deltaX == 0)
            {
                if (linePointB.Y > linePointA.Y)
                {
                    maxY = linePointB.Y;
                    minY = linePointA.Y;
                }
                else
                {
                    maxY = linePointA.Y;
                    minY = linePointB.Y;
                }
                if (point.X == linePointA.X && point.Y >= minY && point.Y <= maxY)
                    return true;
                else return false;
            }
            else
            {
                if (point.Y - linePointA.Y == (point.X - linePointA.X) * (deltaY) / (deltaX))
                {

                    if (linePointB.Y > linePointA.Y)
                    {
                        maxY = linePointB.Y;
                        minY = linePointA.Y;
                    }
                    else
                    {
                        maxY = linePointA.Y;
                        minY = linePointB.Y;
                    }
                    if (linePointB.X > linePointA.X)
                    {
                        maxX = linePointB.X;
                        minX = linePointA.X;
                    }
                    else
                    {
                        maxX = linePointA.X;
                        minX = linePointB.X;
                    }
                    if (point.X <= maxX && point.X >= minX && point.Y >= minY && point.Y <= maxY)
                        return true;
                    else return false;
                }
                else
                    return false;
            }
        }

    }
}
