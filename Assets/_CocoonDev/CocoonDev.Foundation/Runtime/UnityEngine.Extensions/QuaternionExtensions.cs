using UnityEngine;

namespace CocoonDev.Foundation.Unity.Extensions
{ 
    /// <summary>
    /// Extension Methods used on Quaternions.
    /// </summary>
    public static class QuaternionExtensions
    {
        /// <summary>
        /// Set x, y, z and/or w to any value.
        /// </summary>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <param name="z">Value to set z to. (Optional)</param>
        /// <param name="w">Value to set w to. (Optional)</param>
        /// <returns>Quaternion with changed values.</returns>
        public static Quaternion With(this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null) =>
            new Quaternion(x ?? quaternion.x, y ?? quaternion.y, z ?? quaternion.z, w ?? quaternion.w);

        /// <summary>
        /// Add any value to x, y, z and/or w.
        /// </summary>
        /// <param name="x">Value to add to x. (Optional)</param>
        /// <param name="y">Value to add to y. (Optional)</param>
        /// <param name="z">Value to add to z. (Optional)</param>
        /// <param name="w">Value to add to w. (Optional)</param>
        /// <returns>Quaternion with added values.</returns>
        public static Quaternion Add(this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null) =>
            new Quaternion(quaternion.x + x ?? quaternion.x, quaternion.y + y ?? quaternion.y, quaternion.z + z ?? quaternion.z, quaternion.w + w ?? quaternion.w);

        /// <summary>
        /// Subtract any value from x, y, z and/or w.
        /// </summary>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <param name="w">Value to subtract from w. (Optional)</param>
        /// <returns>Quaternion with subtracted values.</returns>
        public static Quaternion Sub(this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null) =>
            new Quaternion(quaternion.x - x ?? quaternion.x, quaternion.y - y ?? quaternion.y, quaternion.z - z ?? quaternion.z, quaternion.w - w ?? quaternion.w);

        /// <summary>
        /// Multiply any value with x, y, z and/or w.
        /// </summary>
        /// <param name="x">Value to multiply with x. (Optional)</param>
        /// <param name="y">Value to multiply with y. (Optional)</param>
        /// <param name="z">Value to multiply with z. (Optional)</param>
        /// <param name="w">Value to multiply with w. (Optional)</param>
        /// <returns>Quaternion with multiplied values.</returns>
        public static Quaternion Mul(this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null) =>
            new Quaternion(quaternion.x * x ?? quaternion.x, quaternion.y * y ?? quaternion.y, quaternion.z * z ?? quaternion.z, quaternion.w * w ?? quaternion.w);

        /// <summary>
        /// Divide any value with x, y, z and/or w.
        /// </summary>
        /// <param name="x">Value to divide with x. (Optional)</param>
        /// <param name="y">Value to divide with y. (Optional)</param>
        /// <param name="z">Value to divide with z. (Optional)</param>
        /// <param name="w">Value to divide with w. (Optional)</param>
        /// <returns>Quaternion with divided values.</returns>
        public static Quaternion Div(this Quaternion quaternion, float? x = null, float? y = null, float? z = null, float? w = null) =>
            new Quaternion(quaternion.x / x ?? quaternion.x, quaternion.y / y ?? quaternion.y, quaternion.z / z ?? quaternion.z, quaternion.w / w ?? quaternion.w);
    }
}
