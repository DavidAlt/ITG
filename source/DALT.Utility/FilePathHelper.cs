using System;

namespace DALT.Utility
{
    public static class FilePathHelper
    {
        public static void PrintCurrentDirectory()
        {
            Console.WriteLine("Current directory: {0}", Environment.CurrentDirectory);
        }

        public static void PrintBaseDirectory()
        {
            Console.WriteLine("Base directory: {0}", AppDomain.CurrentDomain.BaseDirectory);
        }

        public static void PrintCurrentAssemblyPath()
        {
            Console.WriteLine("Assembly path: {0}", System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
        }

        public static void PrintCommandLine()
        {
            Console.WriteLine("Command line: {0}", Environment.CommandLine);
        }

        // Important classes
        // System.Environment
        // System.IO.File, FileInfo
        // System.IO.Directory, DirectoryInfo
        // System.IO.Path
        // System.Reflection.Assembly
        
    }
}
