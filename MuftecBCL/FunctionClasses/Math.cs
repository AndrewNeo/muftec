using System;
using System.Collections.Generic;
using Muftec.Lib;

namespace Muftec.BCL.FunctionClasses
{
    public static class Math
    {
        /// <summary>
        /// + (n1 n2 -- n3)
        /// Perform the addition operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 2 3 + ( returns ) 5
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("+")]
        public static void Add(OpCodeData data)
        {
            var item2 = Shared.Pop(data.RuntimeStack);
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
            {
                result = new MuftecStackItem(item1.AsDouble() + item2.AsDouble());
            }
            else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
            {
                result = new MuftecStackItem((int)item1.Item + (int)item2.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// - (n1 n2 -- n3)
        /// Perform the subtraction operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 5 2 - ( returns ) 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        /// <exception cref="MuftecInvalidStackItemTypeException">Raised when values other than a float or integer are used</exception>
        [OpCode("-")]
        public static void Subtract(OpCodeData data)
        {
            var item2 = Shared.Pop(data.RuntimeStack);
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
            {
                result = new MuftecStackItem(item1.AsDouble() - item2.AsDouble());
            }
            else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
            {
                result = new MuftecStackItem((int)item1.Item - (int)item2.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// * (n1 n2 -- n3)
        /// Perform the multiplication operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 2 3 * ( returns ) 6
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("*")]
        public static void Multiply(OpCodeData data)
        {
            var item2 = Shared.Pop(data.RuntimeStack);
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
            {
                result = new MuftecStackItem(item1.AsDouble() * item2.AsDouble());
            }
            else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
            {
                result = new MuftecStackItem((int)item1.Item * (int)item2.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// / (n1 n2 -- n3)
        /// Perform the division operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 5 10 / ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("/")]
        public static void Divide(OpCodeData data)
        {
            var item2 = Shared.Pop(data.RuntimeStack);
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
            {
                result = new MuftecStackItem(item1.AsDouble() / item2.AsDouble());
            }
            else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
            {
                result = new MuftecStackItem((int)item1.Item / (int)item2.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// % (n1 n2 -- n3)
        /// Perform the modulus operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 2 3 % ( returns ) 1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("%")]
        public static void Modulus(OpCodeData data)
        {
            var item2 = Shared.Pop(data.RuntimeStack);
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if ((item1.Type == MuftecType.Float) || (item2.Type == MuftecType.Float))
            {
                result = new MuftecStackItem(item1.AsDouble() % item2.AsDouble());
            }
            else if ((item1.Type == MuftecType.Integer) && (item2.Type == MuftecType.Integer))
            {
                result = new MuftecStackItem((int)item1.Item % (int)item2.Item);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// ^ (n1 n2 -- float3)
        /// Perform the modulus operation on the first two numbers in the stack.
        /// </summary>
        /// <example>
        /// 4 5 ^ ( returns ) 1024.0
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("^")]
        public static void Exponent(OpCodeData data)
        {
            var item2 = Shared.Pop(data.RuntimeStack);
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if (((item1.Type == MuftecType.Float) || (item1.Type == MuftecType.Integer)) &&
                ((item2.Type == MuftecType.Float) || (item2.Type == MuftecType.Integer)))
            {
                result = new MuftecStackItem(System.Math.Pow(item1.AsDouble(), item2.AsDouble()));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// ++ (n1 -- n2)
        /// Add one to the number on top of the stack.
        /// </summary>
        /// <example>
        /// 3 ++ ( returns ) 4
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("++")]
        public static void PlusPlus(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if (item1.Type == MuftecType.Float)
            {
                result = new MuftecStackItem((item1.AsDouble()) + 1);
            }
            else if (item1.Type == MuftecType.Integer)
            {
                result = new MuftecStackItem(((int)item1.Item) + 1);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// -- (n1 -- n2)
        /// Subtract one from the number on top of the stack.
        /// </summary>
        /// <example>
        /// 3 -- ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("--")]
        public static void MinusMinus(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if (item1.Type == MuftecType.Float)
            {
                result = new MuftecStackItem((item1.AsDouble()) - 1);
            }
            else if (item1.Type == MuftecType.Integer)
            {
                result = new MuftecStackItem(((int)item1.Item) - 1);
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// abs (n1 -- n2)
        /// Returns the absolute number of the number on top of the stack.
        /// </summary>
        /// <example>
        /// -3 abs ( returns ) -3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("abs")]
        public static void AbsoluteVal(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if (item1.Type == MuftecType.Float)
            {
                result = new MuftecStackItem(System.Math.Abs(item1.AsDouble()));
            }
            else if (item1.Type == MuftecType.Integer)
            {
                result = new MuftecStackItem(System.Math.Abs((int)item1.Item));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// sign (n1 -- n2)
        /// Given a number, return 1 if positive, 0 if 0, and -1 if negitive.
        /// </summary>
        /// <example>
        /// -3 sign ( returns ) -1
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("sign")]
        public static void Sign(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);
            MuftecStackItem result;

            if (item1.Type == MuftecType.Float)
            {
                result = new MuftecStackItem(System.Math.Sign(item1.AsDouble()));
            }
            else if (item1.Type == MuftecType.Integer)
            {
                result = new MuftecStackItem(System.Math.Sign((int)item1.Item));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }

            data.RuntimeStack.Push(result);
        }

        /// <summary>
        /// floor (float1 -- float2)
        /// Round a float to the lowest integer, returned as a float.
        /// </summary>
        /// <example>
        /// 2.7 floor ( returns ) 2
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("floor")]
        public static void Floor(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack, MuftecType.Float);
            data.RuntimeStack.Push(new MuftecStackItem(System.Math.Floor(item1.AsDouble())));
        }

        /// <summary>
        /// ceil (float1 -- float2)
        /// Round a float to the highest integer, returned as a float.
        /// </summary>
        /// <example>
        /// 2.2 floor ( returns ) 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("ceil")]
        public static void Ceiling(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack, MuftecType.Float);
            data.RuntimeStack.Push(new MuftecStackItem(System.Math.Ceiling(item1.AsDouble())));
        }

        /// <summary>
        /// sqrt (float1 -- float2)
        /// Calculate the square root of a number, returned as a float.
        /// </summary>
        /// <example>
        /// 9 sqrt ( returns ) 3
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("sqrt")]
        public static void SquareRoot(OpCodeData data)
        {
            var item1 = Shared.Pop(data.RuntimeStack);

            if ((item1.Type == MuftecType.Float) || (item1.Type == MuftecType.Integer))
            {
                data.RuntimeStack.Push(new MuftecStackItem(System.Math.Sqrt(item1.AsDouble())));
            }
            else
            {
                throw new MuftecInvalidStackItemTypeException(data.RuntimeStack);
            }
        }

        /// <summary>
        /// round (float1 int1 -- float2)
        /// Round a number to a given precision.
        /// </summary>
        /// <example>
        /// 7.899 1 round ( returns ) 7.9
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("round")]
        public static void Round(OpCodeData data)
        {
            var precision = Shared.PopInt(data.RuntimeStack);
            var value = Shared.PopFloat(data.RuntimeStack);
            data.RuntimeStack.Push(new MuftecStackItem(System.Math.Round(value, precision)));
        }

        /// <summary>
        /// getseed ( -- s )
        /// Returns the current SRAND seed setting.
        /// </summary>
        /// <example>
        /// getseed ( returns ) "abcd"
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("getseed")]
        public static void GetRandomSeed(OpCodeData data)
        {
            var seed = new MuftecStackItem(String.IsNullOrEmpty(data.RandomSeed) ? "" : data.RandomSeed);
            data.RuntimeStack.Push(seed);
        }

        /// <summary>
        /// setseed ( s -- )
        /// Sets the seed for SRAND. If SRAND is called before SETSEED is called, then
        /// SRAND is seeded with a semi-random value.
        /// </summary>
        /// <example>
        /// "test" setseed ( returns )
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("setseed")]
        public static void SetRandomSeed(OpCodeData data)
        {
            var seed = Shared.PopStr(data.RuntimeStack);
            data.RandomSeed = seed;
            data.RandomSeeded = new Random(seed.GetHashCode());
        }

        /// <summary>
        /// srand ( -- i )
        /// Generates a random seeded number.
        /// </summary>
        /// <example>
        /// srand ( returns ) 43624096
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("srand")]
        public static void SeededRandom(OpCodeData data)
        {
            if (data.RandomSeeded == null)
                data.RandomSeeded = new Random();

            data.RuntimeStack.Push(new MuftecStackItem(data.RandomSeeded.Next(0, int.MaxValue)));
        }

        /// <summary>
        /// random ( -- i )
        /// Returns a random integer from 0 to MAXINT.
        /// </summary>
        /// <example>
        /// "test" setseed ( returns )
        /// </example>
        /// <param name="data">Opcode reference data.</param>
        [OpCode("random")]
        public static void Random(OpCodeData data)
        {
            if (data.RandomUnseeded == null)
                data.RandomUnseeded = new Random();

            data.RuntimeStack.Push(new MuftecStackItem(data.RandomUnseeded.Next(0, int.MaxValue)));
        }
    }
}
