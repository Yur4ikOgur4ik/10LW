﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicalInstruments
{
    public static class ValidInput
    {
        public static int GetInt(string message = "Input an integer")
        {
            int result;

            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (int.TryParse(input, out result))
                    return result;
                else
                    Console.WriteLine("Error: the number is not integer, enter again");
            }
        }

        public static double GetDouble(string message = "Input a real number")
        {
            double result;

            while (true)
            {
                Console.WriteLine(message);
                string input = Console.ReadLine();
                if (double.TryParse(input, out result))
                    return result;
                else
                    Console.WriteLine("Error: the number is not real, enter again");
            }

        }
    }
}
