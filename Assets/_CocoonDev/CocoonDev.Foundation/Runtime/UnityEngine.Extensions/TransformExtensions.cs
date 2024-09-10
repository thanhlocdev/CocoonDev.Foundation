using UnityEngine;

namespace CocoonDev.Foundation.Unity.Extensions
{
    /// <summary>
    /// Extension Methods used on Transforms.
    /// </summary>
    public static class TransformExtensions
    {
        /// <summary>
        /// Set the individual compoenents of a <paramref name="transform"/>s position.
        /// </summary>
        public static void SetPosition(this Transform transform, float? x = null, float? y = null, float? z = null) =>
            transform.position = new Vector3(x ?? transform.position.x, y ?? transform.position.y, z ?? transform.position.z);

        /// <summary>
        /// Set the individual compoenents of a <paramref name="transform"/>s local position.
        /// </summary>
        public static void SetLocalPosition(this Transform transform, float? x = null, float? y = null, float? z = null) =>
            transform.localPosition = new Vector3(x ?? transform.localPosition.x, y ?? transform.localPosition.y, z ?? transform.localPosition.z);

        /// <summary>
        /// Gets the positions from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Positions of each transform.</returns>
        public static Vector3[] Positions(this Transform[] transforms)
        {
            Vector3[] positions = new Vector3[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                positions[i] = transforms[i].position;
            }
            return positions;
        }

        /// <summary>
        /// Gets the rotations from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Rotations of each transform.</returns>
        public static Quaternion[] Rotations(this Transform[] transforms)
        {
            Quaternion[] rotation = new Quaternion[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                rotation[i] = transforms[i].rotation;
            }
            return rotation;
        }

        /// <summary>
        /// Gets the local scale from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Local scale of each transform.</returns>
        public static Vector3[] LocalScales(this Transform[] transforms)
        {
            Vector3[] localScales = new Vector3[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                localScales[i] = transforms[i].localScale;
            }
            return localScales;
        }

        /// <summary>
        /// Gets the lossy scale from an array of Transforms.
        /// </summary>
        /// <param name="transforms">Transforms.</param>
        /// <returns>Lossy scale of each transform.</returns>
        public static Vector3[] LossyScales(this Transform[] transforms)
        {
            Vector3[] lossyScales = new Vector3[transforms.Length];
            for (int i = 0; i < transforms.Length; i++)
            {
                lossyScales[i] = transforms[i].lossyScale;
            }
            return lossyScales;
        }

        /// <summary>
        /// Gets the root Transform relative to this <paramref name="transform"/>.
        /// </summary>
        public static Transform Root(this Transform transform)
        {
            var parent = transform;
            Transform root = transform;
            while (parent != null)
            {
                parent = parent.parent;

                if (parent != null)
                    root = parent;
            }

            return root;
        }
    }
}
