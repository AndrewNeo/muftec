using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Muftec.BCL;
using Muftec.Lib;

namespace Muftec
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Muftec 1.0");
                Console.WriteLine("Put some help documentation here, eventually.");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("muftec -x <source file>   -- Execute a source file");
                Console.WriteLine("muftec -c <source file>   -- Compiles a source file to a executable");
                Console.WriteLine("          [<out file>]    -- (Optional) Define the output filename");
            }
            else if (args[0] == "-x")
            {
                // Run a program
                var text = File.ReadAllText(args[1]);
                var output = Compiler.ParseString(text);
                if (output == null)
                {
                    Console.WriteLine("Could not continue.");
                    return;
                }

                var system = new MuftecLibSystem();
                var bcl = new MuftecBaseClassLibrary();
                system.AddLibrary(bcl);

                var queue = new Queue<MuftecStackItem>();
                queue.Enqueue(new MuftecStackItem(output.MainFunctionName, MuftecAdvType.Function));
                var runtime = new Stack<MuftecStackItem>();
                system.Run(queue, runtime, output.Variables, output.Functions);
            }
            else if (args[0] == "-c")
            {
                // Compile a program
                var text = File.ReadAllText(args[1]);
                var output = Compiler.ParseString(text);
                if (output == null)
                {
                    Console.WriteLine("Could not continue.");
                    return;
                }
                
                string filename;
                if (args.Length > 2)
                {
                    filename = args[2];
                }
                else
                {
                    filename = Path.GetFileNameWithoutExtension(args[1]);
                }

                Fabricator.SaveAssembly(output, filename + ".exe", true);
            }
            else
            {
                Console.WriteLine("Invalid switch specified.");
            }
        }
    }
}
