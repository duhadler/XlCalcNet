using System;

namespace NewDistrib
{
    // 
    // Created by SharpDevelop.
    // User: dietrichhadler
    // Date: 05.08.2022
    // Time: 18:19
    // 
    // To change this template use Tools | Options | Coding | Edit Standard Headers.
    // 
    static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Hello StatDistribCS!");

            DistMain.DemoDistMain();

            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }
    }
}