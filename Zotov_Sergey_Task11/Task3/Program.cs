using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*TwoDPoint point1 = new TwoDPoint(1, 10);
            TwoDPoint point2 = new TwoDPoint(1, 10);

            Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", point1.GetHashCode(), point2.GetHashCode());*/

            TwoDPointWithHash newPoint1 = new TwoDPointWithHash(1, 10);
            TwoDPointWithHash newPoint2 = new TwoDPointWithHash(1, 10);



            Console.WriteLine("Hash for point1: {0}\tHash for point2: {1}", newPoint1.GetHashCode(), newPoint2.GetHashCode());

            // уникальных точек будет 2, хотя координаты их одинаковы
            /*Console.WriteLine("TwoDPointWithHash:");

            var twoDPointList = new List<TwoDPoint> { point1, point2 };
            var distinctTwoDPointList = twoDPointList.Distinct();
            foreach (var point in distinctTwoDPointList)
            {
                Console.WriteLine("Distinct point: {0}", point);
            }*/

            // одна уникальная точка
            Console.WriteLine("TwoDPointWithHash:");

            var twoDPointWithHashList = new List<TwoDPointWithHash> { newPoint1, newPoint2 };
            var distinctTwoDPointWithHashList = twoDPointWithHashList.Distinct();
            foreach (var point in distinctTwoDPointWithHashList)
            {
                Console.WriteLine("Distinct point: {0}", point);
            }

            TwoDPointWithHash point1 = new TwoDPointWithHash(1, 1);
            TwoDPointWithHash point2 = new TwoDPointWithHash(10, 10);
            TwoDPointWithHash point3 = new TwoDPointWithHash(1, 1);

            Console.WriteLine(point1.GetHashCode() == point2.GetHashCode());

            Console.WriteLine(point1.GetHashCode());
            Console.WriteLine(point2.GetHashCode());

            Console.ReadKey();
        }
    }
}
