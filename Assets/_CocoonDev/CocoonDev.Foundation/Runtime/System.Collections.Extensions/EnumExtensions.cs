using System;

namespace CocoonDev.Foundation.System.Collections.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// Converts an enum to int.
        /// </summary>
        /// <typeparam name="T">Generic Type.</typeparam>
        /// <param name="e">Generic Variable.</param>
        /// <returns>Int index of enum value.</returns>
        public static int ToInt<T>(this T e) where T : struct, IComparable
        {
            if (!(typeof(T).IsEnum))
                throw new ArgumentException("Argument must be an enum");
            return (int)(object)e;
        }
    }
}
