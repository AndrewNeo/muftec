﻿using System;
using System.Collections.Generic;

namespace Muftec.Lib
{
    /// <summary>
    /// This is the general exception class for Muftec.
    /// </summary>
    public class MuftecGeneralException : Exception
    {
        /// <summary>
        /// General exception
        /// </summary>
        public MuftecGeneralException() { }

        /// <summary>
        /// General exception with stack trace
        /// </summary>
        /// <param name="runtimeStack">Reference to the current execution stack</param>
        public MuftecGeneralException(Stack<MuftecStackItem> runtimeStack)
        {
            MuftecStackTrace(runtimeStack);
        }

        /// <summary>
        /// General exception with stack trace and message
        /// </summary>
        /// <param name="runtimeStack">Reference to the current execution stack</param>
        /// <param name="message">Message</param>
        public MuftecGeneralException(Stack<MuftecStackItem> runtimeStack, string message) : base(message)
        {
            MuftecStackTrace(runtimeStack);
        }

        /// <summary>
        /// Perform a stack trace
        /// </summary>
        /// <param name="runtimeStack">Reference to the current execution stack</param>
        public static void MuftecStackTrace(Stack<MuftecStackItem> runtimeStack)
        {
            if (!Shared.IsDebug()) return;

            // TODO: Put this in a string instead of printing to the console
            Console.WriteLine("== STACK TRACE ==");

            var fixedStack = runtimeStack.ToArray();

            foreach (var item in fixedStack)
            {
                Console.WriteLine("{0}: ({1}) {2}", runtimeStack.Count, StackTypeToString(item.Type), item.ToDebugString());
            }

            Console.WriteLine();
        }

        private static string StackTypeToString(MuftecType stackType)
        {
            switch (stackType)
            {
                case MuftecType.Integer:
                    return "integer";
                case MuftecType.Float:
                    return "float";
                case MuftecType.String:
                    return "string";
                case MuftecType.List:
                    return "list";
                case MuftecType.Dictionary:
                    return "dict";
                default:
                    return "invalid";
            }
        }
    }

    /// <summary>
    /// This exception occours when a function attempts to use a stack item of the wrong type.
    /// </summary>
    public class MuftecInvalidStackItemTypeException : MuftecGeneralException
    {
        public MuftecInvalidStackItemTypeException(Stack<MuftecStackItem> runtimeStack) : base(runtimeStack) { }
    }

    /// <summary>
    /// This exception occours when a function cannot properly convert one type to another.
    /// </summary>
    public class MuftecInvalidConversionException : MuftecGeneralException
    {
        public MuftecInvalidConversionException(Stack<MuftecStackItem> runtimeStack, string exceptionMessage) : base(runtimeStack, exceptionMessage) { }
    }

    /// <summary>
    /// This exception occours when the stack underflows.
    /// </summary>
    public class MuftecStackUnderflowException : MuftecGeneralException { }

    /// <summary>
    /// This exception occours when the execution system runs into an unknown opcode.
    /// </summary>
    public class MuftecInvalidOpcodeException : MuftecGeneralException
    {
        public MuftecInvalidOpcodeException(Stack<MuftecStackItem> runtimeStack) : base(runtimeStack) { }
        public MuftecInvalidOpcodeException(Stack<MuftecStackItem> runtimeStack, string exceptionMessage) : base(runtimeStack, exceptionMessage) { }
    }

    /// <summary>
    /// This exception occours when there is a compiler error.
    /// </summary>
    public class MuftecCompilerException : Exception
    {
        public MuftecCompilerException(string message) : base("Compile error\r\n" + message) { }
        public MuftecCompilerException(string message, int lineNum) : base(String.Format("Compile error on line {0}:\r\n{1}", lineNum, message)) { }
    }
}
