using System;
using System.Collections.Generic;
using UnityEngine;
using System.Reflection;

namespace CocoonDev.Foundation.Unity.Extensions
{
    /// <summary>
    /// Extension Methods used on Components.
    /// </summary>
    public static class ComponentExtensions
    {
        /// <summary>
        /// Returns all Components of all GameObjects.
        /// </summary>
        /// <typeparam name="T">Generic type.</typeparam>
        /// <param name="comps">GamObjects.</param>
        /// <returns>Array containing each GameObjects Component in order.</returns>
        public static T[] GetComponents<T>(this Component[] comps) where T : Component
        {
            T[] components = new T[comps.Length];
            for (int i = 0; i < comps.Length; i++)
            {
                var component = comps[i].GetComponent<T>();
                components[i] = component;
            }
            return components;
        }

        /// <summary>
        /// Get the first component searching all parents of this GameObject.
        /// </summary>
        public static T GetComponentInParents<T>(this Component comp)
        {
            var parent = comp.transform.parent; // Get parent

            if (parent == null)
                return default;

            if (parent.TryGetComponent(out T component)) // Get current parents Component
                return component;

            return parent.gameObject.GetComponentInParents<T>();
        }

        /// <summary>
        /// Try to get the first component searching all parents of this GameObject.
        /// </summary>
        public static bool TryGetComponentInParents<T>(this Component comp, out T component)
        {
            component = comp.GetComponentInParents<T>();
            return component != null;
        }

        /// <summary>
        /// Get all components in every parent of this GameObject.
        /// </summary>
        public static List<T> GetComponentsInParents<T>(this Component comp)
        {
            List<T> components = new List<T>(); // Create list
            var parent = comp.transform.parent; // Get parent

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
        public static List<T> GetComponentsInParents<T>(this Component comp, bool includeInactive = false)
        {
            List<T> components = new List<T>(); // Create list
            var parent = comp.transform.parent; // Get parent

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
        /// Get the first component of type <typeparamref name="T"/> in entire objects hierarchy.
        /// </summary>
        public static T GetComponentInEntireObject<T>(this GameObject comp)
        {
            var parent = comp.transform;
            Transform root = comp.transform;
            while (parent != null)
            {
                parent = parent.parent;

                if (parent != null)
                    root = parent;
            }

            return root.GetComponentInChildren<T>();
        }

        /// <summary>
        /// Checks if the <paramref name="componentReference"/> is null and get the component from the <paramref name="comp"/> if it is.
        /// </summary>
        public static void GetComponentIfNull<T>(this Component comp, ref T componentReference, bool logWarnings = true)
        {
            if (componentReference != null)
                return;

            if (logWarnings)
#if CLOGGER
                comp.LogWarning("Extentions", $"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.");
#else
                Debug.LogWarning($"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.", comp);
#endif

            if (comp.TryGetComponent(out componentReference) is false && logWarnings)
#if CLOGGER
                comp.LogError("Extentions", $"No component of type: {typeof(T)} was found on {comp}.");
#else
                Debug.LogError($"No component of type: {typeof(T)} was found on {comp}.", comp);
#endif
        }

        /// <summary>
        /// Checks if the <paramref name="component"/> is null and get the component from the <paramref name="component"/> if it is.
        /// </summary>
        public static T GetComponentIfNull<T>(this Component comp, T component, bool logWarnings = true)
        {
            if (component != null)
                return component;

            if (logWarnings)
#if CLOGGER
                comp.LogWarning("Extentions", $"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.");
#else
                Debug.LogWarning($"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.", comp);
#endif

            if (comp.TryGetComponent(out component) is false && logWarnings)
#if CLOGGER
                comp.LogError("Extentions", $"No component of type: {typeof(T)} was found on {comp}.");
#else
                Debug.LogError($"No component of type: {typeof(T)} was found on {comp}.", comp);
#endif

            return component;
        }

        /// <summary>
        /// Checks if the <paramref name="componentReference"/> is null and get the component from the <paramref name="comp"/> if it is.
        /// </summary>
        public static void GetComponentInParentIfNull<T>(this Component comp, ref T componentReference, bool logWarnings = true)
        {
            if (componentReference != null)
                return;

            if (logWarnings)
#if CLOGGER
                comp.LogWarning("Extentions", $"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.");
#else
                Debug.LogWarning($"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.", comp);
#endif

            componentReference = comp.GetComponentInParent<T>();
            if (componentReference is null && logWarnings)
#if CLOGGER
                comp.LogError("Extentions", $"No component of type: {typeof(T)} was found on {comp}.");
#else
                Debug.LogError($"No component of type: {typeof(T)} was found on {comp}.", comp);
#endif
        }

        /// <summary>
        /// Checks if the <paramref name="component"/> is null and get the component from the <paramref name="comp"/> if it is.
        /// </summary>
        public static T GetComponentInParentIfNull<T>(this Component comp, T component, bool logWarnings = true)
        {
            if (component != null)
                return component;

            if (logWarnings)
#if CLOGGER
                comp.LogWarning("Extentions", $"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.");
#else
                Debug.LogWarning($"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.", comp);
#endif

            component = comp.GetComponentInParent<T>();
            if (component is null && logWarnings)
#if CLOGGER
                comp.LogError("Extentions", $"No component of type: {typeof(T)} was found on {comp}.");
#else
                Debug.LogError($"No component of type: {typeof(T)} was found on {comp}.", comp);
#endif

            return component;
        }

        /// <summary>
        /// Checks if the <paramref name="componentReference"/> is null and get the component from the <paramref name="comp"/> if it is.
        /// </summary>
        public static void GetComponentInChildrenIfNull<T>(this Component comp, ref T componentReference, bool logWarnings = true)
        {
            if (componentReference != null)
                return;

            if (logWarnings)
#if CLOGGER
                comp.LogWarning("Extentions", $"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.");
#else
                Debug.LogWarning($"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.", comp);
#endif

            componentReference = comp.GetComponentInChildren<T>();
            if (componentReference is null && logWarnings)
#if CLOGGER
                comp.LogError("Extentions", $"No component of type: {typeof(T)} was found on {comp}.");
#else
                Debug.LogError($"No component of type: {typeof(T)} was found on {comp}.", comp);
#endif
        }

        /// <summary>
        /// Checks if the <paramref name="component"/> is null and get the component from the <paramref name="comp"/> if it is.
        /// </summary>
        public static T GetComponentInChildrenIfNull<T>(this Component comp, T component, bool logWarnings = true)
        {
            if (component != null)
                return component;

            if (logWarnings)
#if CLOGGER
                comp.LogWarning("Extentions", $"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.");
#else
                Debug.LogWarning($"Field with type {typeof(T)} was not set before playing. It's being assigned automatically.", comp);
#endif

            component = comp.GetComponentInChildren<T>();
            if (component is null && logWarnings)
#if CLOGGER
                comp.LogError("Extentions", $"No component of type: {typeof(T)} was found on {comp}.");
#else
                Debug.LogError($"No component of type: {typeof(T)} was found on {comp}.", comp);
#endif

            return component;
        }

        /// <summary>
        /// Create a full copy of a component.
        /// </summary>
        public static T GetCopyOf<T>(this Component comp, T other) where T : Component
        {
            Type type = comp.GetType();

            if (type != other.GetType())
                return null; // type mis-match

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
            PropertyInfo[] pinfos = type.GetProperties(flags);

            foreach (PropertyInfo pinfo in pinfos)
            {
                if (pinfo.CanWrite)
                {
                    try
                    {
                        pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                    }
                    catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
                }
            }

            FieldInfo[] finfos = type.GetFields(flags);

            foreach (var finfo in finfos)
                finfo.SetValue(comp, finfo.GetValue(other));

            return comp as T;
        }
    }
}
