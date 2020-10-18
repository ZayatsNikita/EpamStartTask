using System;
using System.Collections.Generic;
using EpamStartTask.Models;
namespace EpamStartTask
{
    public class Program
    {
        static void Main(string[] args)
        {
            Figure figure;
            List<Figure> list = new List<Figure>();
            int choize;
            do
            {
                choize = ProgramManager.Menu();
                switch (choize)
                {
                    case 1:
                        foreach (Figure fg in list)
                        {
                            Console.WriteLine("Tipe:" + fg.GetType().Name + "; Координаты: " + fg.ToString());
                        }
                        break;
                    case 2:
                        WorkWithFiles.ReadDataFromFile(list);
                        break;
                    case 3:
                        try
                        {
                            figure = FigureManager.MaxArea(list, "*");
                            Console.WriteLine($"Фигура с максимальной площадью = {figure.Area}, это - " + figure.GetType().Name);
                        }
                        catch (ArgumentNullException ex)
                        {
                            Console.WriteLine("Список пуст");
                        }
                        break;
                    case 4:
                        Console.WriteLine(FigureManager.AvaregeArea(list, "*"));
                        break;
                    case 5:
                        Console.WriteLine(FigureManager.AvaregePerimetr(list, "*"));
                        break;
                    case 6:
                        FigureManager.TypeWithMaxAveragePerimetr(list);
                        break;
                    case 0:
                        Console.WriteLine("Goodbye");
                        break;
                    default:
                        Console.WriteLine("Wrong value");
                        break;
                }
                ProgramManager.Pause();
            } while (choize != 0);
        }
    }
}
