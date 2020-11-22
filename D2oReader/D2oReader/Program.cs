using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace D2oReader
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
#if DEBUG
                foreach (var d2oFilePath in Directory.EnumerateFiles(@"data\common").Where(entry => entry.EndsWith(".d2o")))
                {
                    new App(d2oFilePath);
                }
#else
                if (args != null)
                {
                    string d2oFilePath;

                    d2oFilePath = args[0];

                    new App(d2oFilePath);

                    if (Debugger.IsAttached)
                    {
                        Console.WriteLine("Press any key to continue . . .");
                        Console.ReadKey();
                    }
                }
#endif

                if (Debugger.IsAttached)
                {
                    Console.WriteLine("Press any key to continue . . .");
                    Console.ReadKey();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
             }
        }
    }
}

 
