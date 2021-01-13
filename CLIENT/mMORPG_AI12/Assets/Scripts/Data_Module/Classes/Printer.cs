using System;

namespace AI12_DataObjects
{
    public class Printer
    {
        public static void Line(String str)
        {
            Console.WriteLine(str);
        }

        public static void Line(String str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str, Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void Word(String str)
        {
            Console.Write(str);
        }

        public static void Word(String str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str, Console.ForegroundColor);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}