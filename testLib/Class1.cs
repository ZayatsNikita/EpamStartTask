using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using EpamStartTask.Models;
using EpamStartTask;
namespace testLib
{
    [TestFixture]
    public class FigureManagerTest
    {
        [Test]
        //проверка метода doesPointLieOnlLine из класса PointManager
        public void doesPointLieOnlLineTest1()
        {
            bool flag;
            Point point = new Point("3", "3");
            Point point2 = new Point("5", "5");
            Point point3 = new Point("4", "4");

            //act
            flag = PointManager.doesPointLieOnlLine(point3, point2, point);

            //assert
            Assert.AreEqual(flag, true);
        }
        [Test]
        public void doesPointLieOnlLineTest2()
        {
            bool flag;
            Point point = new Point("3", "3");
            Point point2 = new Point("5", "5");
            Point point3 = new Point("1", "1");

            //act
            flag = PointManager.doesPointLieOnlLine(point3, point2, point);

            //assert
            Assert.AreEqual(flag, false);
        }

        //
        [Test]
        //проверка метода DistanceBetweenPoints из класса PointManager
        public void DistanceBetweenPointsTest()
        {
            double distance;
            Point point = new Point("3", "3");
            Point point2 = new Point("5", "3");
            //act
            distance = PointManager.DistanceBetweenPoints(point2, point);

            //assert
            Assert.AreEqual(distance, 2);
        }


        [Test]
        //проверка метода AreParalle из класса PointManager
        public void AreParallelTest1()
        {
            bool flag;

            Point point = new Point("3", "3");
            Point point2 = new Point("5", "5");
            Point point3 = new Point("1", "2");
            Point point4 = new Point("2", "3");

            //act
            flag = PointManager.AreParallel(point, point2, point3, point4);

            //assert
            Assert.AreEqual(flag, true);
        }

        [Test]
        public void AreParallelTest2()
        {
            bool flag;

            Point point = new Point("3", "3");
            Point point2 = new Point("5", "5");
            Point point3 = new Point("1", "2");
            Point point4 = new Point("2", "2");

            //act
            flag = PointManager.AreParallel(point, point2, point3, point4);

            //assert
            Assert.AreEqual(flag, false);
        }

        //проверка метода AreCrossing из класса PointManager
        [Test]
        public void AreCrossingTest1()
        {
            Point flag;

            Point point = new Point("1", "1");
            Point point2 = new Point("3", "3");
            Point point3 = new Point("1", "3");
            Point point4 = new Point("3", "1");

            //act
            flag = PointManager.AreCrossing(point, point2, point3, point4);

            //assert
            Assert.IsTrue(flag == new Point("2", "2"));
        }
        [Test]
        public void AreCrossingTest2()
        {
            Point flag;

            Point point = new Point("3", "1");
            Point point2 = new Point("5", "3");
            Point point3 = new Point("5", "1");
            Point point4 = new Point("6", "3");

            //act
            flag = PointManager.AreCrossing(point, point2, point3, point4);

            //assert
            Assert.IsNull(flag);
        }
    }


    [TestFixture]
    public class FigureFactureTest
    {
        [Test]
        //проверка метода doesPointLieOnlLine из класса PointManager
        public void CreateFigureTest1()
        {
            Triangle tr;
            Point point = new Point("3", "3");
            Point point2 = new Point("5", "5");
            Point point3 = new Point("4", "4");

            //act
            try
            {
                FigureFabrica.CreateFigure(point, point2, point3);
                Assert.Fail();
            }
            catch (ArgumentException ex) { }
            //assert

        }
        [Test]
        public void CreateFigureTest2()
        {
            Triangle tr = null;
            Point point = new Point("3", "3");
            Point point2 = new Point("0", "0");
            Point point3 = new Point("4", "4");

            //act
            try
            {
                tr = (Triangle)FigureFabrica.CreateFigure(point, point2, point3);
            }
            catch (ArgumentException ex)
            { }
            Assert.IsNotNull(tr);

            //assert
        }
    }
}
