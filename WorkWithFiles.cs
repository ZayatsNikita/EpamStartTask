using EpamStartTask.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace EpamStartTask
{
    public class WorkWithFiles
    {
        static public void ReadDataFromFile(List<Figure> list) //добавить проверку
        {
            string info;
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(@"D:\EPAM\EpamStartTask\CoordinateFile.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Figure fg;
            while (!streamReader.EndOfStream)
            {
                fg = null;
                info = streamReader.ReadLine();
                string[] XYArray = info.Split();
                try
                {
                    if (XYArray.Length == 8)
                    {
                        list.Add(FigureFabrica.CreateFigure(new Point(XYArray[0], XYArray[1]), new Point(XYArray[2], XYArray[3]), new Point(XYArray[4], XYArray[5]), new Point(XYArray[6], XYArray[7])));
                    }
                    else
                    {
                        if (XYArray.Length == 6)
                        {
                            list.Add(FigureFabrica.CreateFigure(new Point(XYArray[0], XYArray[1]), new Point(XYArray[2], XYArray[3]), new Point(XYArray[4], XYArray[5])));
                        }
                        else
                        {
                            if (XYArray.Length == 4)
                                list.Add(FigureFabrica.CreateFigure(new Point(XYArray[0], XYArray[1]), new Point(XYArray[2], XYArray[3])));
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            streamReader.Close();
        }
    }
}
