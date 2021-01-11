using System;
namespace AI12_DataObjects
{
    public class Debug
    {
        public Debug()
        {
        }

        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void LogError(string error)
        {
            Console.Error.WriteLine(error);
        }

        public static void LogWarning(string message)
        {
            Console.WriteLine(message);
        }
    }
}
