using System;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class InputOutput
    {
        /// <summary>
        /// print (a1 -- )
        /// Print a value to the console.
        /// </summary>
        /// <example>
        /// "Hello, world!" print ( -- )
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("print")]
        public static void Print(OpCodeData data)
        {
            Console.WriteLine(data.RuntimeStack.PopStringify());
        }

        /// <summary>
        /// read ( -- str1)
        /// Read a string from stdin.
        /// </summary>
        /// <example>
        /// read ( returns ) "Hello!"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("read")]
        public static void ReadLine(OpCodeData data)
        {
            data.RuntimeStack.Push(Console.ReadLine());
        }
    }
}
