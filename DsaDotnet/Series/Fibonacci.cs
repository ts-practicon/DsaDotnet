﻿using System.Numerics;

namespace DsaDotnet;

public static partial class Series
{
    /// <summary>
    /// Calculates the Fibonacci number at the specified index.
    /// </summary>
    /// <param name="input">The index of the Fibonacci number to calculate.</param>
    /// <returns>The Fibonacci number at the specified index.</returns>
    /// <exception cref="ArgumentException">Thrown when the input is a negative number.</exception>
    public static ulong Fibonacci(this int input)
    {
        if (input <= 1)
        {
            if (input < 0)
            {
                throw new ArgumentException("Cannot calculate the fibonacci of a negative number");
            }

            return (ulong)input;
        }

        var n = (uint)input;
        ulong a = 0, b = 1;
        for (var i = 31 - BitOperations.LeadingZeroCount(n); i >= 0; i--)
        {
            var c = a * ((b << 1) - a);
            var d = a * a + b * b;
            a = c;
            b = d;
            if ((n & (1 << i)) == 0)
            {
                continue;
            }

            var temp = a + b;
            a = b;
            b = temp;
        }

        return a;
    }
}
