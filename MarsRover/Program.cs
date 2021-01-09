using System;

namespace MarsRover
{
    class Program
    {
        static void Main(string[] args)
        {
            //Local Test
            string[] cPos = { "1", "2" };
            string[] comm = { "L", "M", "L", "M", "L", "M", "L", "M", "M" };
            Rover r1 = new Rover(cPos, comm);

            Console.WriteLine(r1.ErrDesc);
            for (int i = 0; i < r1.NewPosition.Length; i++)
                Console.WriteLine(r1.NewPosition[i]);
        }
    }
}
