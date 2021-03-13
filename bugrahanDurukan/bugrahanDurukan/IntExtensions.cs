using System;
using System.Collections.Generic;
using System.Text;

namespace bugrahanDurukan
{
    // Implement at least one extension method
    public static class IntExtensions
    {
        public static bool IsGreaterThan(this int i, int value)
        {
            return i > value;
        }
    }
}
