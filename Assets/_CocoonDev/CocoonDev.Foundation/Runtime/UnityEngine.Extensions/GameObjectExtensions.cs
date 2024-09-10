using System.Collections.Generic;
using UnityEngine;

namespace CocoonDev.Foundation.Unity.Extensions
{
    /// <summary>
    /// Extension Methods used on GameObjects.
    /// </summary>
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Gets the position of the GameObject.
        /// </summary>
        /// <param name="obj">GameObject.</param>
        /// <returns>Position of the GamObject as Vector3.</returns>
        public static Vector3 GetPosition(this GameObject obj) =>
            obj.transform.position;

        /// <summary>
        /// Gets the rotation of the GameObject.
        /// </summary>
        /// <param name="obj">GameObject.</param>
        /// <returns>Rotation of the GamObject as Quaternion.</returns>
        public static Quaternion GetRotation(this GameObject obj) =>
            obj.transform.rotation;

        /// <summary>
        /// Gets the scale of the GameObject.
        /// </summary>
        /// <param name="obj">GameObject.</param>
        /// <returns>Scale of the GamObject as Vector3.</returns>
        public static Vector3 GetScale(this GameObject obj) =>
            obj.transform.localScale;

        /// <summary>
        /// Returns all tags for all GameObjects.
        /// </summary>
        /// <param name="objs">GameObjects.</param>
        /// <returns>Array containing ceah GameObjects tag in order</returns>
        public static string[] GetTags(this GameObject[] objs)
        {
            string[] tags = new string[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                tags[i] = objs[i].tag;
            }
            return tags;
        }

        /// <summary>
        /// Returns all Components of all GameObjects.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="objs">GamObjects.</param>
        /// <returns>Array containing each GameObjects Component in order.</returns>
        public static T[] GetComponents<T>(this GameObject[] objs) where T : Component
        {
            T[] components = new T[objs.Length];
            for (int i = 0; i < objs.Length; i++)
            {
                var component = objs[i].GetComponent<T>();
                components[i] = component;
            }
            return components;
        }

        /// <summary>
        /// Get the first component searching all parents of this GameObject.
        /// </summary>
        public static T GetComponentInParents<T>(this GameObject obj)
        {
            Transform parent = obj.transform.parent; // Get parent

            if (parent == null)
                return default;

            if (parent.TryGetComponent(out T component)) // Get current parents Component
                return component;

            return parent.gameObject.GetComponentInParents<T>();
        }

        /// <summary>
        /// Get all components in every parent of this GameObject.
        /// </summary>
        public static List<T> GetComponentsInParents<T>(this GameObject obj)
        {
            var components = new List<T>(); // Create list
            Transform parent = obj.transform.parent; // Get parent

            if (parent == null)
                return null;

            components.AddRange(parent.GetComponents<T>()); // Get current parents Components

            List<T> parentComponents = parent.gameObject.GetComponentsInParents<T>();

            if (parentComponents != null)
                components.AddRange(parentComponents); // Recursion Magic

            return components;
        }

        /// <summary>
        /// Get all components in every parent of this GameObject.
        /// </summary>
        public static List<T> GetComponentsInParents<T>(this GameObject go, bool includeInactive = false)
        {
            List<T> components = new List<T>(); // Create list
            var parent = go.transform.parent; // Get parent

            if (parent == null)
                return null;

            if (!(includeInactive || parent.gameObject.activeSelf))
                components.AddRange(parent.GetComponents<T>()); // Get current parents Components

            List<T> parentComponents = parent.gameObject.GetComponentsInParents<T>();

            if (parentComponents != null)
                components.AddRange(parentComponents); // Recursion Magic

            return components;
        }

        /// <summary>
        /// Add a component as a copy of another.
        /// </summary>
        public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component =>
            go.AddComponent(toAdd.GetType()).GetCopyOf(toAdd) as T;
    }
}
