using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public class Utility
    {
        public static int SelectEnum(string label, int start, int end)
        {
            int outValue;

            do
            {
                Console.Write(label);
            }
            while (!(int.TryParse(Console.ReadLine(), out outValue) && IsRangeValid(outValue, start, end)));

            return outValue;
        }

        public static bool IsRangeValid(int value, int start, int end)
        {
            return value >= start && value <= end;
        } 
    }
}