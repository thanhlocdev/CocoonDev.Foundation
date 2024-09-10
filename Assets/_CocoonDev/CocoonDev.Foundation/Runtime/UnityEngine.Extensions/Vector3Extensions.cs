using System.Collections.Generic;
using UnityEngine;

namespace CocoonDev.Foundation.Unity.Extensions
{
    /// <summary>
    /// Extension Methods used on Vector3.
    /// </summary>
    public static class Vector3Extensions
    {
        /// <summary>
        /// Set x, y and/or z to any value.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="x">Value to set x to. (Optional)</param>
        /// <param name="y">Value to set y to. (Optional)</param>
        /// <param name="z">Value to set z to. (Optional)</param>
        /// <returns>Vector2 with changed values.</returns>
        public static Vector3 With(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(x ?? vector.x, y ?? vector.y, z ?? vector.z);

        /// <summary>
        /// Add two vectors together.
        /// </summary>
        public static Vector3 Add(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x + x ?? vector.x, vector.y + y ?? vector.y, vector.z + z ?? vector.z);

        /// <summary>
        /// Subtract any value from x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector3 Sub(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x - x ?? vector.x, vector.y - y ?? vector.y, vector.z - z ?? vector.z);

        /// <summary>
        /// Subtract any value from x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to subtract from x. (Optional)</param>
        /// <param name="y">Value to subtract from y. (Optional)</param>
        /// <param name="z">Value to subtract from z. (Optional)</param>
        /// <returns>Vector2 with subtracted values.</returns>
        public static Vector3 Mul(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x * x ?? vector.x, vector.y * y ?? vector.y, vector.z * z ?? vector.z);

        /// <summary>
        /// Divide any value with x, y and/or z.
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="x">Value to divide with x. (Optional)</param>
        /// <param name="y">Value to divide with y. (Optional)</param>
        /// <param name="z">Value to divide with z. (Optional)</param>
        /// <returns>Vector2 with divided values.</returns>
        public static Vector3 Div(this Vector3 vector, float? x = null, float? y = null, float? z = null) =>
            new Vector3(vector.x / x ?? vector.x, vector.y / y ?? vector.y, vector.z / z ?? vector.z);

        /// <summary>
        /// Flatten the vector to a given value on the y axis.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <param name="flatLevel">Value to set y to. (Default = 0)</param>
        /// <returns>Vector3 with y set to 0 or set flat level.</returns>
        public static Vector3 Flat(this Vector3 vector, float flatLevel = 0) =>
            new Vector3(vector.x, flatLevel, vector.z);

        /// <summary>
        /// Finds the direction towards a given vector.
        /// </summary>
        /// <param name="source">Vector.</param>
        /// <param name="destination">Vector to find the direction to.</param>
        /// <returns>Direction in the form of a normalized Vector3.</returns>
        public static Vector3 DirectionTo(this Vector3 source, Vector3 destination) =>
            Vector3.Normalize(destination - source);

        /// <summary>
        /// Rounds each axis of the vector to a whole number.
        /// </summary>
        public static Vector3 Round(this Vector3 vector)
        {
            vector.x = Mathf.Round(vector.x);
            vector.y = Mathf.Round(vector.y);
            vector.z = Mathf.Round(vector.z);
            return vector;
        }

        /// <summary>
        /// Rounds each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector3 Round(this Vector3 vector, float multiple) =>
            (vector / multiple).Round() * multiple;


        /// <summary>
        /// Floors each axis of the vector to a whole number.
        /// </summary>
        public static Vector3 Floor(this Vector3 vector)
        {
            vector.x = Mathf.Floor(vector.x);
            vector.y = Mathf.Floor(vector.y);
            vector.z = Mathf.Floor(vector.z);
            return vector;
        }

        /// <summary>
        /// Floors each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector3 Floor(this Vector3 vector, float multiple) =>
            (vector / multiple).Floor() * multiple;


        /// <summary>
        /// Ceils each axis of the vector to a whole number.
        /// </summary>
        public static Vector3 Ceil(this Vector3 vector)
        {
            vector.x = Mathf.Ceil(vector.x);
            vector.y = Mathf.Ceil(vector.y);
            vector.z = Mathf.Ceil(vector.z);
            return vector;
        }

        /// <summary>
        /// Ceils each axis of the vector to a multiple of a given value.
        /// </summary>
        public static Vector3 Ceil(this Vector3 vector, float multiple) =>
            (vector / multiple).Ceil() * multiple;


        /// <summary>
        /// Converts a Vector3 to a Vector2 using the x and y coordinates.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 x and y coordinates.</returns>
        public static Vector2 ToVector2XY(this Vector3 vector) =>
            new Vector2(vector.x, vector.y);

        /// <summary>
        /// Converts a Vector3 to a Vector2 using the x and z coordinates.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 x and z coordinates.</returns>
        public static Vector2 ToVector2XZ(this Vector3 vector) =>
            new Vector2(vector.x, vector.z);

        /// <summary>
        /// Converts a Vector3 to a Vector2 using the y and z coordinates.
        /// </summary>
        /// <param name="vector">Vector.</param>
        /// <returns>Vector2 found from the Vector3 y and z coordinates.</returns>
        public static Vector2 ToVector2YZ(this Vector3 vector) =>
            new Vector2(vector.y, vector.z);

        /// <summary>
        /// Swap the <see cref="Vector3.x"/>, <see cref="Vector3.y"/> and <see cref="Vector3.z"/> components forwards.
        /// <para>This means x becomes y, y becomes z and z becomes x.</para>
        /// </summary>
        public static Vector3 SwapForwards(this Vector3 vector) => new Vector3(vector.z, vector.x, vector.y);

        /// <summary>
        /// Swap the <see cref="Vector3.x"/>, <see cref="Vector3.y"/> and <see cref="Vector3.z"/> components backwards.
        /// <para>This means x becomes z, y becomes x and z becomes y.</para>
        /// </summary>
        public static Vector3 SwapBackwards(this Vector3 vector) => new Vector3(vector.y, vector.z, vector.x);

        /// <summary>
        /// Finds the closest Vector3 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector3.</param>
        /// <returns>Closest Vector3 to target.</returns>
        public static Vector3 Closest(this Vector3 target, Vector3[] vectors)
        {
            Vector3 closest = new Vector3(Mathf.Infinity, Mathf.Infinity, Mathf.Infinity);
            foreach (Vector3 vector in vectors)
            {
                float current = (vector - target).sqrMagnitude;
                if (current < (closest - target).sqrMagnitude)
                    closest = vector;
            }
            return closest;
        }

        /// <summary>
        /// Finds the farthest Vector3 from an array of vectors.
        /// </summary>
        /// <param name="target">Vector.</param>
        /// <param name="vectors">Array of Vector3.</param>
        /// <returns>Farthest Vector3 from target.</returns>
        public static Vector3 Farthest(this Vector3 target, Vector3[] vectors)
        {
            Vector3 farthest = Vector3.zero;
            foreach (Vector3 vector in vectors)
            {
                float current = (vector - target).sqrMagnitude;
                if (current > (farthest - target).sqrMagnitude)
                    farthest = vector;
            }
            return farthest;
        }

        /// <summary>
        /// Find the average of an array of Vector3.
        /// </summary>
        /// <param name="vectors">Vector Array.</param>
        /// <returns>Average Vector3 from array.</returns>
        public static Vector3 Average(this Vector3[] vectors)
        {
            Vector3 total = Vector3.zero;
            foreach (Vector3 vector in vectors)
                total += vector;

            return total / vectors.Length;
        }

        /// <summary>
        /// Returns the vector with a set origin.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>Original Vector3 with new origin.</returns>
        public static Vector3 WithOrigin(this Vector3 vector, Vector3 origin) =>
            vector + origin;

        /// <summary>
        /// Finds the Cross Product between this vector and given vector.
        /// </summary>
        /// <param name="vector1">This Vector3</param>
        /// <param name="vector2">Given Vector3.</param>
        /// <returns>Cross Product between two Vector2.</returns>
        public static Vector3 Cross(this Vector3 vector1, Vector3 vector2) =>
            Vector3.Cross(vector1, vector2);

        /// <summary>
        /// Returns a Vector2 Perpendicular to the input.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        public static Vector3 PerpXY(this Vector3 vector) =>
            new Vector3(vector.y, -vector.x, 0f);

        /// <summary>
        /// Returns a Vector2 Perpendicular to the input.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        public static Vector3 PerpXZ(this Vector3 vector) =>
            new Vector3(vector.y, 0f, -vector.x);

        /// <summary>
        /// Returns a Vector2 Perpendicular to the input.
        /// </summary>
        /// <param name="vector">Vector3.</param>
        public static Vector3 PerpYZ(this Vector3 vector) =>
            new Vector3(0f, vector.y, -vector.x);

        /// <summary>
        /// Checks if this Vector3 is within a given distance from a given Vector3.
        /// </summary>
        /// <param name="vector">This Vector3.</param>
        /// <param name="radius">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is within. False if not within.</returns>
        public static bool IsWithin(this Vector3 vector, Vector3 origin, float radius) =>
            (vector - origin).sqrMagnitude < radius * radius;

        /// <summary>
        /// Checks if this Vector2 is within a given area.
        /// </summary>
        public static bool IsWithin(this Vector3 vector, Vector3 bottomLeftFront, Vector3 topRightBack) =>
            vector.x > bottomLeftFront.x && vector.x < topRightBack.x &&
            vector.y > bottomLeftFront.y && vector.y < topRightBack.y &&
            vector.z > bottomLeftFront.z && vector.z < topRightBack.z;

        /// <summary>
        /// Checks if this Vector3 is beyond a given distance from a given Vector3.
        /// </summary>
        /// <param name="vector">This Vector3.</param>
        /// <param name="radius">Distance.</param>
        /// <param name="origin">Origin.</param>
        /// <returns>True if is beyond. False if not beyond.</returns>
        public static bool IsBeyond(this Vector3 vector, Vector3 origin, float radius) =>
            (vector - origin).sqrMagnitude > radius * radius;

        /// <summary>
        /// Checks if this Vector2 is beyond a given area.
        /// </summary>
        public static bool IsBeyond(this Vector3 vector, Vector3 bottomLeftFront, Vector3 topRightBack) =>
            vector.x < bottomLeftFront.x || vector.x > topRightBack.x ||
            vector.y < bottomLeftFront.y || vector.y > topRightBack.y ||
            vector.z < bottomLeftFront.z || vector.z > topRightBack.z;

        /// <summary>
        /// Sets the magnitude of a vector.
        /// </summary>
        public static Vector3 SetMagnitude(this Vector3 vector, float magnitude) =>
            vector.normalized * magnitude;


        /// <summary>
        /// Returns a copy of <paramref name="vector"/> with its magnitude clamped to <paramref name="maxLength"/>.
        /// </summary>
        public static Vector3 ClampMagnitude(this Vector3 vector, float maxLength = 1) => Vector3.ClampMagnitude(vector, maxLength);

        /// <summary>
        /// Finds the distance from this vector to the target vector.
        /// </summary>
        public static float DistanceFrom(this Vector3 vector, Vector3 target) => Vector3.Distance(vector, target);

        /// <summary>
        /// Finds the squared distance from this vector to the target vector.
        /// <para>This is faster than <see cref="DistanceFrom(Vector3, Vector3)"/> since it doesn't run a square root operation.</para>
        /// </summary>
        public static float SqrDistanceFrom(this Vector3 vector, Vector3 target) => (target - vector).sqrMagnitude;

        /// <summary>
        /// Find the manhattan distance from this vector to the <paramref name="target"/> vector.
        /// </summary>
        public static float ManhattanDistanceFrom(this Vector3 vector, Vector3 target) =>
            Mathf.Abs(target.x - vector.x) + Mathf.Abs(target.y - vector.y) + Mathf.Abs(target.z - vector.z);

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        public static bool IsCloserThan(this Vector3 position, Vector3 comparedPosition, Vector3 origin)
        {
            float positionCloseness = (position - origin).sqrMagnitude;
            float comparedPositionCloseness = (comparedPosition - origin).sqrMagnitude;

            return positionCloseness < comparedPositionCloseness;
        }

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        /// <param name="closeness">The closeness of the closest position from <paramref name="origin"/> between <paramref name="position"/> and <paramref name="comparedPosition"/>.</param>
        public static bool IsCloserThan(this Vector3 position, Vector3 comparedPosition, Vector3 origin, out float closeness)
        {
            float positionCloseness = (position - origin).sqrMagnitude;
            float comparedPositionCloseness = (comparedPosition - origin).sqrMagnitude;

            bool isCloser = positionCloseness < comparedPositionCloseness;
            closeness = isCloser ? positionCloseness : comparedPositionCloseness;
            return isCloser;
        }

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        /// <param name="closeness">The closeness of the closest position from <paramref name="origin"/> between <paramref name="position"/> and <paramref name="comparedPosition"/>.</param>
        public static bool IsCloserTo(this Vector3 position, Vector3 origin, float closestValue, out float closeness)
        {
            float positionCloseness = (position - origin).sqrMagnitude;

            bool isCloser = positionCloseness < closestValue;
            closeness = isCloser ? positionCloseness : closestValue;
            return isCloser;
        }

        /// <summary>
        /// Checks if <paramref name="position"/> is closer to <paramref name="origin"/> than <paramref name="comparedPosition"/>.
        /// </summary>
        /// <param name="closestValue">Current closest value.
        /// <para>Is updated internally to the closest value between <paramref name="position"/> and the passed in <paramref name="closestValue"/>.</para>
        /// </param>
        public static bool IsCloserTo(this Vector3 position, Vector3 origin, ref float closestValue)
        {
            float positionCloseness = (position - origin).sqrMagnitude;

            bool isCloser = positionCloseness < closestValue;
            closestValue = isCloser ? positionCloseness : closestValue;
            return isCloser;
        }

        /// <summary>
        /// Translates a group of points.
        /// </summary>
        public static IEnumerable<Vector3> Translate(this IEnumerable<Vector3> points, Vector3 translation)
        {
            List<Vector3> result = new List<Vector3>();

            foreach (Vector3 point in points)
                result.Add(point + translation);

            return result;
        }

        /// <summary>
        /// Rotate a <paramref name="worldPosition"/> around a <paramref name="centerOfRotation"/>.
        /// </summary>
        /// <param name="worldPosition">Current world position.</param>
        /// <param name="centerOfRotation">World space position to rotate around.</param>
        /// <param name="orientation">Relative orientation.</param>
        /// <returns><paramref name="worldPosition"/> rotated around <paramref name="centerOfRotation"/> by <paramref name="orientation"/>.</returns>
        public static Vector3 Rotate(this Vector3 worldPosition, Vector3 centerOfRotation, Quaternion orientation)
        {
            var localPosition = worldPosition - centerOfRotation;
            localPosition = orientation * localPosition;
            worldPosition = localPosition + centerOfRotation;
            return worldPosition;
        }

        /// <summary>
        /// Rotate a <paramref name="worldPosition"/> around a <paramref name="centerOfRotation"/>.
        /// </summary>
        /// <param name="worldPosition">Current world position.</param>
        /// <param name="centerOfRotation">World space position to rotate around.</param>
        /// <param name="eulerAngles">Relative angles.</param>
        /// <returns><paramref name="worldPosition"/> rotated around <paramref name="centerOfRotation"/> by <paramref name="eulerAngles"/>.</returns>
        public static Vector3 Rotate(this Vector3 worldPosition, Vector3 centerOfRotation, Vector3 eulerAngles) =>
            Rotate(worldPosition, centerOfRotation, Quaternion.Euler(eulerAngles));

        /// <summary>
        /// Converts a <see cref="Vector3"/> into a C# matrix.
        /// </summary>
        public static float[,] ToMatrix(this Vector3 vector)
        {
            return new float[,]
            {
                {vector.x},
                {vector.y},
                {vector.z},
            };
        }

        /// <summary>
        /// Computes a random point in an annulus (a ring-shaped area) based on minimum and 
        /// maximum radius values around a central Vector3 point (origin).
        /// </summary>
        /// <param name="origin">The center Vector3 point of the annulus.</param>
        /// <param name="minRadius">Minimum radius of the annulus.</param>
        /// <param name="maxRadius">Maximum radius of the annulus.</param>
        /// <returns>A random Vector3 point within the specified annulus.</returns>
        public static Vector3 RandomPointInAnnulus(this Vector3 origin, float minRadius, float maxRadius)
        {
            float angle = Random.value * Mathf.PI * 2f;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // Squaring and then square-rooting radii to ensure uniform distribution within the annulus
            float minRadiusSquared = minRadius * minRadius;
            float maxRadiusSquared = maxRadius * maxRadius;
            float distance = Mathf.Sqrt(Random.value * (maxRadiusSquared - minRadiusSquared) + minRadiusSquared);

            // Converting the 2D direction vector to a 3D position vector
            Vector3 position = new Vector3(direction.x, 0, direction.y) * distance;
            return origin + position;
        }

        public static Vector3 GetRandomPosition(this Bounds bounds)
        {
            var halfWidth = bounds.size.x / 2f;
            var halfHeight = bounds.size.y / 2f;
            var halfDepth = bounds.size.z / 2f;

            var result = bounds.center + new Vector3(
                Random.Range(-halfWidth, halfWidth),
                Random.Range(-halfHeight, halfHeight),
                Random.Range(-halfDepth, halfDepth));

            return result;
        }

        public static Vector3 GetRandomPosition(this Bounds bounds, Quaternion rotation, float offset = 0)
        {
            var halfWidth = bounds.size.x / 2f + offset;
            var halfHeight = bounds.size.y / 2f + offset;
            var halfDepth = bounds.size.z / 2f + offset;

            var result = bounds.center + rotation * new Vector3(
                Random.Range(-halfWidth, halfWidth),
                Random.Range(-halfHeight, halfHeight),
                Random.Range(-halfDepth, halfDepth));

            return result;
        }
    }
}
